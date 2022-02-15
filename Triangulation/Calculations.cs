using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Triangulation.Structures;

namespace Triangulation {
    class Calculations {
        public static Circle GenerateCircle(Triangle triangle) {
            Line l1 = BisectorFinder(triangle.Edges[0], LineFromEdge(triangle.Edges[0]));
            Line l2 = BisectorFinder(triangle.Edges[1], LineFromEdge(triangle.Edges[1]));
            Point center = CrossingPointCramer(l1, l2);
            triangle.Circumcenter = center;
            float radius = TriangleSidesProduct(triangle) / (4 * triangle.GetArea());
            return new Circle(center, radius);

        }
        
        public static bool IsPointInsideCircle(Point p, Circle c) {
            float distance = new Edge(c.Center, p).GetLength();
            if (distance < c.Radius)
                return true;
            return false;
        }

        public static bool IsPointInCircleRange(Point p, Circle c) {
            float xMax = c.Center.X + c.Radius;
            if (p.X < xMax)
                return true;
            return false;
        }
        private static Point CrossingPointCramer(Line line1, Line line2) {
            float w = line1.A * line2.B - line2.A * line1.B;
            if (w == 0) {
                return null;
            }

            float x = (line2.B * line1.C - line1.B * line2.C) / w;
            float y = (line1.A * line2.C - line2.A * line1.C) / w;
            return new Point(x, y);
            // line1.B = -line1.B;
            // line2.B = -line2.B;
            // float w = line1.A * line2.B - line1.B * line2.A;
            // if (w == 0)
            //     return null;
            // float wx = -line1.C * line2.B + line1.B * line2.C;
            // float wy = -line1.A * line2.C + line1.C * line2.A;
            // // Console.WriteLine("The crossing point is: " + wx / w + ";" + wy / w);
            // return new Point(wx / w, wy / w);
        }

        private static Line BisectorFinder(Edge edge, Line line) {
            Point midPoint = new Point((edge.Points[0].X + edge.Points[1].X)/2f, (edge.Points[0].Y + edge.Points[1].Y) / 2f);
            float c = -line.B * (midPoint.X) + line.A * (midPoint.Y);
            float a = -line.B;
            float b = line.A;
            return new Line(a, b, c);
        }

        private static Line LineFromEdge(Edge edge) {
            float a = edge.Points[1].Y - edge.Points[0].Y;
            float b = edge.Points[0].X - edge.Points[1].X;
            return new Line(a, b, (a * edge.Points[0].X + b * edge.Points[0].Y));
        }

        

        private static float TriangleSidesProduct(Triangle t) {
            return t.Edges[0].GetLength() * t.Edges[1].GetLength() * t.Edges[2].GetLength();
        }
        
    }
}
