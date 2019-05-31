using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.C
{
    public class Capture
    {
        private static Capture c;
        public static Capture I { get { if (c == null) c = new Capture(); return c; } }

        private Capture()
        {

        }

        public byte[] Bytes;
    }
}
