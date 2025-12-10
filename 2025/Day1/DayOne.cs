using advent_of_code._2025;
using advent_of_code._2025.Day1;

namespace advent_of_code
{
    public class DayOne
    {
        [Test]
        public void ChallengeOne()
        {
            var dial = new Dial();
            var input = DayOneInputs.Challenge.Split('\n');
            var password = 0;

            foreach (var line in input) {
                var trimmed = line.Trim();
                if (trimmed.Length == 0) continue;

                var direction = trimmed.Substring(0, 1);
                var times = Int32.Parse(trimmed.Substring(1, trimmed.Length - 1));

                if (direction == "L")
                {
                    if (dial.TurnLeft(times) == 0) password++;
                }
                else
                {
                    if (dial.TurnRight(times) == 0) password++;
                }
            }
            Console.WriteLine(password);
        }

        [Test]
        public void ChallengeTwo()
        {
            var dial = new Dial();
            var input = DayOneInputs.Challenge
                .Split('\n')
                .Select(line => line.Trim())
                .Where(line => line.Length != 0);
            var password = 0;

            foreach (var line in input) {
                var direction = line[..1];
                var times = Int32.Parse(line[1..]);

                password += dial.TurnClicking(direction, times);
            }
            Console.WriteLine(password);
        }
    }
}
