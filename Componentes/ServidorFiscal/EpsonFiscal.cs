using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiscal
{
    /// <summary>
    /// TM-U220AFII
    /// TM-T900FA
    /// </summary>
    public class EpsonFiscal
    {
        /* -----------------------------------------------------------------------------
        Typedef from exported Prototypes of "EpsonFiscalInterface.h"
        ----------------------------------------------------------------------------- */
        // ConfigurarVelocidad()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ConfigurarVelocidad(int velocidad);

        // ConfigurarPuerto()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ConfigurarPuerto(string puerto);

        // Conectar()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int Conectar();

        // Desconectar()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int Desconectar();

        // Consultar()
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ConsultarVersionDll(StringBuilder descripcion, int descripcion_largo_maximo, ref int mayor, ref int menor);

        // ImprimirCierreX() 
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                                CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ImprimirCierreX();

        // ImprimirCierreZ() 
        [System.Runtime.InteropServices.DllImport("EpsonFiscalInterface.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi,
                                                                               CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static extern int ImprimirCierreZ();


        /* -----------------------------------------------------------------------------
        Function: dll_version()
        ----------------------------------------------------------------------------- */
        void dll_version()
        {
            const int str_len = 100;
            StringBuilder str = new StringBuilder(str_len);
            int mayor = 0;
            int menor = 0;

            /* call exported function from "EpsonFiscalInterface.h" */
            ConsultarVersionDll(str, str_len, ref mayor, ref menor);

            /* show */
            string msg = "-Descripción: " + str.ToString() + "  -Mayor: " + mayor.ToString() + "  -Menor: " + menor.ToString();
            //MessageBox.Show(msg);
        }


        /* -----------------------------------------------------------------------------
        Function: print_X_and_Z()
        ----------------------------------------------------------------------------- */
        public void printX()
        {
            int error;

            ConfigurarVelocidad(9600);
            int RESUL = ConfigurarPuerto("0");
            error = Conectar();
            //MessageBox.Show("Connect: " + error.ToString());

            /* print x */
            error = ImprimirCierreX();
        }
        void print_X_and_Z()
        {
            int error;

            /* connect */
            ConfigurarVelocidad(9600);
            int RESUL = ConfigurarPuerto("0");
            error = Conectar();
            //MessageBox.Show("Connect: " + error.ToString());

            /* print x */
            error = ImprimirCierreX();
            //MessageBox.Show("Closure Cashier: " + error.ToString());

            /* print z */
            error = ImprimirCierreZ();
            //MessageBox.Show("Closure Day: " + error.ToString());

            /* clsoe port */
            error = Desconectar();
            //MessageBox.Show("Disconect: " + error.ToString());
        }

    }
}
