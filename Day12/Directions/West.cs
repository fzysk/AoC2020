namespace Day12.Directions
{
    internal class West : Direction, ITranslate
    {
        public West(int value = 0)
        {
            Horizontal = -value;
        }

        public Direction Translate(Direction old)
        {
            old.Horizontal += Horizontal;
            return old;
        }
    }
}
