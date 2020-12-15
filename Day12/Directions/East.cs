namespace Day12.Directions
{
    internal class East : Direction, ITranslate
    {
        public East(int value = 0)
        {
            Horizontal = value;
        }

        public Direction Translate(Direction old)
        {
            old.Horizontal += Horizontal;
            return old;
        }
    }
}
