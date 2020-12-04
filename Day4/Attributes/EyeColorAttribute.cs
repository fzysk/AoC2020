namespace Day4.Attributes
{
    internal sealed class EyeColorAttribute : RegexAttribute
    {
        public EyeColorAttribute() : base("amb|blu|brn|gry|grn|hzl|oth") { }
    }
}
