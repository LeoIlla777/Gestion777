using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Lfc.Inicio
{
    public partial class ControlTablero : UserControl
    {
        public ControlTablero()
        {
            InitializeComponent();
        }


        [EditorBrowsable(EditorBrowsableState.Always),
                Browsable(true),
                DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text {
            get {
                return EtiquetaTitulo.Text;
            }
            set {
                EtiquetaTitulo.Text = value;
            }
        }

        public Image Image {
            get {
                return ImagenIcono.Image;
            }
            set {
                ImagenIcono.Image = value;
            }
        }
    }
}
