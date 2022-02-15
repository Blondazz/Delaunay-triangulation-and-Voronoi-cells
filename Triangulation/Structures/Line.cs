using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangulation.Structures {
    public class Line {
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }

        public Line(float a, float b, float c) {
            A = a;
            B = b;
            C = c;

        }
    }
}
