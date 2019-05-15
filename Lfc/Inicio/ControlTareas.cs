using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Lfc.Inicio
{
    public partial class ControlTareas : ControlTablero
    {
        public ControlTareas()
        {
            InitializeComponent();
        }

        private void BotonListado_Click(object sender, EventArgs e)
        {
            Lfx.Workspace.Master.RunTime.Execute("LISTAR", new string[] { "Lbl.Tareas.Tarea" });
        }

        private void BotonCrearTarea_Click(object sender, EventArgs e)
        {
            Lfx.Workspace.Master.RunTime.Execute("CREAR", new string[] { "Lbl.Tareas.Tarea" });
        }
    }
}
