using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Triangulation {
    class Program {
        [STAThread]
       


      
            
        static void Main() {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TriangulationForm());

            // List<Point> points = new List<Point>(500) {
            //     // new Point(300f, 300f),
            //     // new Point(700f, 700f),
            //     // new Point(500f, 100f)
            // };
            // for (int i = 0; i < 500; i++) {
            //     Random r = new Random();
            //     points.Add(new Point((float)r.NextDouble()*2000-1000, (float)r.NextDouble()*2000-1000));
            // }
            //
            // Delaunay.Draw(points, new List<Triangle>(), "img0");
            //
            // var a = Delaunay.TriangulatePoints(points);
            //
            // Delaunay.Draw(points, a, "img1");

        }
    }
}
