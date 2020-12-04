using System;
using System.Text.RegularExpressions;

namespace Day4.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    internal class RegexAttribute : Attribute, IValiditationAttribute
    {
        public Regex Regex { get; set; }

        public RegexAttribute(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                throw new ArgumentException("Bad regex");
            }

            Regex = new Regex(pattern);
        }

        public bool IsValid(string value)
        {
            return Regex.IsMatch(value);
        }
    }
}
