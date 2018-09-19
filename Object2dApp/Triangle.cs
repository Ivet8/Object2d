using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object2dApp {

    public class Triangle : Object2d {

        public Triangle(double a, double b, double c) {
            if (a + b <= c || a + c <= b || b + c <= a) {
                throw new NotTriangleException("The entered numbers don't create a triangle.");
            }
            Edges = new double[] { a, b, c };
            Array.Sort(Edges);
            _periphery = a + b + c;
        }
        public Triangle(Object2d obj2d) : this(obj2d.Edges[0], obj2d.Edges[1], obj2d.Edges[2]) {
        }

        /// <summary>
        /// Tests whether the triangle is right.
        /// </summary>
        public bool IsRight() {
             return (Math.Abs(Edges[2] * Edges[2] - (Edges[0] * Edges[0] + Edges[1] * Edges[1])) < 0.00001);
        }
        public override string ToString() {
            return "class Triangle: " + base.ToString();
        }


        class NotTriangleException : Exception {
            public NotTriangleException(String s) : base(s) { }
        }
    }
}
