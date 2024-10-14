namespace Divide25.Services
{
    public class DivisibleService
    {
        // Method to calculate the smallest number divisible by all numbers in the provided range
        public long GetSmallestNumberDivisibleByRange(int start, int end)
        {
            try
            {
                // result must start on 1, otherwise CalculateLcm would fail
                long result = 1; 
                for (int i = start; i <= end; i++)
                {
                    result = checked(CalculateLcm(result, i));
                }
                return result;
            }
            // Catch a overflow in case the server throws it and return the error to the API
            catch (OverflowException)
            {
                throw new OverflowException("The result has exceeded the maximum allowable value.");
            }
        }

        private long CalculateLcm(long num1, long num2)
        {
            // LCM is calculated using the formula: LCM(a, b) = (a * b) / CalculateGc(a, b)
            // This formula helps to find the smallest number that both num1 and num2 can divide without leaving a remainder.
            // Using GCD greatly speeds up the calculation speed compared to previous solutions made.
            return (num1 * num2) / CalculateGcd(num1, num2);
        }

        private long CalculateGcd(long num1, long num2)
        {
            // This method finds the largest number that can divide both num1 and num2 without leaving a remainder
            // It works by repeatedly taking the remainder of num1 divided by num2 until num2 becomes zero
            // At which point, num1 will hold the GCD of the original two numbers
            while (num2 != 0)
            {
                long remainder = num2;
                num2 = num1 % num2;
                num1 = remainder;
            }
            return num1;
        }

    }
}
