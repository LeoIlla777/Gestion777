using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lazaro.Pres.DisplayStyles
{
        public class DarkColors : IDisplayStyle
        {
                public virtual Color BackgroundColor
                {
                        get
                        {
                                return Color.Blue;//Color.Gray;
                        }
                }

                public virtual Color LightColor
                {
                        get
                        {
                            return Color.LightBlue;//Color.LightGray;
                        }
                }


                public virtual Color BorderColor
                {
                        get
                        {
                                return System.Drawing.Color.White;
                        }
                }

                public virtual Color ActiveBorderColor
                {
                        get
                        {
                                return Color.BlueViolet;//Color.Silver;
            }
                }


                public virtual Color DarkColor
                {
                        get
                        {
                                return Color.DarkBlue;//System.Drawing.Color.DarkGray;
                        }
                }

                public virtual Color TextColor
                {
                        get
                        {
                                return System.Drawing.Color.White;
                        }
                }

                public virtual Color GrayTextColor
                {
                        get
                        {
                                return Color.LightBlue;//System.Drawing.Color.LightGray;
                        }
                }

                public virtual Color DataAreaColor
                {
                        get
                        {
                                return Color.LightBlue;//System.Drawing.Color.LightGray;
                        }
                }

                public virtual Color DataAreaTextColor
                {
                        get
                        {
                                return System.Drawing.Color.White;
                        }
                }


                public virtual Color DataAreaGrayTextColor
                {
                        get
                        {
                                return Color.Blue;//System.Drawing.Color.Gray;
                        }
                }


                public virtual Color SelectionColor
                {
                        get
                        {
                                return Color.AliceBlue;//System.Drawing.Color.Silver;
            }
                }

                public virtual Bitmap Icon
                {
                        get
                        {
                                return (Bitmap)(Properties.Resources.ResourceManager.GetObject("form"));
                        }
                }
        }
}
