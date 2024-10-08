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
    [InlineData("5",5)]
    public void StringSumCalculator_ExpectSumForSingleNumber(string input,int expectedResult)
    {
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.StringSumCalculator(input);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("000",0)]
    [InlineData("sd,0,,,0,asd,0",0)] //string containing multiple zero numbers 
    public void StringSumCalculator_HandleMultipleZerosInString(string input,int expectedResult)
    {
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.StringSumCalculator(input);

        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("1,2",3)]
    [InlineData("1,abc%3^4",8)] 
    public void StringSumCalculator_ExpectSumNumbers(string input,int expectedResult)
    {
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.StringSumCalculator(input);

       Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("-1,2")]
    [InlineData("-1-ac,-2")] //multiple negative numbers mixed with string
    [InlineData("-1,-2,-3")] //multiple negative numbers
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
    [InlineData(",1,2$",3)] //leading and trailing delimeters
    [InlineData("1abc3",4)]
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

    [Theory]
    [InlineData("abc,1000,1",1001)]
    public void StringSumCalculator_HandleNumberEqualto1000(string input,int expectedResult)
    {
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.StringSumCalculator(input);

        Assert.Equal(result,expectedResult);
    }

    [Theory]
    [InlineData("abc",0)]
    [InlineData("#$%%^",0)]
    [InlineData("ac,#$%",0)]
    public void StringCalculator_IgnoreSpecialCharacterAndLetters(string input,int expectedResult)
    {
        StringCalculator objUnderTest = new StringCalculator();
        int result = objUnderTest.StringSumCalculator(input);

        Assert.Equal(result,expectedResult);
    }
}
