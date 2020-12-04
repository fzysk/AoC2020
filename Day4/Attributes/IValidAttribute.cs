namespace Day4.Attributes
{
    internal interface IValiditationAttribute
    {
        bool IsValid(string value);
    }
}
