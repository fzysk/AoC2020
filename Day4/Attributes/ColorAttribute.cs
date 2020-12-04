namespace Day4.Attributes
{
    internal sealed class ColorAttribute : RegexAttribute
    {
        public ColorAttribute() : base("#[a-fA-F0-9]{6}") { }
    }
}
