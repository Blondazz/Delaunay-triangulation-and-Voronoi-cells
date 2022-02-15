using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangulation {
    public partial class TriangulationForm : Form
    {
        public List<Point> points = new();
        public List<Triangle> triangles = new();
        public List<Edge> voronoiEdges = new();
        public bool isVoronoiWithoutDelaunay = false;
        public bool isDelaunayWithoutVoronoi = false;
        private bool _isMoving = false;
        public TriangulationForm() {
            InitializeComponent();
        }

        private void buttonPoints_Click(object sender, EventArgs e) {
            points = GeneratePoints.Random((int)numericUpDownPoints.Value, 500);
            Bitmap bmp = Delaunay.Draw(points, new List<Triangle>(), "img");
            pictureBox.Image = bmp;
            buttonTriangulate.Enabled = true;
            buttonShowVoronoi.Enabled = false;
            buttonShowDelaunay.Enabled = false;
            buttonMove.Enabled = false;
            isVoronoiWithoutDelaunay = false;
            isDelaunayWithoutVoronoi = false;
            buttonShowVoronoi.Text = "Show Voronoi without Delaunay";
            buttonShowDelaunay.Text = "Show Delaunay without Voronoi";
        }

        private void TriangulationForm_ResizeEnd(object sender, EventArgs e) {
            float ratio = Width / 660f < Height / 560f ? Width / 660f : Height / 560f;
            pictureBox.Width = (int)(500f * ratio);
            pictureBox.Height = (int)(500f * ratio);
        }

        private void buttonTriangulate_Click(object sender, EventArgs e) {
            triangles = Delaunay.TriangulatePoints(points);
            voronoiEdges = Delaunay.Voronoi(triangles);
            triangles = Delaunay.RemoveSuperTriangle(triangles, points);
            var t = new Task(drawVoronoiAndDelaunay);
            t.Start();
            buttonTriangulate.Enabled = false;
            buttonShowDelaunay.Enabled = true;
            buttonShowVoronoi.Enabled = true;
            buttonMove.Enabled = true;
        }

        private void drawTriangles() {
            Bitmap bmp = Delaunay.Draw(points, triangles, "img1");
            pictureBox.Image = bmp;
        }
        

        private void drawVoronoiAndDelaunay() {
            Bitmap bmp = Delaunay.Draw(points, triangles, voronoiEdges, "img2");
            pictureBox.Image = bmp;
            
        }

        private void buttonShowVoronoi_Click(object sender, EventArgs e) {
            isVoronoiWithoutDelaunay = !isVoronoiWithoutDelaunay;
            if (isVoronoiWithoutDelaunay) {
                buttonShowDelaunay.Enabled = false;
                if (_isMoving == false) {
                    var t = new Task(drawVoronoi);
                    t.Start();
                }
                buttonShowVoronoi.Text = "Show Voronoi with Delaunay";
            }
            else {
                buttonShowDelaunay.Enabled = true;
                if (_isMoving == false) {
                    var t = new Task(drawVoronoiAndDelaunay);
                    t.Start();
                }

                buttonShowVoronoi.Text = "Show Voronoi without Delaunay";
            }

           
        }
        private void drawVoronoi() {
            Bitmap bmp = Delaunay.Draw(points, voronoiEdges, "img3");
            pictureBox.Image = bmp;
        }

        private void buttonShowDelaunay_Click(object sender, EventArgs e) {
            isDelaunayWithoutVoronoi = !isDelaunayWithoutVoronoi;
            if (isDelaunayWithoutVoronoi) {
                buttonShowVoronoi.Enabled = false;
                if (_isMoving == false) {
                    var t = new Task(drawTriangles);
                    t.Start();
                }

                buttonShowDelaunay.Text = "Show Delaunay with Voronoi";
            }
            else {
                buttonShowVoronoi.Enabled = true;
                isVoronoiWithoutDelaunay = false;
                if (_isMoving == false) {
                    var t = new Task(drawVoronoiAndDelaunay);
                    t.Start();
                }
               
                buttonShowDelaunay.Text = "Show Delaunay without Voronoi";
            }
        }

        private void buttonMove_Click(object sender, EventArgs e) {
            _isMoving = !_isMoving;
            if (_isMoving) {
                buttonPoints.Enabled = false;
                // Thread thread = new Thread(movePoints);
                // thread.Start();
                var t = new Task(movePoints);
                t.Start();
                buttonMove.Text = "Stop moving points";
            }
            else {
                buttonPoints.Enabled = true;
                buttonMove.Text = "Start moving points";
            }
        }

        private void movePoints() {
            Random random = new Random();

            while (_isMoving) {
                
                foreach (var point in points) {
                    point.X += (float)(random.NextDouble() * 14 - 7);
                    point.Y += (float)(random.NextDouble() * 14 - 7);
                }

                triangles = Delaunay.TriangulatePoints(points);
                voronoiEdges = Delaunay.Voronoi(triangles);
                triangles = Delaunay.RemoveSuperTriangle(triangles, points);
                Bitmap bitmap;
                if (isDelaunayWithoutVoronoi) {
                    bitmap = Delaunay.Draw(points, triangles, "test");
                }
                else if (isVoronoiWithoutDelaunay) {
                    bitmap = Delaunay.Draw(points, voronoiEdges, "test");
                }
                else {
                    bitmap = Delaunay.Draw(points, triangles, voronoiEdges, "test");
                }
                
                pictureBox.Image = bitmap;
                    
                Thread.Sleep(10);
            }
        }
    }

}
