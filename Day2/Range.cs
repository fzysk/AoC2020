namespace Day2
{
    internal class Range
    {
        public int LowerBound { get; private set; }
        public int UpperBound { get; private set; }
        public char Character { get; private set; }

        public Range(int lowerBound, int upperBound, char character)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
            Character = character;
        }

        internal bool IsPhraseInRange(string phrase)
        {
            int counter = 0;
            for (int i = 0; i < phrase.Length; i++)
            {
                if (Character.CompareTo(phrase[i]) == 0 && ++counter > UpperBound)
                {
                    return false;
                }
            }

            if (counter < LowerBound)
            {
                return false;
            }

            return true;
        }

        internal bool IsPhraseValidWithNewPolicy(string phrase)
        {
            return (phrase[LowerBound - 1] == Character) ^ (phrase[UpperBound - 1] == Character);
        }
    }
}
