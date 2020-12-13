using System.Collections.Generic;
using System.Linq;

namespace Day11
{
    internal class Part1Simulator : SeatsSimulator
    {
        public Part1Simulator(Seat[][] seats) : base(seats) { }

        protected override List<Seat> GetAdjacentSeats(int i, int j, Seat[][] seats)
        {
            List<Seat> adjacentSeats = new List<Seat>();

            for (int i1 = i - 1; i1 <= i + 1; i1++)
            {
                for (int j1 = j - 1; j1 <= j + 1; j1++)
                {
                    if (i1 >= 0 && i1 < seats.Length &&
                        j1 >= 0 && j1 < seats[0].Length &&
                        !(i1 == i && j1 == j))
                    {
                        adjacentSeats.Add(seats[i1][j1]);
                    }
                }
            }

            return adjacentSeats;
        }

        protected override Seat MutateSeat(Seat seat, List<Seat> adjacentSeats)
        {
            switch (seat)
            {
                case Seat.Empty:
                    if (adjacentSeats.All(s => s != Seat.Occupied))
                    {
                        return Seat.Occupied;
                    }
                    break;
                case Seat.Occupied:
                    if (adjacentSeats.Count(s => s == Seat.Occupied) >= 4)
                    {
                        return Seat.Empty;
                    }
                    break;
                case Seat.Floor:
                default:
                    break;
            }

            return seat;
        }
    }
}
