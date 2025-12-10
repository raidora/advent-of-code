namespace advent_of_code._2025
{
    internal class Dial
    {
        private int indicator = 50;

        public int TurnRight(int times)
        {
            //discard full circles
            indicator += times % 100;
            WrapIndicator();
            return indicator;
        }

        public int TurnLeft(int times)
        {
            indicator -= times % 100;
            WrapIndicator();
            return indicator;
        }

        public void WrapIndicator()
        {
            // 0-99 is a 100 numbers.
            if (indicator < 0) indicator += 100;
            if (indicator > 99) indicator -= 100;
        }
    }
}
