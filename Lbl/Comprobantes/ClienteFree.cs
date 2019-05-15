using Lazaro.Orm;
using Lazaro.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lbl.Comprobantes
{
    [Atributos.Nomenclatura(NombreSingular = "Cliente")]
    [Lbl.Atributos.Datos(TablaDatos = "comprob_cliente", CampoId = "id_comprob")]
    [Entity(TableName = "comprob_cliente", IdFieldName = "id_comprob")]
    public class ClienteFree : ElementoDeDatos
    {
        //Heredar constructor
        public ClienteFree(Lfx.Data.IConnection dataBase)
                        : base(dataBase) { }

        public ClienteFree(Lfx.Data.IConnection dataBase, int itemId)
			: base(dataBase, itemId) { }

        public ClienteFree(Lfx.Data.IConnection dataBase, Lfx.Data.Row row)
                        : base(dataBase, row) { }

        /// <summary>
        /// Obtiene o establece el nombre del elemento.
        /// </summary>
        [Column(Name = "cliente_free", Type = ColumnTypes.VarChar, Length = 150, Nullable = false)]
        public string Nombre {
            get {
                return this.GetFieldValue<string>("cliente_free");
            }
            set {
                this.Registro["cliente_free"] = value;
            }
        }

        public int IdComprob {
            get {
                return this.GetFieldValue<int>("id_comprob");
            }
            set {
                this.Registro["id_comprob"] = value;
            }
        }

        public override Lfx.Types.OperationResult Guardar(Lfx.Data.IConnection conn)
        {
            qGen.IStatement Comando;

            if (this.Existe == false)
            {
                Comando = new qGen.Insert(this.TablaDatos);
                Comando.ColumnValues.AddWithValue(CampoId, IdComprob);
            }
            else
            {
                Comando = new qGen.Update(this.TablaDatos);
                Comando.WhereClause = new qGen.Where(this.CampoId, IdComprob);
            }
            Comando.ColumnValues.AddWithValue("cliente_free", this.Nombre);
            conn.ExecuteNonQuery(Comando);

            return new Lfx.Types.SuccessOperationResult();
        }
    }
}
