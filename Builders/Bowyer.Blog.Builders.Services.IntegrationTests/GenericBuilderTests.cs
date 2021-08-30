using System;
using System.Collections.Generic;
using System.Text;
using Bowyer.Blog.Builders.Builders;
using Bowyer.Blog.Builders.Database.Entities;
using FluentAssertions;
using NUnit.Framework;

namespace Bowyer.Blog.Builders.Services.IntegrationTests
{
    public class GenericBuilderTests
    {
        [Test]
        public void TestCreatingAnAddressUsingGenericAddressBuilder()
        {
            // Arrange

            // Act
            var actual = new AddressGenericBuilder().Build();

            // Assert
            actual.Should().BeEquivalentTo(BuilderConstants.DefaultAddress);
        }
    }
}