using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object2dApp {
    public class Rectangle : Object2d {
        public Rectangle(double a, double b) {
            Edges = new double[] { a, b, a, b };
            _periphery = 2 * (a + b);
        }
        public override string ToString() {
            return "class Rectangle: " + base.ToString();
        }
    }
}
