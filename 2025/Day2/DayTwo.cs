using System;
using System.Collections.Generic;
using System.Text;

namespace advent_of_code._2025.Day2
{
    internal class DayTwo
    {

        [Test]
        public void ChallengeOne()
        {
            long invalidIDSum = 0;

            var inputs = DayTwoInput.FirstInput
                .Split(',')
                .Select(i => i.Trim())
                .ToList();

            Parallel.ForEach(inputs, i =>
            {
                var range = i.Split('-');
                var start = long.Parse(range[0]);
                var end = long.Parse(range[1]);

                for(var j = start; j <= end; j++)
                {
                    var jStr = j.ToString();
                    var midPoint = jStr.Length / 2;

                    if (jStr.Length % 2 != 0) continue;
                    if (jStr[..midPoint] == jStr[midPoint..])
                    {
                        invalidIDSum += j;
                    }
                }
            });

            Console.WriteLine(invalidIDSum);
        }
    }
}
