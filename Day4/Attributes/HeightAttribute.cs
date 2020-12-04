using System;

namespace Day4.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    internal sealed class HeightAttribute : Attribute, IValiditationAttribute
    {
        private const int UNIT_LENGTH = 2;  // cm or in;
        
        private const string CM = "cm";
        private const int CM_MIN = 150;
        private const int CM_MAX = 193;

        private const string IN = "in";
        private const int IN_MIN = 59;
        private const int IN_MAX = 79;

        public bool IsValid(string height)
        {
            if (string.IsNullOrEmpty(height))
            {
                return false;
            }

            string unit = height.Substring(height.Length - UNIT_LENGTH, UNIT_LENGTH);
            if (int.TryParse(height.Substring(0, height.Length - UNIT_LENGTH), out int value))
            {
                switch (unit)
                {
                    case CM:
                        return CM_MIN <= value && value <= CM_MAX;
                    case IN:
                        return IN_MIN <= value && value <= IN_MAX;
                }
            }

            return false;
        }
    }
}
