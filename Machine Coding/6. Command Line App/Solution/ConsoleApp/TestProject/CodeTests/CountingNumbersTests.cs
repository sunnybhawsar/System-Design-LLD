using ConsoleApp.Code;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestProject
{
    public class CountingNumbersTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("15")]
        [InlineData("15", "foo")]
        [InlineData("15", "foo", "bar")]
        [InlineData("xyz")]
        [InlineData("xyz", "foo")]
        [InlineData("xyz", "bar", "bar")]
        public void RunTestCases(params string[] args)
        {
            // Arrange // Act
            IList<string> result = new CountingNumbers().GetResult(args);

            // Assert
            if (args != null && args.Length > 0)
            {
                switch (args.Length)
                {
                    case 1:
                        try
                        {
                            Assert.Equal(Convert.ToInt32(args[0]), result.Count);
                        }
                        catch(Exception ex)
                        {
                            Assert.Equal("Invalid Input", result[0]);
                        }
                        break;

                    case 2:
                        try
                        {
                            Assert.Equal(Convert.ToInt32(args[0]), result.Count);
                            Assert.Equal(args[1], result[2]);
                        }
                        catch (Exception ex)
                        {
                            Assert.Equal("Invalid Input", result[0]);
                        }                        
                        break;

                    default:
                        try
                        {
                            Assert.Equal(Convert.ToInt32(args[0]), result.Count);
                            Assert.Equal(args[1], result[2]);
                            Assert.Equal(args[2], result[4]);
                        }
                        catch (Exception ex)
                        {
                            Assert.Equal("Invalid Input", result[0]);
                        }                        
                        break;
                }
            }
            else
            {
                Assert.Equal(100, result.Count);
            }            
        }
    }
}