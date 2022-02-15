using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Triangulation {
    public class Edge:IComparable<Edge> {
        public Point[] Points { get; set; }

        public Edge(Point A, Point B) {
            Points = new[] {A, B};
        }


        public int CompareTo(Edge other) {
            if (this.Points.Contains(other.Points[0]) && this.Points.Contains(other.Points[1]))
                return 1;
            return 0;
        }

        public float GetLength() {
            return (float)Math.Sqrt(Math.Pow(Points[0].X - Points[1].X, 2) + Math.Pow(Points[0].Y - Points[1].Y, 2));
        }
        public override string ToString() {
            return $"[{Points[0]},{Points[1]}],size: {GetLength().ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
