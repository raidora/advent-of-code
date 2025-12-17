using System;
using System.Collections.Generic;
using System.Text;

namespace advent_of_code._2025.Day4
{
    internal class DayFour
    {

        [Test]
        public void ChallengeOne()
        {
            var accessibleRolls = 0;

            var inputs = DayFourInput.FirstInput
                .Split('\n')
                .Where(i => i.Length != 0)
                .Select(i => i.Trim())
                .ToList();

            for(int i = 0; i < inputs.Count; i++)
            {
                var observableSlice = new List<string>();

                for (int j = 0; j < inputs[0].Length; j++)
                {
                    if (inputs[i][j] == '@')
                    {
                        observableSlice.Add(i - 1 >= 0 ? inputs[i - 1] : "");
                        observableSlice.Add(inputs[i]);
                        observableSlice.Add(i + 1 < inputs.Count ? inputs[i + 1] : "");

                        accessibleRolls += ValidateAccess(observableSlice, j, 4) ? 1 : 0;
                    }
                }
            }

            Console.WriteLine(accessibleRolls);
        }

        public bool ValidateAccess(List<string> rows, int rollPos, int limitRule)
        {
            var blockedMoves = 0;

            if (rows[0].Length != 0)
            {
                for (int i = rollPos - 1; i <= rollPos + 1; i++) {
                    if (i >= 0 && i < rows[0].Length)
                    {
                        if (rows[0][i] == '@') blockedMoves += 1;
                    }
                }
            }

            for (int i = rollPos - 1; i <= rollPos + 1; i++)
            {
                if (i >= 0 && i < rows[1].Length && i != rollPos)
                {
                    if (rows[1][i] == '@') blockedMoves += 1;
                }
            }


            if (rows[2].Length != 0)
            {
                for (int i = rollPos - 1; i <= rollPos + 1; i++) {
                    if (i >= 0 && i < rows[2].Length)
                    {
                        if (rows[2][i] == '@') blockedMoves += 1;
                    }
                }
            }

            return blockedMoves < limitRule;
        }
    }
}
