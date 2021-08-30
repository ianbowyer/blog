using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Bowyer.Blog.TcpReader.Database.Services;
using Bowyer.Blog.TcpReader.Dto;
using Microsoft.Extensions.Logging;

namespace Bowyer.Blog.TcpReader.Services.Service
{
    public class ProcessPacketService : IProcessPacketService
    {
        private readonly ITelemetryService _telemetryService;
        private readonly ILogger _logger;

        public ProcessPacketService(
            ILoggerFactory loggerFactory,
            ITelemetryService telemetryService)
        {
            _telemetryService = telemetryService;
            _logger = loggerFactory.CreateLogger(GetType());
        }

        public async Task ProcessPacket(TcpClient tcpClient)
        {
            var stream = tcpClient.GetStream();
            var readBuffer = new byte[15];
            var connected = false;
            var packet = new List<byte>();
            var deviceId = "";

            int bytesRead;
            while ((bytesRead = await stream.ReadAsync(readBuffer, 0, readBuffer.Length).ConfigureAwait(false)) != 0)
            {
                packet.AddRange(readBuffer);

                if (!connected && packet.Count >= 15)
                {
                    deviceId = Encoding.UTF8.GetString(readBuffer, 0, 15);
                    Console.WriteLine(deviceId);

                    var valid = CheckIfValidDevice(deviceId);
                    if (valid)
                    {
                        _logger.LogTrace(LogEventIds.DeviceConnected, "Device Accepted!");
                        await ReplyAck(stream);
                        connected = true;
                        packet.RemoveRange(0, 15);
                    }
                    else
                    {
                        _logger.LogTrace(LogEventIds.DeviceDenied, "Device Denied!");
                        await ReplyNack(stream);
                        stream.Close();
                        tcpClient.Close();
                    }
                }

                if (connected)
                {
                    // Continue to read data
                    if (packet.Count >= 16)
                    {
                        var telemetryBytes = packet.GetRange(0, 16).ToArray();
                        var telemetryPacket = new TelemetryPacket(telemetryBytes);
                        _logger.LogInformation(LogEventIds.PacketReceived, $"Telemetry Packet Received for Device {deviceId}. Lat: {telemetryPacket.Latitude} Long: {telemetryPacket.Longitude}");

                        try
                        {
                            // Save to database
                            await _telemetryService.Add(telemetryPacket);
                            await ReplyAck(stream);
                        }
                        catch (Exception e)
                        {
                            await ReplyNack(stream);
                        }
                    }
                }
            }
            stream.Close();
            tcpClient.Close();
        }

        private bool CheckIfValidDevice(string deviceId)
        {
            return true;
        }

        private async Task ReplyNack(NetworkStream stream)
        {
            _logger.LogTrace(LogEventIds.ReplyNack, $"Returning NACK 0x00");
            var nack = new byte[] { 0x00 };
            await stream.WriteAsync(nack, 0, nack.Length).ConfigureAwait(false);
        }

        private async Task ReplyAck(NetworkStream stream)
        {
            _logger.LogTrace(LogEventIds.ReplyAck, $"Returning ACK 0x01");
            var ack = new byte[] { 0x01 };
            await stream.WriteAsync(ack, 0, ack.Length).ConfigureAwait(false);
        }
    }

    public interface IProcessPacketService
    {
        Task ProcessPacket(TcpClient tcpClient);
    }
}