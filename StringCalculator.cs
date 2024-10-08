using System;
using System.Text.RegularExpressions;

public class StringCalculator
{
    public int StringSumCalculator(string input)
    {
        if (string.IsNullOrEmpty(input))
            return 0;

        // Validate input and calculate sum
        return CalculateSum(ValidateInput(input));
    }

    private string ValidateInput(string input)
    {
        if (Regex.IsMatch(input, @"\n[^\d\w]"))
        {
            throw new Exception("Not valid input: no special character allowed after delimiter \"\n\"");
        }
        return Regex.Replace(input, @"-+", "-", RegexOptions.None); // Remove excess negative signs
    }

    private int CalculateSum(string input)
    {
        // Get numbers separated by delimiters
        MatchCollection numbersCollection = Regex.Matches(input, @"-?\d+");
        int sum = 0;

        foreach (Match match in numbersCollection)
        {
            int number = int.Parse(match.Value); // Parse the matched value
            if (number < 0)
            {
                throw new Exception("No Negative Numbers are Allowed!"); // Throw exception for negative numbers
            }

            sum += number <= 1000 ? number : 0; // Sum numbers less than or equal to 1000
        }

        return sum;
    }
}
