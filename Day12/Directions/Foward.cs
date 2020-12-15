namespace Day12.Directions
{
    internal class Foward : Direction, ITranslate
    {
        private int _value;

        public Foward(int value)
        {
            _value = value;
        }

        public Direction Translate(Direction old)
        {
            switch (old)
            {
                case North n:
                    n.Vertical += _value;
                    break;
                case East e:
                    e.Horizontal += _value;
                    break;
                case South s:
                    s.Vertical -= _value;
                    break;
                case West w:
                    w.Horizontal -= _value;
                    break;
                default:
                    break;
            }

            return old;
        }
    }
}
