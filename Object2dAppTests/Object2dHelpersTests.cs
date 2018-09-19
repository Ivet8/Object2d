using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Object2dApp;
using System.Collections.Generic;

namespace Object2dAppTests {
    [TestClass]
    public class Object2dHelpersTests {

        #region Tests - IsTriangle()
        [TestMethod]
        public void IsTriangle_true() {
            Assert.IsTrue(Object2dHelpers.IsTriangle(new Triangle( 4, 2, 3 )));
            Assert.IsTrue(Object2dHelpers.IsTriangle(new Object2d(new double[] { 4, 2, 3 })));
            Assert.IsTrue(Object2dHelpers.IsTriangle(new Object2d(new double[] { 1, 1, 1 })));
            Assert.IsTrue(Object2dHelpers.IsTriangle(new Object2d(new double[] { 1.5, 2.1, 2.2 })));
        }
        [TestMethod]
        public void IsTriangle_false() {
            Assert.IsFalse(Object2dHelpers.IsTriangle(new Object2d(new double[] { 5.2, 2, 3.1 })));
            Assert.IsFalse(Object2dHelpers.IsTriangle(new Object2d(new double[] { 2, 2, 4 })));
            Assert.IsFalse(Object2dHelpers.IsTriangle(new Object2d(new double[] { 2, 3, 4, 1 })));
            Assert.IsFalse(Object2dHelpers.IsTriangle(new Object2d(new double[] { 1, 2 })));
            Assert.IsFalse(Object2dHelpers.IsTriangle(new Object2d(new double[] { 1 })));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsTriangle_negativeEdges() {
            Object2dHelpers.IsTriangle(new Object2d(new double[] { -2, -2, -3 }));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsTriangle_zeroEdges() {
            Object2dHelpers.IsTriangle(new Object2d(new double[] { 0, 2, 3 }));
        }
        #endregion

        #region Tests -IsSquare()
        [TestMethod]
        public void IsSquare_true() {
            Assert.IsTrue(Object2dHelpers.IsSquare(new Object2d(new double[] { 1, 1, 1, 1 })));
            Assert.IsTrue(Object2dHelpers.IsSquare(new Object2d(new double[] { 1.5, 1.5, 1.5, 1.5 })));
        }
        [TestMethod]
        public void IsSquare_false() {
            Assert.IsFalse(Object2dHelpers.IsSquare(new Object2d(new double[] { 2, 1, 1, 1 })));
            Assert.IsFalse(Object2dHelpers.IsSquare(new Object2d(new double[] { 1, 2, 1, 1 })));
            Assert.IsFalse(Object2dHelpers.IsSquare(new Object2d(new double[] { 1, 1, 2, 1 })));
            Assert.IsFalse(Object2dHelpers.IsSquare(new Object2d(new double[] { 1, 1, 1, 2 })));
            Assert.IsFalse(Object2dHelpers.IsSquare(new Object2d(new double[] { 1, 1, 1, 1, 1 })));
            Assert.IsFalse(Object2dHelpers.IsSquare(new Object2d(new double[] { 1, 1, 1 })));
            Assert.IsFalse(Object2dHelpers.IsSquare(new Object2d(new double[] { 1, 1 })));
            Assert.IsFalse(Object2dHelpers.IsSquare(new Object2d(new double[] { 1 })));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsSquare_negativeEdges() {
            Object2dHelpers.IsSquare(new Object2d(new double[] { -1, -1, -1, -1 }));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsSquare_zeroEdges() {
            Object2dHelpers.IsSquare(new Object2d(new double[] { 0, 0, 0, 0 }));
        }
        #endregion

        #region Tests - IsRectangle()
        [TestMethod]
        public void IsRectangle_true() {
            Assert.IsTrue(Object2dHelpers.IsRectangle(new Object2d(new double[] { 1, 2, 1, 2 })));
            Assert.IsTrue(Object2dHelpers.IsRectangle(new Object2d(new double[] { 1.5, 2.5, 1.5, 2.5 })));
        }
        [TestMethod]
        public void IsRectangle_false() {
            Assert.IsFalse(Object2dHelpers.IsRectangle(new Object2d(new double[] { 1, 1, 1, 1 })));
            Assert.IsFalse(Object2dHelpers.IsRectangle(new Object2d(new double[] { 2, 1, 1, 1 })));
            Assert.IsFalse(Object2dHelpers.IsRectangle(new Object2d(new double[] { 2, 2, 1, 1 })));
            Assert.IsFalse(Object2dHelpers.IsRectangle(new Object2d(new double[] { 2, 2, 2, 1 })));
            Assert.IsFalse(Object2dHelpers.IsRectangle(new Object2d(new double[] { 5, 1, 5, 1, 5 })));
            Assert.IsFalse(Object2dHelpers.IsRectangle(new Object2d(new double[] { 1, 2, 1 })));
            Assert.IsFalse(Object2dHelpers.IsRectangle(new Object2d(new double[] { 1, 5 })));
            Assert.IsFalse(Object2dHelpers.IsRectangle(new Object2d(new double[] { 1 })));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsRectangle_negativeEdges() {
            Object2dHelpers.IsRectangle(new Object2d(new double[] { -1, -2, -1, -2 }));
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void IsRectangle_zeroEdges() {
            Object2dHelpers.IsRectangle(new Object2d(new double[] { 0, 1, 0, 1 }));
        }
        #endregion

        #region Tests - TriangleWithBiggestPeriphery()
        [TestMethod]
        public void TriangleWithBiggestPeriphery_biggestTrianglefirst() {
            Triangle t1 = new Triangle(3, 4, 5);
            Triangle t2 = new Triangle(1, 2, 1.5);
            Triangle t3 = new Triangle(1, 1, 1);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(t1);
            objects.Add(t2);
            objects.Add(t3);
            Assert.AreSame(t1, Object2dHelpers.TriangleWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void TriangleWithBiggestPeriphery_biggestTrianglemiddle() {
            Triangle t1 = new Triangle(3, 4, 5);
            Triangle t2 = new Triangle(1, 2, 1.5);
            Triangle t3 = new Triangle(1, 1, 1);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(t2);
            objects.Add(t1);
            objects.Add(t3);
            Assert.AreSame(t1, Object2dHelpers.TriangleWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void TriangleWithBiggestPeriphery_biggestTrianglelast() {
            Triangle t1 = new Triangle(3, 4, 5);
            Triangle t2 = new Triangle(1, 2, 1.5);
            Triangle t3 = new Triangle(1, 1, 1);
            Triangle t4 = new Triangle(1, 2.5, 3);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(t2);
            objects.Add(t3);
            objects.Add(t4);
            objects.Add(t1);
            Assert.AreSame(t1, Object2dHelpers.TriangleWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void TriangleWithBiggestPeriphery_samePeriphery() {
            Triangle t1 = new Triangle(3, 4, 5);
            Triangle t2 = new Triangle(2.5, 4.5, 5);
            Triangle t3 = new Triangle(4, 4, 4);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(t1);
            objects.Add(t2);
            objects.Add(t3);
            Assert.AreSame(t1, Object2dHelpers.TriangleWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void TriangleWithBiggestPeriphery_biggestObject2d() {
            Triangle t1 = new Triangle(3, 4, 5);
            Triangle t2 = new Triangle(1, 2, 1.5);
            Triangle t3 = new Triangle(1, 1, 1);
            Object2d o1 = new Object2d(new double[] { 3, 4, 6 });
            Object2d o2 = new Object2d(new double[] { 50, 20 });
            List<Object2d> objects = new List<Object2d>();
            objects.Add(t1);
            objects.Add(t2);
            objects.Add(t3);
            objects.Add(o1);
            objects.Add(o2);
            Assert.AreSame(o1, Object2dHelpers.TriangleWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void TriangleWithBiggestPeriphery_differentObjects() {
            Triangle t1 = new Triangle(3, 4, 5);
            Triangle t2 = new Triangle(1, 2, 1.5);
            Object2d o1 = new Object2d(new double[] { 3, 4, 6 });
            Object2d o2 = new Object2d(new double[] { 50, 20 });
            Object2d o3 = new Object2d(new double[] { 50, 20,60,80 });
            Square s1 = new Square(100);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(t1);
            objects.Add(t2);
            objects.Add(o1);
            objects.Add(o2);
            objects.Add(o3);
            objects.Add(s1);
            Assert.AreSame(o1, Object2dHelpers.TriangleWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void TriangleWithBiggestPeriphery_null() {
            Object2d o1 = new Object2d(new double[] { 50, 20 });
            Object2d o2 = new Object2d(new double[] { 50, 20, 60, 80 });
            Square s1 = new Square(1000);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(o1);
            objects.Add(o2);
            objects.Add(s1);
            Assert.IsNull(Object2dHelpers.TriangleWithBiggestPeriphery(objects));
        }
        #endregion

        #region Tests - TriangleWithSmallestPeriphery()
        [TestMethod]
        public void TriangleWithsmallestPeriphery_smallestTrianglefirst() {
            Triangle t1 = new Triangle(3, 4, 5);
            Triangle t2 = new Triangle(1, 2, 1.5);
            Triangle t3 = new Triangle(1, 1, 1);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(t3);
            objects.Add(t1);
            objects.Add(t2);
            Assert.AreSame(t3, Object2dHelpers.TriangleWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void TriangleWithSmallestPeriphery_smallestTrianglemiddle() {
            Triangle t1 = new Triangle(3, 4, 5);
            Triangle t2 = new Triangle(1, 2, 1.5);
            Triangle t3 = new Triangle(1, 1, 1);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(t1);
            objects.Add(t3);
            objects.Add(t2);
            Assert.AreSame(t3, Object2dHelpers.TriangleWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void TriangleWithSmallestPeriphery_smallestTrianglelast() {
            Triangle t1 = new Triangle(3, 4, 5);
            Triangle t2 = new Triangle(1, 2, 1.5);
            Triangle t3 = new Triangle(1, 1, 1);
            Triangle t4 = new Triangle(1, 2.5, 3);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(t1);
            objects.Add(t2);
            objects.Add(t4);
            objects.Add(t3);
            Assert.AreSame(t3, Object2dHelpers.TriangleWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void TriangleWithSmallestPeriphery_samePeriphery() {
            Triangle t1 = new Triangle(3, 4, 5);
            Triangle t2 = new Triangle(2.5, 4.5, 5);
            Triangle t3 = new Triangle(4, 4, 4);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(t1);
            objects.Add(t2);
            objects.Add(t3);
            Assert.AreSame(t1, Object2dHelpers.TriangleWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void TriangleWithSmallestPeriphery_smallestObject2d() {
            Triangle t1 = new Triangle(3, 4, 5);
            Triangle t2 = new Triangle(1, 2, 1.5);
            Object2d o1 = new Object2d(new double[] { 1, 1, 1 });
            Object2d o2 = new Object2d(new double[] { 0.5, 0.5 });
            List<Object2d> objects = new List<Object2d>();
            objects.Add(t1);
            objects.Add(t2);
            objects.Add(o1);
            objects.Add(o2);
            Assert.AreSame(o1, Object2dHelpers.TriangleWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void TriangleWithSmallestPeriphery_differentObjects() {
            Triangle t1 = new Triangle(3, 4, 5);
            Triangle t2 = new Triangle(1, 2, 1.5);
            Object2d o1 = new Object2d(new double[] { 1, 1, 1 });
            Object2d o2 = new Object2d(new double[] { 0.50, 0.20 });
            Object2d o3 = new Object2d(new double[] { 0.5, 0.1, 0.2, 0.1 });
            Square s1 = new Square(100);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(t1);
            objects.Add(t2);
            objects.Add(o1);
            objects.Add(o2);
            objects.Add(o3);
            objects.Add(s1);
            Assert.AreSame(o1, Object2dHelpers.TriangleWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void TriangleWithSmallestPeriphery_null() {
            Object2d o1 = new Object2d(new double[] { 50, 20 });
            Object2d o2 = new Object2d(new double[] { 50, 20, 60, 80 });
            Square s1 = new Square(10);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(o1);
            objects.Add(o2);
            objects.Add(s1);
            Assert.IsNull(Object2dHelpers.TriangleWithSmallestPeriphery(objects));
        }
        #endregion

        #region Tests - SquareWithBiggestPeriphery()
        [TestMethod]
        public void SquareWithBiggestPeriphery_biggestSquarefirst() {
            Square s1 = new Square(3);
            Square s2 = new Square(1.5);
            Square s3 = new Square(2);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(s1);
            objects.Add(s2);
            objects.Add(s3);
            Assert.AreSame(s1, Object2dHelpers.SquareWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void SquareWithBiggestPeriphery_biggestSquaremiddle() {
            Square s1 = new Square(3);
            Square s2 = new Square(1.5);
            Square s3 = new Square(2);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(s2);
            objects.Add(s1);
            objects.Add(s3);
            Assert.AreSame(s1, Object2dHelpers.SquareWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void SquareWithBiggestPeriphery_biggestSquarelast() {
            Square s1 = new Square(3);
            Square s2 = new Square(1.5);
            Square s3 = new Square(2);
            Square s4 = new Square(2.5);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(s2);
            objects.Add(s3);
            objects.Add(s4);
            objects.Add(s1);
            Assert.AreSame(s1, Object2dHelpers.SquareWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void SquareWithBiggestPeriphery_samePeriphery() {
            Square s1 = new Square(3);
            Square s2 = new Square(3);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(s1);
            objects.Add(s2);
            Assert.AreSame(s1, Object2dHelpers.SquareWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void SquareWithBiggestPeriphery_biggestObject2d() {
            Square s1 = new Square(3);
            Square s2 = new Square(1);
            Object2d o1 = new Object2d(new double[] { 5,5,5,5 });
            Object2d o2 = new Object2d(new double[] { 50, 20 });
            List<Object2d> objects = new List<Object2d>();
            objects.Add(s1);
            objects.Add(s2);
            objects.Add(o1);
            objects.Add(o2);
            Assert.AreSame(o1, Object2dHelpers.SquareWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void SquareWithBiggestPeriphery_differentObjects() {
            Square s1 = new Square(2);
            Object2d o1 = new Object2d(new double[] { 5,5,5,5 });
            Object2d o2 = new Object2d(new double[] { 50, 20 });
            Object2d o3 = new Object2d(new double[] { 50, 20, 60, 80 });
            Rectangle r1 = new Rectangle(100,200);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(s1);
            objects.Add(o1);
            objects.Add(o2);
            objects.Add(o3);
            objects.Add(r1);
            Assert.AreSame(o1, Object2dHelpers.SquareWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void SquareWithBiggestPeriphery_null() {
            Object2d o1 = new Object2d(new double[] { 50, 20 });
            Object2d o2 = new Object2d(new double[] { 50, 20, 60, 80 });
            Rectangle r1 = new Rectangle(10,5);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(o1);
            objects.Add(o2);
            objects.Add(r1);
            Assert.IsNull(Object2dHelpers.SquareWithBiggestPeriphery(objects));
        }
        #endregion

        #region Tests - SquareWithSmallestPeriphery()
        [TestMethod]
        public void SquareWithSmallestPeriphery_smallestSquarefirst() {
            Square s1 = new Square(3);
            Square s2 = new Square(1.5);
            Square s3 = new Square(1);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(s3);
            objects.Add(s1);
            objects.Add(s2);
            Assert.AreSame(s3, Object2dHelpers.SquareWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void SquareWithSmallestPeriphery_smallestSquaremiddle() {
            Square s1 = new Square(3);
            Square s2 = new Square(1.5);
            Square s3 = new Square(1);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(s1);
            objects.Add(s3);
            objects.Add(s2);
            Assert.AreSame(s3, Object2dHelpers.SquareWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void SquareWithSmallestPeriphery_smallestSquarelast() {
            Square s1 = new Square(3);
            Square s2 = new Square(1.5);
            Square s3 = new Square(1);
            Square s4 = new Square(2.5);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(s1);
            objects.Add(s2);
            objects.Add(s4);
            objects.Add(s3);
            Assert.AreSame(s3, Object2dHelpers.SquareWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void SquareWithSmallestPeriphery_samePeriphery() {
            Square s1 = new Square(3);
            Square s2 = new Square(3);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(s1);
            objects.Add(s2);
            Assert.AreSame(s1, Object2dHelpers.SquareWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void SquareWithSmallestPeriphery_smallestObject2d() {
            Square s1 = new Square(300);
            Square s2 = new Square(100);
            Object2d o1 = new Object2d(new double[] { 5, 5, 5, 5 });
            Object2d o2 = new Object2d(new double[] { 5, 2 });
            List<Object2d> objects = new List<Object2d>();
            objects.Add(s1);
            objects.Add(s2);
            objects.Add(o1);
            objects.Add(o2);
            Assert.AreSame(o1, Object2dHelpers.SquareWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void SquareWithSmallestPeriphery_differentObjects() {
            Square s1 = new Square(200);
            Object2d o1 = new Object2d(new double[] { 5, 5, 5, 5 });
            Object2d o2 = new Object2d(new double[] { 5, 2 });
            Object2d o3 = new Object2d(new double[] { 5, 2, 1, 1 });
            Rectangle r1 = new Rectangle(1, 2);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(s1);
            objects.Add(o1);
            objects.Add(o2);
            objects.Add(o3);
            objects.Add(r1);
            Assert.AreSame(o1, Object2dHelpers.SquareWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void SquareWithSmallestPeriphery_null() {
            Object2d o1 = new Object2d(new double[] { 50, 20 });
            Object2d o2 = new Object2d(new double[] { 50, 20, 60, 80 });
            Rectangle r1 = new Rectangle(10, 5);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(o1);
            objects.Add(o2);
            objects.Add(r1);
            Assert.IsNull(Object2dHelpers.SquareWithSmallestPeriphery(objects));
        }
        #endregion

        #region Tests - RectangleWithBiggestPeriphery()
        [TestMethod]
        public void RectangleWithBiggestPeriphery_biggestRectanglefirst() {
            Rectangle r1 = new Rectangle(3,4);
            Rectangle r2 = new Rectangle(1.5,1);
            Rectangle r3 = new Rectangle(2,2);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(r1);
            objects.Add(r2);
            objects.Add(r3);
            Assert.AreSame(r1, Object2dHelpers.RectangleWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void RectangleWithBiggestPeriphery_biggestRectanglemiddle() {
            Rectangle r1 = new Rectangle(3,4);
            Rectangle r2 = new Rectangle(1.5,1);
            Rectangle r3 = new Rectangle(2,2);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(r2);
            objects.Add(r1);
            objects.Add(r3);
            Assert.AreSame(r1, Object2dHelpers.RectangleWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void RectangleWithBiggestPeriphery_biggestRectanglelast() {
            Rectangle r1 = new Rectangle(3,4);
            Rectangle r2 = new Rectangle(1.5,1);
            Rectangle r3 = new Rectangle(2,2);
            Rectangle r4 = new Rectangle(2.5,1);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(r2);
            objects.Add(r3);
            objects.Add(r4);
            objects.Add(r1);
            Assert.AreSame(r1, Object2dHelpers.RectangleWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void RectangleWithBiggestPeriphery_samePeriphery() {
            Rectangle r1 = new Rectangle(3,4);
            Rectangle r2 = new Rectangle(4,3);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(r1);
            objects.Add(r2);
            Assert.AreSame(r1, Object2dHelpers.RectangleWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void RectangleWithBiggestPeriphery_biggestObject2d() {
            Rectangle r1 = new Rectangle(3,5);
            Rectangle r2 = new Rectangle(1,2);
            Object2d o1 = new Object2d(new double[] { 5, 10, 5, 10 });
            Object2d o2 = new Object2d(new double[] { 50, 20 });
            List<Object2d> objects = new List<Object2d>();
            objects.Add(r1);
            objects.Add(r2);
            objects.Add(o1);
            objects.Add(o2);
            Assert.AreSame(o1, Object2dHelpers.RectangleWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void RectangleWithBiggestPeriphery_differentObjects() {
            Rectangle r1 = new Rectangle(2,1);
            Object2d o1 = new Object2d(new double[] { 5, 10, 5, 10 });
            Object2d o2 = new Object2d(new double[] { 50, 20 });
            Object2d o3 = new Object2d(new double[] { 50, 20, 60, 80 });
            Square s1 = new Square(500);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(r1);
            objects.Add(o1);
            objects.Add(o2);
            objects.Add(o3);
            objects.Add(s1);
            Assert.AreSame(o1, Object2dHelpers.RectangleWithBiggestPeriphery(objects));
        }
        [TestMethod]
        public void RectangleWithBiggestPeriphery_null() {
            Object2d o1 = new Object2d(new double[] { 50, 20 });
            Object2d o2 = new Object2d(new double[] { 50, 20, 60, 80 });
            Square s1 = new Square(10);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(o1);
            objects.Add(o2);
            objects.Add(s1);
            Assert.IsNull(Object2dHelpers.RectangleWithSmallestPeriphery(objects));
        }
        #endregion

        #region Tests - RectangleWithSmallestPeriphery()
        [TestMethod]
        public void RectangleWithSmallestPeriphery_smallestRectanglefirst() {
            Rectangle r1 = new Rectangle(3,4);
            Rectangle r2 = new Rectangle(5,1.5);
            Rectangle r3 = new Rectangle(1,2);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(r3);
            objects.Add(r1);
            objects.Add(r2);
            Assert.AreSame(r3, Object2dHelpers.RectangleWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void RectangleWithSmallestPeriphery_smallestRectanglemiddle() {
            Rectangle r1 = new Rectangle(3,4);
            Rectangle r2 = new Rectangle(5,1.5);
            Rectangle r3 = new Rectangle(1,2);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(r1);
            objects.Add(r3);
            objects.Add(r2);
            Assert.AreSame(r3, Object2dHelpers.RectangleWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void RectangleWithSmallestPeriphery_smallestRectanglelast() {
            Rectangle r1 = new Rectangle(3,4);
            Rectangle r2 = new Rectangle(1.5,10);
            Rectangle r3 = new Rectangle(1,2);
            Rectangle r4 = new Rectangle(2.5,10);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(r1);
            objects.Add(r2);
            objects.Add(r4);
            objects.Add(r3);
            Assert.AreSame(r3, Object2dHelpers.RectangleWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void RectangleWithSmallestPeriphery_samePeriphery() {
            Rectangle r1 = new Rectangle(3,4);
            Rectangle r2 = new Rectangle(4,3);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(r1);
            objects.Add(r2);
            Assert.AreSame(r1, Object2dHelpers.RectangleWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void RectangleWithSmallestPeriphery_smallestObject2d() {
            Rectangle r1 = new Rectangle(300,10);
            Rectangle r2 = new Rectangle(100,50);
            Object2d o1 = new Object2d(new double[] { 5, 4, 5, 4 });
            Object2d o2 = new Object2d(new double[] { 5, 2 });
            List<Object2d> objects = new List<Object2d>();
            objects.Add(r1);
            objects.Add(r2);
            objects.Add(o1);
            objects.Add(o2);
            Assert.AreSame(o1, Object2dHelpers.RectangleWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void RectangleWithSmallestPeriphery_differentObjects() {
            Rectangle r1 = new Rectangle(200,10);
            Object2d o1 = new Object2d(new double[] { 5, 4, 5, 4 });
            Object2d o2 = new Object2d(new double[] { 5, 2 });
            Object2d o3 = new Object2d(new double[] { 5, 2, 1, 1 });
            Square s1 = new Square(1);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(r1);
            objects.Add(o1);
            objects.Add(o2);
            objects.Add(o3);
            objects.Add(s1);
            Assert.AreSame(o1, Object2dHelpers.RectangleWithSmallestPeriphery(objects));
        }
        [TestMethod]
        public void RectangleWithSmallestPeriphery_null() {
            Object2d o1 = new Object2d(new double[] { 50, 20 });
            Object2d o2 = new Object2d(new double[] { 50, 20, 60, 80 });
            Square r1 = new Square(10);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(o1);
            objects.Add(o2);
            objects.Add(r1);
            Assert.IsNull(Object2dHelpers.RectangleWithSmallestPeriphery(objects));
        }
        #endregion

        #region Tests - RightTriangles()
        [TestMethod]
        public void RightTriangles_one() {
            Triangle t1 = new Triangle(3, 4, 5);
            Triangle t2 = new Triangle(1, 1, 1);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(t1);
            objects.Add(t2);
            List<Object2d> result = new List<Object2d>();
            result.Add(t1);
            CollectionAssert.AreEqual(result, Object2dHelpers.RightTriangles(objects));
        }
        [TestMethod]
        public void RightTriangles_empty() {
            Triangle t1 = new Triangle(4, 4, 5);
            Triangle t2 = new Triangle(1, 1, 1);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(t1);
            objects.Add(t2);
            Assert.AreEqual(0,Object2dHelpers.RightTriangles(objects).Count);
        }
        [TestMethod]
        public void RightTriangles_more() {
            Triangle t1 = new Triangle(3, 4, 5);
            Triangle t2 = new Triangle(1, 1, 1);
            Triangle t3 = new Triangle(Math.Sqrt(2), 1, 1);
            Triangle t4 = new Triangle(0.5, 1.3, 1.2);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(t1);
            objects.Add(t2);
            objects.Add(t3);
            objects.Add(t4);
            List<Object2d> result = new List<Object2d>();
            result.Add(t1);
            result.Add(t3);
            result.Add(t4);
            CollectionAssert.AreEqual(result, Object2dHelpers.RightTriangles(objects));
        }
        [TestMethod]
        public void RightTriangles_differentObjects() {
            Object2d o1 = new Object2d(new double[] { 3, 4, 5 });
            Object2d o2 = new Object2d(new double[] { 3, 4});
            Square s1 = new Square(5);
            Rectangle r1 = new Rectangle(1, 2);
            Triangle t2 = new Triangle(1, 1, 1);
            Triangle t3 = new Triangle(Math.Sqrt(2), 1, 1);
            Triangle t4 = new Triangle(0.5, 1.3, 1.2);
            List<Object2d> objects = new List<Object2d>();
            objects.Add(o1);
            objects.Add(o2);
            objects.Add(s1);
            objects.Add(r1);
            objects.Add(t2);
            objects.Add(t3);
            objects.Add(t4);
            List<Object2d> result = new List<Object2d>();
            result.Add(o1);
            result.Add(t3);
            result.Add(t4);
            CollectionAssert.AreEqual(result, Object2dHelpers.RightTriangles(objects));
        }
        #endregion
    }
}


