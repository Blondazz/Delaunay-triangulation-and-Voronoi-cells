using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using QuadTree;

namespace Triangulation {
    public static class Delaunay
    {
        public static int size = 1000;
        /// <summary>
        /// returns a list of delaunay triangles along with a super triangle generated to make it
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public static List<Triangle> TriangulatePoints(List<Point> points) {
            var triangleList = new List<Triangle>();
            var finalTriangleList = new List<Triangle>();
            var superTriangle = generateSuperTriangle(points);
            triangleList.Add(superTriangle);
            
            foreach (var p in points) {
                
                var edgeBuffer = new List<Edge>();
                var tDelete = new List<Triangle>(); 
                foreach (var t in triangleList) {
                    var circle = Calculations.GenerateCircle(t);
                  
                    if (Calculations.IsPointInsideCircle(p, circle)) {
                        foreach (var edge in t.Edges) {
                            edgeBuffer.Add(edge);
                        }
                        tDelete.Add(t);
                    }
                    
                }
                
                foreach (var t in tDelete) {
                    triangleList.Remove(t);
                }

                edgeBuffer = removeDuplicateEdges(edgeBuffer);
                foreach (var edge in edgeBuffer) {
                    var triangle = new Triangle(edge, p);
                    triangleList.Add(triangle);
                }

                
            }
            foreach (var point in superTriangle.Points) {
                points.Add(point);
            }
            return triangleList;
        }
        /// <summary>
        /// Removes the added super triangle from a list of triangles
        /// </summary>
        /// <param name="triangleList"></param>
        /// <param name="points">Points used to make the triangle list</param>
        /// <returns></returns>
        public static List<Triangle> RemoveSuperTriangle(List<Triangle> triangleList, List<Point> points) {
            var superTriangle = new Triangle(points[^1], points[^2], points[^3]);
            points.RemoveRange(points.Count-3, 3);
            var superVerticesTriangles = new List<Triangle>();
            foreach (var triangle in triangleList) {
                if (triangle.Points.Contains(superTriangle.Points[0]) ||
                    triangle.Points.Contains(superTriangle.Points[1]) ||
                    triangle.Points.Contains(superTriangle.Points[2]))
                    superVerticesTriangles.Add(triangle);
            }

            foreach (var superVerticesTriangle in superVerticesTriangles) {
                triangleList.Remove(superVerticesTriangle);
            }
            return triangleList;
        }
        /// <summary>
        /// Returns a list of edges making up a Voronoi diagram from a list of Delaunay triangles
        /// </summary>
        /// <param name="triangles"></param>
        /// <returns></returns>
        public static List<Edge> Voronoi(List<Triangle> triangles) {
            var voronoiEdges = new List<Edge>();
            for (int i = 0; i < triangles.Count-1; i++) {
                for (int j = i+1; j < triangles.Count; j++) {
                    foreach (var edge in triangles[i].Edges) {
                        if (triangles[j].Circumcenter is null) {
                            Calculations.GenerateCircle(triangles[j]);
                        }
                        if (edge.Points.Contains(triangles[j].Edges[0].Points[0])&& edge.Points.Contains(triangles[j].Edges[0].Points[1])) {
                            voronoiEdges.Add(new Edge(triangles[i].Circumcenter, triangles[j].Circumcenter));
                        }
                        else if (edge.Points.Contains(triangles[j].Edges[1].Points[0]) && edge.Points.Contains(triangles[j].Edges[1].Points[1])) {
                            voronoiEdges.Add(new Edge(triangles[i].Circumcenter, triangles[j].Circumcenter));
                        }
                        else if (edge.Points.Contains(triangles[j].Edges[2].Points[0]) && edge.Points.Contains(triangles[j].Edges[2].Points[1])) {
                            voronoiEdges.Add(new Edge(triangles[i].Circumcenter, triangles[j].Circumcenter));
                        }

                    }
                }
            }
            return voronoiEdges;
        }
        /// <summary>
        /// Generates a triangle containing all the points in a provided list
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        private static Triangle generateSuperTriangle(List<Point> points) {
            float xMax = points[0].X;
            float xMin = points[0].X;
            float yMax = points[0].Y;
            float yMin = points[0].Y;
            foreach (var p in points) {
                xMax = p.X > xMax ? p.X : xMax;
                xMin = p.X < xMin ? p.X : xMin;
                yMax = p.Y > yMax ? p.Y : yMax;
                yMin = p.Y < yMin ? p.Y : yMin;
            }

            float dx = xMax - xMin;
            float dy = yMax - yMin;
            float deltaMax = Math.Max(dx,dy);
            float xMid = (xMin + xMax) / 2f;
            float yMid= (yMin + yMax) / 2f;

            var superTriangle = new Triangle(
                new Point(xMid - 1.5f * deltaMax, yMid - deltaMax),
                new Point(xMid, yMid + 1.5f * deltaMax),
                new Point(xMid + 1.5f * deltaMax, yMid - deltaMax));
            return superTriangle;
        }
        /// <summary>
        /// Removes every duplicate edge from the provided list and returns it
        /// </summary>
        /// <param name="edges"></param>
        /// <returns></returns>
        private static List<Edge> removeDuplicateEdges(List<Edge> edges) {
            var indexes = new List<int>();
            for (int i = 0; i < edges.Count-1; i++) {
                for (int j = i+1; j < edges.Count; j++) {
                    if (edges[i].Points.Contains(edges[j].Points[0]) && edges[i].Points.Contains(edges[j].Points[1])) {
                        indexes.Add(i);
                        indexes.Add(j);
                    }
                }
            }
            indexes.Sort();
            indexes.Reverse();
            foreach (var i in indexes) {
                edges.RemoveAt(i);
            }

            return edges;
        }
        /// <summary>
        /// Returns a bitmap containing Points and delaunay Triangles
        /// </summary>
        public static Bitmap Draw(List<Point> points, List<Triangle> triangles, string filename) {
            Bitmap bmp = new Bitmap(1000, 1000);
            float ratio = 1000f / size;
            using (Graphics g = Graphics.FromImage(bmp)) {
                
                Pen pen = new Pen(Color.Black, 2f/ratio);
                Brush brush = new SolidBrush(Color.Magenta);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, 1000, 1000);
                g.DrawLine(new Pen(Color.Blue, 2f/ratio), size/2f * ratio, 0,size/2f * ratio, size * ratio);
                g.DrawLine(new Pen(Color.Blue, 2f/ratio), 0,size/2f * ratio, size * ratio, size/2f * ratio);


                foreach (var triangle in triangles) {
                    foreach (var e in triangle.Edges) {
                        g.DrawLine(pen, e.Points[0].X+size/2f * ratio, e.Points[0].Y+ size/2f * ratio, e.Points[1].X+ size/2f * ratio, e.Points[1].Y+ size/2f * ratio);
                        
                    }
                }

                foreach (var p in points) {
                    g.FillCircle(brush, p.X + size / 2f * ratio, p.Y + size / 2f * ratio, 2.5f);
                }

            }
            //bmp.Save(filename+".jpg");
            return bmp;
        }
        /// <summary>
        /// Returns a bitmap containing points, Delaunay triangles, and Voronoi diagram
        /// </summary>
        /// <param name="points"></param>
        /// <param name="triangles"></param>
        /// <param name="voronoiEdges"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Bitmap Draw(List<Point> points, List<Triangle> triangles, List<Edge> voronoiEdges, string filename) {
            Bitmap bmp = new Bitmap(1000, 1000);
            float ratio = 1000f / size;
            using (Graphics g = Graphics.FromImage(bmp)) {

                Pen pen = new Pen(Color.Black, 2f / ratio);
                Brush brush = new SolidBrush(Color.Magenta);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, 1000, 1000);
                g.DrawLine(new Pen(Color.Blue, 2f / ratio), size / 2f * ratio, 0, size / 2f * ratio, size * ratio);
                g.DrawLine(new Pen(Color.Blue, 2f / ratio), 0, size / 2f * ratio, size * ratio, size / 2f * ratio);

                


                foreach (var triangle in triangles) {
                    foreach (var e in triangle.Edges) {
                        g.DrawLine(pen, e.Points[0].X + size / 2f * ratio, e.Points[0].Y + size / 2f * ratio, e.Points[1].X + size / 2f * ratio, e.Points[1].Y + size / 2f * ratio);

                    }
                }

                foreach (var e in voronoiEdges) {
                    g.DrawLine(new Pen(Color.Red, 2f/ratio), e.Points[0].X + size / 2f * ratio,
                        e.Points[0].Y + size / 2f * ratio, e.Points[1].X + size / 2f * ratio,
                        e.Points[1].Y + size / 2f * ratio);
                }
                foreach (var p in points) {
                    g.FillCircle(brush, p.X + size / 2f * ratio, p.Y + size / 2f * ratio, 2.5f);
                }

            }
            //bmp.Save(filename + ".jpg");
            return bmp;
        }
        /// <summary>
        /// Returns a bitmap containing points and voronoi Diagram
        /// </summary>
        /// <param name="points"></param>
        /// <param name="voronoiEdges"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Bitmap Draw(List<Point> points, List<Edge> voronoiEdges, string filename) {
            Bitmap bmp = new Bitmap(1000, 1000);
            float ratio = 1000f / size;
            using (Graphics g = Graphics.FromImage(bmp)) {

                Pen pen = new Pen(Color.Black, 2f / ratio);
                Brush brush = new SolidBrush(Color.Magenta);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, 1000, 1000);
                g.DrawLine(new Pen(Color.Blue, 2f / ratio), size / 2f * ratio, 0, size / 2f * ratio, size * ratio);
                g.DrawLine(new Pen(Color.Blue, 2f / ratio), 0, size / 2f * ratio, size * ratio, size / 2f * ratio);

                foreach (var e in voronoiEdges) {
                    g.DrawLine(new Pen(Color.Red, 2f/ratio), e.Points[0].X + size / 2f * ratio,
                        e.Points[0].Y + size / 2f * ratio, e.Points[1].X + size / 2f * ratio,
                        e.Points[1].Y + size / 2f * ratio);
                }

                foreach (var p in points) {
                    g.FillCircle(brush, p.X + size / 2f * ratio, p.Y + size / 2f * ratio, 2.5f);
                }

            }
            //bmp.Save(filename + ".jpg");
            return bmp;
        }
    }
}
