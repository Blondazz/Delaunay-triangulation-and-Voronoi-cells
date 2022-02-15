using System;
using System.Collections.Generic;
using System.Text;

namespace Triangulation {
    public class Triangle {
        public Point[] Points { get; set; }
        public Edge[] Edges { get; }
        private Point A;
        private Point B;
        private Point C;

        public Point Circumcenter { get; set; }

        public Triangle(Point[] points) {
            Points = points;
            A = points[0];
            B = points[1];
            C = points[2];
            Edges = new[] {new Edge(A, B), new Edge(B, C), new Edge(C, A)};
        }
        public Triangle(Point a, Point b, Point c) {
            Points = new[] {a, b, c};
            A = a;
            B = b;
            C = c;
            Edges = new[] { new Edge(A, B), new Edge(B, C), new Edge(C, A) };
        }

        public Triangle(Edge e, Point p) {
            A = e.Points[0];
            B = e.Points[1];
            C = p;
            Points = new[] {A, B, C};
            Edges = new[] {e, new Edge(B, C), new Edge(C, A)};
        }
        public float GetHalfCircumference() {
            return (Edges[0].GetLength() + Edges[1].GetLength() + Edges[2].GetLength()) / 2f;
        }
        public float GetArea() {
            float half = GetHalfCircumference();
            Edge a = Edges[0];
            Edge b = Edges[1];
            Edge c = Edges[2];
            return (float) Math.Sqrt(half * (half - a.GetLength()) * (half - b.GetLength()) * (half - c.GetLength()));
        }
        public override string ToString() {
            return $"{Circumcenter},,{Edges[0]}, {Edges[1]}, {Edges[2]}";
        }

    }
}
