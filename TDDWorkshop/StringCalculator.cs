using System;
using System.Collections.Generic;
using System.Text;

namespace TDDWorkshop
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == "")
                return 0;

            // searching for delimiters
            List<string> delimiters = new List<string>() 
            {
                ",",
                "\n"
            };
            if (numbers.Length > 2 && numbers.Substring(0, 2) == "//")
            {
                if (numbers[2] == '[')
                {
                    StringBuilder str = new StringBuilder();
                    for (int i = 3; i < numbers.Length; i++)
                    {
                        if (numbers[i] == ']')
                            break;
                        str.Append(numbers[i]);
                    }
                    delimiters.Add(str.ToString());
                }
                else
                    delimiters.Add(numbers[2].ToString());
            }

            string[] nrs = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;
            foreach (string nr in nrs)
            {
                if (!int.TryParse(nr, out int add))
                    continue;

                if (add < 0)
                    throw new ArgumentException("Negative numbers.");
                if (add > 1000)
                    continue;

                sum += add;
            }

            return sum;
        }
    }
}
