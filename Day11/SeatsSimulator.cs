using System;
using System.Collections.Generic;
using System.Linq;

namespace Day11
{
    internal abstract class SeatsSimulator
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

        protected abstract Seat MutateSeat(Seat seat, List<Seat> adjacentSeats);
        protected abstract List<Seat> GetAdjacentSeats(int i, int j, Seat[][] seats);
    }
}
