namespace Day12.Directions
{
    internal class South : Direction, ITranslate
    {
        public South(int value = 0)
        {
            Vertical = -value;
        }

        public Direction Translate(Direction old)
        {
            old.Vertical += Vertical;
            return old;
        }
    }
}
