using System;
using System.Collections.Generic;
using System.Text;

namespace advent_of_code._2025.Day3
{
    internal class DayThree
    {
        [Test]
        public void ChallengeOne()
        {
            long joltageSum = 0;

            var inputs = DayThreeInput.FirstInput
                .Split('\n')
                .Where(i => i.Length != 0)
                .Select(i => i.Trim());

            foreach (var i in inputs)
            {
                var first = LargestDigit(i, 0);
                if (first.idx == i.Length - 1)
                {
                    first = LargestDigit(i[..(i.Length - 1)], 0);
                }

                var second = LargestDigit(i, first.idx+1);

                joltageSum += long.Parse(first.value.ToString() + second.value.ToString());
            }

            Console.WriteLine(joltageSum);
        }

        public (int idx, int value) LargestDigit(string bank, int start)
        {
            int largest = 0;
            int pos = 0;

            for (var i = start; i < bank.Length; i++)
            {
                var value = (int)Char.GetNumericValue(bank[i]);

                if (value > largest) {
                    largest = value;
                    pos = i;
                    if (largest == 9) break;
                }
            }
            return (pos, largest);
        }
    }
}
