using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10085400_PROG7312_POE.MVVM.Model
{
    public class Node
    {
        public double Value { get; set; }
        public Node Next { get; set; }

        public Node(double value)
        {
            Value = value;
            Next = null;
        }
    }
}
