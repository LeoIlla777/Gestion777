using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lazaro.Pres.DisplayStyles
{
        public class Brown : DarkColors
        {
                public override Color BackgroundColor
                {
                        get
                        {
                                return Color.FromArgb(66, 122, 162);//System.Drawing.Color.SaddleBrown;
                        }
                }


                public override Color DarkColor
                {
                        get
                        {
                                return Color.DarkBlue;//System.Drawing.Color.Brown;
                        }
                }


                public override Color LightColor
                {
                        get
                        {
                                return Color.LightBlue;//System.Drawing.Color.Sienna;
                        }
                }

                public override Bitmap Icon
                {
                        get
                        {
                                return (Bitmap)(Properties.Resources.ResourceManager.GetObject("tareas"));
                        }
                }
        }
}