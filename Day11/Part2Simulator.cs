using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day11
{
    internal class Part2Simulator : SeatsSimulator
    {
        public Part2Simulator(Seat[][] seats) : base(seats) { }

        protected override List<Seat> GetAdjacentSeats(int i, int j, Seat[][] seats)
        {
            var adjacentSeats = new List<Seat>();

            // left-top
            int i1 = i - 1, j1 = j - 1;
            while (i1 >= 0 && j1 >= 0)
            {
                if (seats[i1][j1] != Seat.Floor)
                {
                    adjacentSeats.Add(seats[i1][j1]);
                    break;
                }

                i1--; j1--;
            }

            // top
            i1 = i - 1; j1 = j;
            while (i1 >= 0)
            {
                if (seats[i1][j1] != Seat.Floor)
                {
                    adjacentSeats.Add(seats[i1][j1]);
                    break;
                }

                i1--;
            }

            // right-top
            i1 = i - 1; j1 = j + 1;
            while (i1 >= 0 && j1 < seats[0].Length)
            {
                if (seats[i1][j1] != Seat.Floor)
                {
                    adjacentSeats.Add(seats[i1][j1]);
                    break;
                }

                i1--; j1++;
            }

            // left
            i1 = i; j1 = j - 1;
            while (j1 >= 0)
            {
                if (seats[i1][j1] != Seat.Floor)
                {
                    adjacentSeats.Add(seats[i1][j1]);
                    break;
                }

                j1--;
            }

            // right
            i1 = i; j1 = j + 1;
            while (j1 < seats[0].Length)
            {
                if (seats[i1][j1] != Seat.Floor)
                {
                    adjacentSeats.Add(seats[i1][j1]);
                    break;
                }

                j1++;
            }

            // bottom-left
            i1 = i + 1; j1 = j - 1;
            while (i1 < seats.Length && j1 >= 0)
            {
                if (seats[i1][j1] != Seat.Floor)
                {
                    adjacentSeats.Add(seats[i1][j1]);
                    break;
                }

                i1++; j1--;
            }

            // bottom
            i1 = i + 1; j1 = j;
            while (i1 < seats.Length)
            {
                if (seats[i1][j1] != Seat.Floor)
                {
                    adjacentSeats.Add(seats[i1][j1]);
                    break;
                }

                i1++;
            }

            // bottom-left
            i1 = i + 1; j1 = j + 1;
            while (i1 < seats.Length && j1 < seats[0].Length)
            {
                if (seats[i1][j1] != Seat.Floor)
                {
                    adjacentSeats.Add(seats[i1][j1]);
                    break;
                }

                i1++; j1++;
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
                    if (adjacentSeats.Count(s => s == Seat.Occupied) >= 5)
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
