namespace Day5
{
    internal class BoardingPass
    {
        private const int ID_MULTIPLIER = 8;

        public int Row { get; private set; }
        public int Column { get; private set; }

        public BoardingPass(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int GetSeatID()
        {
            return Row * ID_MULTIPLIER + Column;
        }
    }
}
