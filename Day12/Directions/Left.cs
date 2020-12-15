using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Day12.Directions
{
    internal class Left : Direction, IRotate
    {
        private int _value;
        private readonly List<Type> _directions = new List<Type> { typeof(North), typeof(East), typeof(South), typeof(West) };

        public Left(int value)
        {
            if (value % 90 != 0)
            {
                throw new Exception("Rotation not 90 degree multiple!");
            }

            _value = value / 90;
        }

        public Direction Rotate(Direction old)
        {
            int startIndex = _directions.FindIndex(x => x == old.GetType());
            Direction @new = (Direction)FormatterServices.GetUninitializedObject(_directions[Modulo(startIndex - _value, _directions.Count)]);

            @new.Horizontal = old.Horizontal;
            @new.Vertical = old.Vertical;

            return @new;
        }

        private int Modulo(int x, int m)
        {
            int r = x % m;
            return r < 0 ? r + m : r;
        }
    }
}
