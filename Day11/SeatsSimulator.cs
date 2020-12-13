using System;
using System.Collections.Generic;
using System.Linq;

namespace Day11
{
    internal class SeatsSimulator
    {
        Seat[][] _seats;
        Seat[][] _prevSeats;

        public SeatsSimulator(Seat[][] seats)
        {
            _seats = seats;
        }

        public int NumberOfOccupiedSeats
        {
            get
            {
                if (_prevSeats == null)
                {
                    throw new Exception("Please run simulation first");
                }

                return _seats.Sum(row => row.Count(seat => seat == Seat.Occupied));
            }
        }

        public void Simulate()
        {
            int seatChanges;
            do
            {
                // write out current state
                //_seats.ToList().ForEach(x => { x.ToList().ForEach(y => Console.Write((char)y)); Console.WriteLine(); });
                //Console.WriteLine();

                seatChanges = 0;
                _prevSeats = DeepCopy(_seats);

                for (int i = 0; i < _seats.Length; i++)
                {
                    for (int j = 0; j < _seats[i].Length; j++)
                    {
                        Seat currSeat = _prevSeats[i][j];
                        Seat newSeat = MutateSeat(currSeat, GetAdjacentSeats(i, j, _prevSeats));

                        if (currSeat != newSeat)
                        {
                            seatChanges++;
                            _seats[i][j] = newSeat;
                        }
                    }
                }
            } while (seatChanges != 0);
        }

        private Seat MutateSeat(Seat seat, List<Seat> adjacentSeats)
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

        private List<Seat> GetAdjacentSeats(int i, int j, Seat[][] seats)
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

        private Seat[][] DeepCopy(Seat[][] seats)
        {
            var result = new Seat[seats.Length][];

            for (int i = 0; i < seats.Length; i++)
            {
                result[i] = new Seat[seats[i].Length];
                Array.Copy(seats[i], 0, result[i], 0, seats[i].Length);
            }

            return result;
        }
    }
}
