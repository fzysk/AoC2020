using System;

namespace Day4.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    internal sealed class RangeAttribute : Attribute, IValiditationAttribute
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public RangeAttribute(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public bool IsValid(string value)
        {
            if (int.TryParse(value, out int numericalValue))
            {
                return Min <= numericalValue && numericalValue <= Max;
            }

            return false;
        }
    }
}
