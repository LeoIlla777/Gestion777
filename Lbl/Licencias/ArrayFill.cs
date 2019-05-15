using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lbl.Licencias
{
    public static class ArrayFill
    {
        public static void Fill(ref int[] x, object y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x.SetValue(y, i);
            }
        }
    }
}
