using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
        }

        [Theory]
        [InlineData("0,0,Taco Bell 2")]
        [InlineData("-13,     -83    ,   Taco Bell  ")]
        public void ShouldParse(string str)
        {

            //Arrange
            var parser = new TacoParser();
            //Act
            var value = parser.Parse(str);
            //Assert
            Assert.NotNull(value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("Example")]
        [InlineData("")]
        [InlineData("             ")]
        [InlineData("0,0")]
        [InlineData("number")]
        [InlineData("0,0,0,Name")]
        [InlineData("91,0,Taco Bell")]
        [InlineData("0,181,Taco Bell")]
        [InlineData("0,-181,Taco Bell")]
        [InlineData("-91,0,Taco Bell")]
        [InlineData("number1,number2,Taco Bell")]
        [InlineData("0,0,Taco Casa")]
        [InlineData("0,0,Wendy's")]
        public void ShouldFailParse(string str)
        {

            //Arrange
            var parser = new TacoParser();
            //Act
            var value = parser.Parse(str);

            //Assert
            Assert.Null(value);
        }
    }
}
