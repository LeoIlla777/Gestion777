using System;
using System.Collections.Generic;
using System.Text;

namespace Lbl.Sys.Permisos
{
    public class ListaDePermisos : Lbl.ColeccionGenerica<Permiso>
    {
        public Lbl.Personas.Usuario Usuario = null;

        public ListaDePermisos(Lbl.Personas.Usuario usuario)
                : base(usuario.Connection) { }

        public ListaDePermisos(Lbl.Personas.Usuario usuario, System.Data.DataTable tabla)
                : base(usuario.Connection, tabla)
        {
            this.Usuario = usuario;
            foreach (Permiso Perm in this) {
                Perm.Usuario = usuario;
            }
        }

        public bool TieneAccesoGlobal()
        {
            foreach (Permiso Acc in this) {
                if (Acc.Objeto.Tipo == "Global" && (Acc.Operaciones & Operaciones.Total) == Operaciones.Total) {
                    return true;
                }
            }
            return false;
        }

        public bool TienePermiso(string tipo, Operaciones operacion)
        {
            if (this.TieneAccesoGlobal())
                return true;

            foreach (Permiso Perm in this) {
                if (Perm.Objeto.Tipo == tipo &&
                        ((Perm.Operaciones & operacion) == operacion || (Perm.Operaciones & Operaciones.Total) == Operaciones.Total)) {
                    return true;
                }
            }

            return false;
        }

        public bool TienePermiso(IElementoDeDatos elemento, Operaciones operacion)
        {
            if (this.TieneAccesoGlobal())
                return true;


            string TipoElemento = elemento.GetType().ToString();
            foreach (Permiso Perm in this) {
                if (Perm.Objeto.Tipo == TipoElemento &&
                        ((Perm.Operaciones & operacion) == operacion || (Perm.Operaciones & Operaciones.Total) == Operaciones.Total) &&
                        (Perm.Item == null || Perm.Item.Contains(elemento.Id))) {
                    return true;
                }
            }

            return TienePermiso(elemento.GetType().BaseType, operacion);
        }

        public bool TienePermiso(Type tipo, Operaciones operacion)
        {
            if (this.TieneAccesoGlobal())
                return true;

            if (tipo == null)
                return false;

            string TipoElemento = tipo.ToString();
            foreach (Permiso Perm in this) {
                if (Perm.Objeto.Tipo == TipoElemento &&
                        ((Perm.Operaciones & operacion) == operacion || (Perm.Operaciones & Operaciones.Total) == Operaciones.Total)) {
                    return true;
                }
            }

            if (tipo != typeof(Lbl.ElementoDeDatos) && tipo != typeof(System.Object))
                return TienePermiso(tipo.BaseType, operacion);
            else
                return false;
        }

        public bool TienePermisoxItem(Type tipo, Operaciones operacion, ListaIds items)
        {
            if (this.TieneAccesoGlobal())
                return true;

            if (tipo == null)
                return false;

            string TipoElemento = tipo.ToString();
            foreach (Permiso Perm in this)
            {
                if (Perm.Objeto.Tipo == TipoElemento &&
                        ((Perm.Operaciones & operacion) == operacion || (Perm.Operaciones & Operaciones.Total) == Operaciones.Total)
                        && (Perm.Item == null || Perm.Item == items || (Perm.Operaciones & Operaciones.Total) == Operaciones.Total))
                {
                    return true;
                }
            }

            if (tipo != typeof(Lbl.ElementoDeDatos) && tipo != typeof(System.Object))
                return TienePermisoxItem(tipo.BaseType, operacion, items);
            else
                return false;
        }

        public bool TienePermisoxItem(IElementoDeDatos elemento, Operaciones operacion, ListaIds items)
        {
            if (this.TieneAccesoGlobal())
                return true;


            string TipoElemento = elemento.GetType().ToString();
            foreach (Permiso Perm in this)
            {
                if (Perm.Objeto.Tipo == TipoElemento &&
                        ((Perm.Operaciones & operacion) == operacion || (Perm.Operaciones & Operaciones.Total) == Operaciones.Total) &&
                        (Perm.Item == null || Perm.Item.Contains(elemento.Id) || (Perm.Operaciones & Operaciones.Total) == Operaciones.Total))
                {
                    return true;
                }
            }

            return TienePermisoxItem(elemento.GetType().BaseType, operacion, items);
        }

        public bool TienePermisoxItem(string tipo, Operaciones operacion, ListaIds items)
        {
            if (this.TieneAccesoGlobal())
                return true;

            foreach (Permiso Perm in this)
            {
                if (Perm.Objeto.Tipo == tipo &&
                        ((Perm.Operaciones & operacion) == operacion || (Perm.Operaciones & Operaciones.Total) == Operaciones.Total)
                        && (Perm.Item == null || Perm.Item == items || (Perm.Operaciones & Operaciones.Total) == Operaciones.Total))
                {
                    return true;
                }
            }

            return false;
        }

        public ListaIds GetItemsxTipo(string tipo)
        {
            ListaIds items = new ListaIds();
            foreach (Permiso Perm in this)
            {
                if (Perm.Objeto.Tipo == tipo && Perm.Item != null && Perm.Item.Count>0)
                {
                    for (int i = 0; i < Perm.Item.Count;i++)
                        items.Add(Perm.Item[i]);
                }
            }
            return items;
        }

        public ListaIds GetItemsxTipo(IElementoDeDatos elemento)
        {
            ListaIds items = new ListaIds();
            string TipoElemento = elemento.GetType().ToString();
            foreach (Permiso Perm in this)
            {
                if (Perm.Objeto.Tipo == TipoElemento && Perm.Item != null && Perm.Item.Count > 0)
                {
                    for (int i = 0; i < Perm.Item.Count; i++)
                        items.Add(Perm.Item[i]);
                }
            }
            return items;
        }

        public ListaIds GetItemsxTipo(Type tipo)
        {
            ListaIds items = new ListaIds();
            string TipoElemento = tipo.ToString();
            foreach (Permiso Perm in this)
            {
                if (Perm.Objeto.Tipo == TipoElemento && Perm.Item != null && Perm.Item.Count > 0)
                {
                    for (int i = 0; i < Perm.Item.Count; i++)
                        items.Add(Perm.Item[i]);
                }
            }
            return items;
        }
    }
}
