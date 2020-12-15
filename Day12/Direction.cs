using Day12.Directions;
using System;

namespace Day12
{
    internal abstract class Direction
    {
        protected internal int Horizontal { get; set; }
        protected internal int Vertical { get; set; }

        public Direction Apply(Direction d1)
        {
            switch (d1)
            {
                case ITranslate translator:
                    return translator.Translate(this);
                case IRotate rotor:
                    return rotor.Rotate(this);
                default:
                    throw new ArgumentException("Not handled type");
            }
        }

        public int GetManhattanDistanceFromStartingPoint()
        {
            return Math.Abs(Horizontal) + Math.Abs(Vertical);
        }

        public static Direction CreateDirection(string line)
        {
            char dir = line[0];
            int value = int.Parse(line.Substring(1, line.Length - 1));

            switch (dir)
            {
                case 'N':
                    return new North(value);
                case 'S':
                    return new South(value);
                case 'E':
                    return new East(value);
                case 'W':
                    return new West(value);
                case 'L':
                    return new Left(value);
                case 'R':
                    return new Right(value);
                case 'F':
                    return new Foward(value);
                default:
                    throw new ArgumentException("Invalid line!");
            }
        }
    }
}
