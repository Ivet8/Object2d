using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Object2dApp {
    public class Object2d : IObject2d {
        private double[] _edges;
        public double[] Edges {
            get { return (_edges); }
            set {
                foreach (double e in value) {
                    if (e <= 0) {
                        throw new ArgumentOutOfRangeException("The edges must be positive numbers");
                    }
                }
                _edges = value;
            }
        }
        protected double _periphery;
        public double Periphery {
            get { return (_periphery); }
        }
        public Object2d() { }
        public Object2d(double[] edges) {
            this.Edges = edges;
            _periphery = 0;
            foreach (double e in edges) {
                _periphery += e;
            }
        }
        public override string ToString() {
            string s = "Edges: ";
            foreach (double e in Edges) {
                s += e + " ";
            }
            return s;
        }
        /// <summary>
        /// Writes collection of 2D objects to xml file
        /// </summary>
        /// <param name="objects">collection of Object2d</param>
        /// <param name="path">filename xml</param>
        public static void WriteListXml(List<Object2d> objects, string path) {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement root = xmlDoc.CreateElement("Objects2d");
            foreach (Object2d obj in objects) {
                XmlElement elem = xmlDoc.CreateElement("Object2d");
                for (int i = 0; i < obj.Edges.Length; i++) {
                    XmlAttribute atr = xmlDoc.CreateAttribute("edge" + i);
                    atr.Value = obj.Edges[i].ToString();
                    elem.Attributes.Append(atr);
                }
                root.AppendChild(elem);
                xmlDoc.AppendChild(root);
                xmlDoc.Save(path);
            }
        }
        /// <summary>
        /// Reads collection of 2D objects from xml file.
        /// </summary>
        /// <param name="path">filename xml</param>
        /// <returns>collection of Objects2d</returns>
        public static List<Object2d> ReadListXml(string path) {
            List<Object2d> objects = new List<Object2d>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlNode root = xmlDoc.DocumentElement;
            foreach (XmlNode node in root.ChildNodes) {
                if (node.Name.Equals("Object2d")) {
                    XmlAttributeCollection attributes = node.Attributes;
                    double[] arrayAtr = new double[attributes.Count];
                    for (int i = 0; i < attributes.Count; i++) {
                        arrayAtr[i] = double.Parse(attributes[i].Value);
                    }
                    objects.Add(new Object2d(arrayAtr));
                }
            }
            return objects;
        }
    }
}
