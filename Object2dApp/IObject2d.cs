using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object2dApp {
    public interface IObject2d {
        double[] Edges { get; set; }
        double Periphery { get; }
    }
}
