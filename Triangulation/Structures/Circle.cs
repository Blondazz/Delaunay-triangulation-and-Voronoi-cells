using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulation.Structures {
    public class Circle {
        public Point Center { get; set; }
        public float Radius { get; set; }

        public Circle(Point center, float radius) {
            Center = center;
            Radius = radius;
        }

        public override string ToString() {
            return $"{Center}, r={Radius.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
