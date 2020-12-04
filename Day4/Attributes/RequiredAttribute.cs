using System;

namespace Day4.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    internal sealed class RequiredAttribute : Attribute, IValiditationAttribute
    {
        public bool IsValid(string value)
        {
            return !string.IsNullOrEmpty(value);
        }
    }
}
