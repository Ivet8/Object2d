using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object2dApp {
    public class Square : Object2d {
        public Square(double a) {
            Edges = new double[] { a, a, a, a };
            _periphery = 4 * a;
        }

        public override string ToString() {
            return "class Square: " + base.ToString();
        }
    }
}
