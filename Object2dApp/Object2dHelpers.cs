using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object2dApp {
    public class Object2dHelpers {
        /// <summary>
        /// Tests whether the object is triangle.
        /// </summary>
        public static bool IsTriangle(IObject2d obj) {
            return (obj.Edges.Length == 3 && obj.Edges[0] + obj.Edges[1] > obj.Edges[2] && obj.Edges[0] + obj.Edges[2] > obj.Edges[1] && obj.Edges[1] + obj.Edges[2] > obj.Edges[0]);
        }

        /// <summary>
        /// Tests whether the object is square.
        /// </summary>
        public static bool IsSquare(IObject2d obj) {
            return (obj.Edges.Length == 4 && obj.Edges[0] == obj.Edges[1] && obj.Edges[1] == obj.Edges[2] && obj.Edges[2] == obj.Edges[3]);
        }

        /// <summary>
        /// Tests whether the object is rectangle.
        /// </summary>
        public static bool IsRectangle(IObject2d obj) {
            return (obj.Edges.Length == 4 && !IsSquare(obj) && obj.Edges[0] == obj.Edges[2] && obj.Edges[1] == obj.Edges[3]);
        }

        /// <summary>
        /// Returns triangle with the biggest periphery.
        /// </summary>
        /// <param name="objects"> collection of 2d objects</param>
        /// <returns>triangle with the biggest periphery</returns>
        public static Object2d TriangleWithBiggestPeriphery(List<Object2d> objects) {
            Object2d triangleBiggest = null;
            foreach (Object2d obj in objects) {
                if (IsTriangle(obj)) {
                    if (triangleBiggest == null) {
                        triangleBiggest = obj;
                    }
                    else if (triangleBiggest.Periphery < obj.Periphery) {
                        triangleBiggest = obj;
                    }
                }
            }
            return triangleBiggest;
        }

        /// <summary>
        /// Returns triangle with the smallest periphery.
        /// </summary>
        /// <param name="objects"> collection of 2d objects</param>
        /// <returns>triangle with the smallest periphery</returns>
        public static Object2d TriangleWithSmallestPeriphery(List<Object2d> objects) {
            Object2d triangleSmallest = null;
            foreach (Object2d obj in objects) {
                if (IsTriangle(obj)) {
                    if (triangleSmallest == null) {
                        triangleSmallest = obj;
                    }
                    else if (triangleSmallest.Periphery > obj.Periphery) {
                        triangleSmallest = obj;
                    }
                }
            }
            return triangleSmallest;
        }

        /// <summary>
        /// Returns square with the biggest periphery.
        /// </summary>
        /// <param name="objects"> collection of 2d objects</param>
        /// <returns>square with the biggest periphery</returns>
        public static Object2d SquareWithBiggestPeriphery(List<Object2d> objects) {
            Object2d squareBiggest = null;
            foreach (Object2d obj in objects) {
                if (IsSquare(obj)) {
                    if (squareBiggest == null) {
                        squareBiggest = obj;
                    }
                    else if (squareBiggest.Periphery < obj.Periphery) {
                        squareBiggest = obj;
                    }
                }
            }
            return squareBiggest;
        }

        /// <summary>
        /// Returns square with the smallest periphery.
        /// </summary>
        /// <param name="objects"> collection of 2d objects</param>
        /// <returns>square with the smallest periphery</returns>
        public static Object2d SquareWithSmallestPeriphery(List<Object2d> objects) {
            Object2d squareSmallest = null;
            foreach (Object2d obj in objects) {
                if (IsSquare(obj)) {
                    if (squareSmallest == null) {
                        squareSmallest = obj;
                    }
                    else if (squareSmallest.Periphery > obj.Periphery) {
                        squareSmallest = obj;
                    }
                }
            }
            return squareSmallest;
        }

        /// <summary>
        /// Returns rectangle with the biggest periphery.
        /// </summary>
        /// <param name="objects"> collection of 2d objects</param>
        /// <returns>rectangle with the biggest periphery</returns>
        public static Object2d RectangleWithBiggestPeriphery(List<Object2d> objects) {
            Object2d rectangleBiggest = null;
            foreach (Object2d obj in objects) {
                if (IsRectangle(obj)) {
                    if (rectangleBiggest == null) {
                        rectangleBiggest = obj;
                    }
                    else if (rectangleBiggest.Periphery < obj.Periphery) {
                        rectangleBiggest = obj;
                    }
                }
            }
            return rectangleBiggest;
        }
        /// <summary>
        /// Returns rectangle with the smallest periphery.
        /// </summary>
        /// <param name="objects"> collection of 2d objects</param>
        /// <returns>rectangle with the smallest periphery</returns>
        public static Object2d RectangleWithSmallestPeriphery(List<Object2d> objects) {
            Object2d rectangleSmallest = null;
            foreach (Object2d obj in objects) {
                if (IsRectangle(obj)) {
                    if (rectangleSmallest == null) {
                        rectangleSmallest = obj;
                    }
                    else if (rectangleSmallest.Periphery > obj.Periphery) {
                        rectangleSmallest = obj;
                    }
                }
            }
            return rectangleSmallest;
        }
        /// <summary>
        /// Returns collection of right triangles
        /// </summary>
        /// <param name="objects">collection of 2d objects</param>
        /// <returns>collection of right triangles</returns>
        public static List<Object2d> RightTriangles(List<Object2d> objects) {
            List<Object2d> rightTriangles = new List<Object2d>();
            foreach (Object2d obj in objects) {
                if (obj is Triangle && ((Triangle)obj).IsRight()) {
                    rightTriangles.Add(obj);
                }
                else if (IsTriangle(obj) && new Triangle(obj).IsRight()) {
                    rightTriangles.Add(obj);
                }
            }
            return rightTriangles;
        }
    }
}
