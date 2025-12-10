using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace advent_of_code._2025
{
    internal class Dial
    {
        private int _indicator = 50;

        public int TurnRight(int times)
        {
            //discard full circles
            _indicator += times % 100;
            WrapIndicator();
            return _indicator;
        }

        public int TurnLeft(int times)
        {
            _indicator -= times % 100;
            WrapIndicator();
            return _indicator;
        }

        public int TurnClicking(string direction, int times)
        {
            int clicks = times / 100;

            _indicator += direction switch
            {
                "R" => times % 100,
                "L" => -(times % 100),
                _ => throw new ArgumentException("direction must be 'L' or 'R'"),
            };

            if (WrapIndicator()) clicks++;
            return clicks;
        }

        public bool WrapIndicator()
        {
            // 0-99 is a 100 numbers.
            if (_indicator < 0)
            {
                _indicator += 100;
                return true;
            }

            if (_indicator > 99)
            {
                _indicator -= 100;
                return true;
            }

            return false;
        }
    }
}
