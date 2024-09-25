using System;
using System.Collections.Generic;
using Xunit;


public class StringCalculatorAddTests
{
    [Theory]
    [InlineData("",0)]
    public void StringSumCalculator_ExpectZeroForEmptyInput(string input,int expectedResult)
    {
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.StringSumCalculator(input);

       Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("0",0)]
    public void StringSumCalculator_ExpectZeroForSingleZero(string input,int expectedResult)
    {
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.StringSumCalculator(input);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("1,2",3)]
    public void StringSumCalculator_ExpectSumForTwoNumbers(string input,int expectedResult)
    {
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.StringSumCalculator(input);

       Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("-1,2")]
    public void StringSumCalculator_ExpectExceptionForNegativeNumbers(string input)
    {
        Assert.Throws<Exception>(() =>
        {
            string input = "-1,2";
            StringCalculator objUnderTest = new StringCalculator();
            objUnderTest.StringSumCalculator(input);
        });
    }

    [Theory]
    [InlineData("1\n2,3",6)]
    public void StringSumCalculator_ExpectSumWithNewlineDelimiter(string input,int expectedResult)
    {
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.StringSumCalculator(input);

       Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("1,1001",1)]
    public void StringSumCalculator_IgnoreNumbersGreaterThan1000(string input,int expectedResult)
    {
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.StringSumCalculator(input);

       Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("//;\n1;2",3)]
    public void StringSumCalculator_ExpectSumWithCustomDelimiter(string input,int expectedResult)
    {
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.StringSumCalculator(input);

       Assert.Equal(expectedResult, result);
    }
    [Theory]
    [InlineData("1,2\n,3")]
    public void StringSumCalculator_ExceptionForSpecialCharacterAfterNewLineCharacter(string input)
    {
         Assert.Throws<Exception>(() =>
        {
            StringCalculator objUnderTest = new StringCalculator();
            objUnderTest.StringSumCalculator(input);
        });
    }
}
