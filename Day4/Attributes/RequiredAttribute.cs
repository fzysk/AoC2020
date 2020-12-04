using System;

namespace Day4.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    sealed class RequiredAttribute : Attribute
    {
       
    }
}
