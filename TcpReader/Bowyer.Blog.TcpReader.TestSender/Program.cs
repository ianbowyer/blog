using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Bowyer.Blog.TcpReader.Dto;

namespace Bowyer.Blog.TcpReader.TestSender
{
    public class Program
    {
        private const string Hostname = "localhost";
        private const int Port = 10500;

        private static async Task Main(string[] args)
        {
            var numberOfTelemetryToSend = 100;

            var tasks = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                 tasks.Add(OpenTcpSocketAndSendData($"{i:D15}", numberOfTelemetryToSend));
            }

            Task.WaitAll(tasks.ToArray());
            Console.Write("Press any key to continue");
            Console.ReadKey();
        }

        private static async Task OpenTcpSocketAndSendData(string userInput, int numberOfTelemetryToSend)
        {
            Console.WriteLine($"Connecting .....");
            using (var tcpClient = new TcpClient(Hostname, Port))
            {
                Console.WriteLine("Connected");
                await using (var dataStream = tcpClient.GetStream())
                {
                    var encoding = new ASCIIEncoding();
                    byte[] ba = encoding.GetBytes(userInput);
                    Console.WriteLine("Transmitting text ...");

                    // Write data to server
                    await dataStream.WriteAsync(ba, 0, ba.Length);
                    Console.WriteLine($"Finished Sending: {userInput}\n");

                    // Read response back from server
                    Console.WriteLine("Awaiting Response.....");
                    byte[] readBuffer = new byte[100];

                    await dataStream.ReadAsync(readBuffer, 0, 1);
                    var ack = BitConverter.ToBoolean(readBuffer, 0);

                    // Check if ACK or NACK
                    if (ack)
                    {
                        WriteLine("ACK", ConsoleColor.Green);

                        // Create a Telemetry Packet and Send
                        for (int i = 0; i < numberOfTelemetryToSend; i++)
                        {
                            var telemetryPacket = new TelemetryPacket(52.1, 0.1).GenerateBytes();

                            Console.WriteLine("Sending Telemetry Packet...");
                            await dataStream.WriteAsync(telemetryPacket, 0, telemetryPacket.Length);
                            Console.WriteLine("Telemetry Packet Sent\n");
                            await dataStream.ReadAsync(readBuffer, 0, 1);
                            var telemetryAck = BitConverter.ToBoolean(readBuffer, 0);
                            if (telemetryAck)
                            {
                                WriteLine("ACK Telemetry", ConsoleColor.Green);
                            }
                            else
                            {
                                WriteLine("NACK Telemetry", ConsoleColor.Red);
                            }
                        }
                    }
                    else
                    {
                        WriteLine("NACK", ConsoleColor.Red);
                        WriteLine("Closing connection", ConsoleColor.Red);
                    }
                }
            }
        }

        private static void WriteLine(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}