using System;
using System.Collections.Generic;

namespace Lcc.Entrada.Articulos
{
    /// <summary>
    /// Esta es una clase intermedia necesaria para admitir en el editor un control de usuario basado en una clase genérica.
    /// </summary>
    public class AuxiliarMatrizDetalleCompra : MatrizControlesEntrada<DetalleCompra>
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AuxiliarMatrizDetalleCompra
            // 
            this.Name = "AuxiliarMatrizDetalleCompra";
            this.Size = new System.Drawing.Size(825, 180);
            this.ResumeLayout(false);

        }
    }
}
