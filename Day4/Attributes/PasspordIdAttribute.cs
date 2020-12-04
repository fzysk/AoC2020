namespace Day4.Attributes
{
    internal sealed class PasspordIdAttribute : RegexAttribute
    {
        public PasspordIdAttribute() : base("[0-9]{9}") { }
    }
}
