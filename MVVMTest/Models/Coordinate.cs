using System;

namespace MVVMTest.Models {

    class Coordinate {

        public double X { get; set; }

        public double Y { get; set; }

        public object Tag { get; set; }

        public static Coordinate Random { get => new Coordinate { X = 1 - 2 * PRNG.NextDouble(), Y = 1 - 2 * PRNG.NextDouble() }; }

        private static readonly Random PRNG = new Random();

    }

}
