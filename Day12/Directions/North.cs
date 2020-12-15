namespace Day12.Directions
{
    internal class North : Direction, ITranslate
    {
        public North(int value = 0)
        {
            Vertical = value;
        }

        public Direction Translate(Direction old)
        {
            old.Vertical += Vertical;
            return old;
        }
    }
}
