using System.Collections.Generic;

namespace Day11
{
    internal enum Seat
    {
        Floor = '.',
        Empty = 'L',
        Occupied = '#'
    }

    internal static class SeatMapper
    {
        private static IDictionary<char, Seat> _seatByChar = new Dictionary<char, Seat>()
        {
            { '.', Seat.Floor },
            { 'L', Seat.Empty },
            { '#', Seat.Occupied }
        };

        public static Seat Map(char c) => _seatByChar[c];
    }
}
