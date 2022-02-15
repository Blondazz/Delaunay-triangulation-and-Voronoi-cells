using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulation {
    public static class GeneratePoints {
        public static List<Point> Random(int amount, int range) {
            var points = new List<Point>(amount);
            for (int i = 0; i < amount; i++) {
                Random r = new Random();
                points.Add(new Point((float)r.NextDouble()*range*2-range, (float)r.NextDouble()*range*2-range));
            }

            return points;
        }
    }
}
