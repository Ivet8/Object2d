using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object2dApp {
    class Program {
        static void Main(string[] args) {
            Triangle t = new Triangle(3, 4, 5);
            Rectangle r = new Rectangle(1, 2);
            Square s = new Square(1);
            Object2d o1 = new Object2d(new double[] { 3, 4, 6 });
            Object2d o2 = new Object2d(new double[] { 50, 20 });
            List<Object2d> objects = new List<Object2d>();
            objects.Add(t);
            objects.Add(r);
            objects.Add(s);
            objects.Add(o1);
            objects.Add(o2);
            Console.WriteLine("2d objects:");
            foreach (Object2d obj in objects) {
                Console.WriteLine(obj.ToString());
            }
            Object2d.WriteListXml(objects, "writelist.xml");
            Console.WriteLine();
            Console.WriteLine("Reading 2d objects from xml:");
            List<Object2d> objects2 = Object2d.ReadListXml("writelist.xml");
            foreach (Object2d obj in objects2) {
                Console.WriteLine(obj.ToString());
            }
        }
    }
}
