using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ukoly
{
    public class FHNode
    {
        public int key;
        public FHNode? parent;
        public FHNode left;
        public FHNode right;
        public FHNode? child;
        public int degree;
        public bool marked;

        public FHNode(int key)
        {
            this.key = key;
            this.parent = null;
            this.child = null;
            this.left = this;
            this.right = this;
            this.degree = 0;
            this.marked = false;
        }
    }
}
