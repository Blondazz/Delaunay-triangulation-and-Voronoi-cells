using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Triangulation {
    public class Point {
        public float X { get; set; }
        public float Y { get; set; }

        public Point(float x, float y) {
            X = x;
            Y = y;
        }

        public override string ToString() {
            return $"({X.ToString(CultureInfo.InvariantCulture)}; {Y.ToString(CultureInfo.InvariantCulture)})";
        }
    }
}
