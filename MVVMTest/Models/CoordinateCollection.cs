using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Woof.WindowsEx;

namespace MVVMTest.Models {

    class CoordinateCollection : List<Coordinate> {
        
        public CoordinateCollection(int n) { for (int i = 0; i < n; i++) Add(Coordinate.Random); }

    }



}
