using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lazaro.Pres.DisplayStyles
{
        public class Articulos : Blue
        {
                public override Bitmap Icon
                {
                        get
                        {
                                return (Bitmap)(Properties.Resources.ResourceManager.GetObject("articulo"));
                        }
                }
        }
}
