using System;
using System.Text;
using System.Text.RegularExpressions;

public class StringCalculator
{
    public int StringSumCalculator(string input)
    {
        if (string.IsNullOrEmpty(input))
            return 0;

        //validates 
        ValidateCharacterAfterNewline(input);
		int result  = CalculateSum(input);
        return result;
    }

    private void ValidateCharacterAfterNewline(string input)
    {
        if (Regex.IsMatch(input, @"\n[^\d\w]"))
        {
            throw new InvalidOperationException("Not valid input: not allowed to add delimter after \"\n\"");
        }
    }

    private int CalculateSum(string input)
    {
        // Regular expression that removes excess negative signs
        string preprocessedNumbers = Regex.Replace(input, @"-+", "-", RegexOptions.None);
        // Regular expression that gets numbers separated by delimiters
        MatchCollection NumbersCollection = Regex.Matches(preprocessedNumbers, @"\b-?\d+\b");
        int sum = 0;
        foreach (Match match in NumbersCollection)
        {
            int number = int.Parse(match.Value); //parse the matched value

            sum += ValidateAndSum(number); // Validates number and sum the number
        }
        return sum;
    }
    private int ValidateAndSum(int number)
    {
        if (number < 0) //throws exception when number is negative
        {
            throw new InvalidOperationException("No Negative Numbers are Allowed!");
        }

        return number < 1000 ? number : 0;
    }

}
