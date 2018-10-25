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
        [InlineData("Example")]
        [InlineData("0,0,Taco Bell 2")]
        [InlineData("-13,     -83    ,   Taco Bell  ")]
        public void ShouldParse(string str)
        {
            // TODO: Complete Should Parse
            //Arrange
            var parser = new TacoParser();
            //Act
            var value = parser.Parse(str);
            //Assert
            Assert.NotNull(value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse
            //Arrange
            var parser = new TacoParser();
            //Act
            var value = parser.Parse(str);

            //Assert
            Assert.Null(value);
        }
    }
}
