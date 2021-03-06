using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CanvasViews.Models
{
	public class clsVista
	{
		private List<DataTable> ListadtEnlacesTablas;
		private List<clsEnlaceColumna> ListaEnlaceColumnas;
		private string CadenaConexion;
		private string TablaPrincipal;
		private SqlConnection CNX = null;

		#region Constructor
		public clsVista(){
		ListadtEnlacesTablas = new List<DataTable>();
		ListaEnlaceColumnas = new List<clsEnlaceColumna>();
		TablaPrincipal = "proyecto";
		CadenaConexion = @"Server=PACOJ09AW\PACOAWSQL;Initial Catalog=DB_PAAS_SCFAMA;Persist Security Info=False;User ID=sa;Password=sa;MultipleActiveResultSets=False;TrustServerCertificate=False;Connection Timeout=30;";
		cargarVista1();
		cargarVista2();
		cargarVista3();
		}
		#endregion Constructor

		public List<clsEnlaceColumna> getListaEnlaceColumnas()
		{
			return this.ListaEnlaceColumnas;
		}

		public List<DataTable> getListadtEnlacesTablas()
		{
			return this.ListadtEnlacesTablas;
		}

		#region Vista1
		public void cargarVista1(){
		DataTable dt = new DataTable();
		DataColumn column;
		column = new DataColumn();
		column.DataType = Type.GetType("System.String");
		column.ColumnName = "Tabla";
		dt.Columns.Add(column);
		column = new DataColumn();
		column.DataType = Type.GetType("System.String");
		column.ColumnName = "Columna";
		dt.Columns.Add(column);
		column = new DataColumn();
		column.DataType = Type.GetType("System.String");
		column.ColumnName = "Enlace";
		dt.Columns.Add(column);
		DataRow newRow1 = dt.NewRow();
		newRow1["Tabla"] = "proyecto";
		newRow1["Columna"] = "codigo";
		newRow1["Enlace"] = "Posicion X / Label";
		dt.Rows.Add(newRow1);
		DataRow newRow2 = dt.NewRow();
		newRow2["Tabla"] = "proyecto";
		newRow2["Columna"] = "costo_total";
		newRow2["Enlace"] = "Posicion Y";
		dt.Rows.Add(newRow2);
		DataRow newRow3 = dt.NewRow();
		newRow3["Tabla"] = "proyecto";
		newRow3["Columna"] = "descripcion";
		newRow3["Enlace"] = "Index Label";
		dt.Rows.Add(newRow3);
		DataRow newRow4 = dt.NewRow();
		newRow4["Tabla"] = "proyecto";
		newRow4["Columna"] = "estado";
		newRow4["Enlace"] = "Name";
		dt.Rows.Add(newRow4);
		ListadtEnlacesTablas.Add(dt);
		}
		#endregion Vista1

		#region Vista2
		public void cargarVista2(){
		DataTable dt = new DataTable();
		DataColumn column;
		column = new DataColumn();
		column.DataType = Type.GetType("System.String");
		column.ColumnName = "Tabla";
		dt.Columns.Add(column);
		column = new DataColumn();
		column.DataType = Type.GetType("System.String");
		column.ColumnName = "Columna";
		dt.Columns.Add(column);
		column = new DataColumn();
		column.DataType = Type.GetType("System.String");
		column.ColumnName = "Enlace";
		dt.Columns.Add(column);
		DataRow newRow1 = dt.NewRow();
		newRow1["Tabla"] = "tarea";
		newRow1["Columna"] = "codigo";
		newRow1["Enlace"] = "Posicion X / Label";
		dt.Rows.Add(newRow1);
		DataRow newRow2 = dt.NewRow();
		newRow2["Tabla"] = "tarea";
		newRow2["Columna"] = "costo";
		newRow2["Enlace"] = "Posicion Y";
		dt.Rows.Add(newRow2);
		DataRow newRow3 = dt.NewRow();
		newRow3["Tabla"] = "tarea";
		newRow3["Columna"] = "descripcion";
		newRow3["Enlace"] = "Index Label";
		dt.Rows.Add(newRow3);
		ListadtEnlacesTablas.Add(dt);
		}
		#endregion Vista2

		#region Vista3
		public void cargarVista3(){
		DataTable dt = new DataTable();
		DataColumn column;
		column = new DataColumn();
		column.DataType = Type.GetType("System.String");
		column.ColumnName = "Tabla";
		dt.Columns.Add(column);
		column = new DataColumn();
		column.DataType = Type.GetType("System.String");
		column.ColumnName = "Columna";
		dt.Columns.Add(column);
		column = new DataColumn();
		column.DataType = Type.GetType("System.String");
		column.ColumnName = "Enlace";
		dt.Columns.Add(column);
		DataRow newRow1 = dt.NewRow();
		newRow1["Tabla"] = "tarea";
		newRow1["Columna"] = "codigo";
		newRow1["Enlace"] = "Posicion X / Label";
		dt.Rows.Add(newRow1);
		DataRow newRow2 = dt.NewRow();
		newRow2["Tabla"] = "tarea";
		newRow2["Columna"] = "tiempo";
		newRow2["Enlace"] = "Posicion Y";
		dt.Rows.Add(newRow2);
		DataRow newRow3 = dt.NewRow();
		newRow3["Tabla"] = "tarea";
		newRow3["Columna"] = "descripcion";
		newRow3["Enlace"] = "Index Label";
		dt.Rows.Add(newRow3);
		ListadtEnlacesTablas.Add(dt);
		}
		#endregion Vista3

		#region Vista4
		public void cargarVista4(){





		}
		#endregion Vista4

		#region FuncionCargar
		public void cargarListas()
		{
			CNX = new SqlConnection(CadenaConexion);
			if (abrirConexion())
			{
				int contador = 0;
				foreach (DataTable dt in this.ListadtEnlacesTablas)
				{
					List<string> Tablas = new List<string>();
					List<string> Keys = new List<string>();
					foreach (DataRow row in dt.Rows)
					{
						if (Tablas.Count <= 0)
						{
							Tablas.Add(row[0].ToString());
						}
						else
						{
							bool exito = true;
							foreach (string item in Tablas)
							{
								if (item.Equals(row[0].ToString()))
								{
									exito = false;
									break;
								}
							}
							if (exito)
							{
								Tablas.Add(row[0].ToString());
							}
						}
					}

					bool MainTable = false;
					for (int i = 0; i < Tablas.Count; i++)
					{
						if (Tablas.ElementAt(i).Equals(this.TablaPrincipal))
						{
							MainTable = true;
							Keys.Add(getPrimaryKey(Tablas.ElementAt(i)));
						}
						else
						{
							Keys.Add(getForeignKey(Tablas.ElementAt(i)));
						}
					}

					if (Tablas.Count() == 1 && Tablas.ElementAt(0).Equals(this.TablaPrincipal))
					{
						string y = "null";
						string label_x = "null";
						string index_label = "null";
						string name = "null";
						foreach (DataRow row in dt.Rows)
						{
							if (row[2].ToString().Equals("Posicion Y"))
							{
								y = row[1].ToString();
							}
							else if (row[2].ToString().Equals("Posicion X / Label"))
							{
								label_x = row[1].ToString();
							}
							else if (row[2].ToString().Equals("Index Label"))
							{
								index_label = row[1].ToString();
							}
							else if (row[2].ToString().Equals("Name"))
							{
								name = row[1].ToString();
							}
						}

						DataTable dtRows = new DataTable();
						string query = string.Format("select {0} as 'id', {1} as 'Posicion Y', {2} as 'Posicion X / Label', {3} as 'Index Label', {4} as 'Name' from {5};", Keys.FirstOrDefault(), y, label_x, index_label, name, Tablas.FirstOrDefault());
						dtRows = consultar(query);
						clsEnlaceColumna objEnlaceColumna = new clsEnlaceColumna(dtRows, contador, dtRows.Rows.Count);
						contador++;
						this.ListaEnlaceColumnas.Add(objEnlaceColumna);
					}
					else
					{
						List<string> y = new List<string>();
						List<string> label_x = new List<string>();
						List<string> index_label = new List<string>();
						List<string> name = new List<string>();
						foreach (DataRow row in dt.Rows)
						{
							if (row[2].ToString().Equals("Posicion Y"))
							{
								y.Add(row[0].ToString());
								y.Add(row[1].ToString());
							}
							else if (row[2].ToString().Equals("Posicion X / Label"))
							{
								label_x.Add(row[0].ToString());
								label_x.Add(row[1].ToString());
							}
							else if (row[2].ToString().Equals("Index Label"))
							{
								index_label.Add(row[0].ToString());
								index_label.Add(row[1].ToString());
							}
							else if (row[2].ToString().Equals("Name"))
							{
								name.Add(row[0].ToString());
								name.Add(row[1].ToString());
							}
						}

						DataTable dtRows = new DataTable();
						string query = string.Format("select {0} as 'id', {1} as 'Posicion Y', {2} as 'Posicion X / Label', {3} as 'Index Label', {4} as 'Name' from {5};", this.TablaPrincipal + "." + getPrimaryKey(this.TablaPrincipal), getColumnas(y), getColumnas(label_x), getColumnas(index_label), getColumnas(name), getTablas(Tablas, Keys, MainTable));
						dtRows = consultar(query);
						clsEnlaceColumna objEnlaceColumna = new clsEnlaceColumna(dtRows, contador, dtRows.Rows.Count);
						contador++;
						this.ListaEnlaceColumnas.Add(objEnlaceColumna);
					}
				}
				cerrarConexion();
			}
		}
		#endregion FuncionCargar

		private string getTablas(List<string> Tablas, List<string> Keys, bool MainTable)
		{
			string innerJoin = "";
			if (MainTable)
			{
				string PrimaryKey = "";
				int IndexMainTable = 0;
				for (int i = 0; i < Tablas.Count; i++)
				{
					if (Tablas.ElementAt(i).Equals(this.TablaPrincipal))
					{
						IndexMainTable = i;
						break;
					}
				}
				PrimaryKey = Keys.ElementAt(IndexMainTable);
				Tablas.RemoveAt(IndexMainTable);
				Keys.RemoveAt(IndexMainTable);
				innerJoin = this.TablaPrincipal;
				for (int i = 0; i < Tablas.Count; i++)
				{
					innerJoin += string.Format(" inner join {0} on {1}.{2} = {3}.{4}", Tablas.ElementAt(i), this.TablaPrincipal, PrimaryKey, Tablas.ElementAt(i), Keys.ElementAt(i));
				}
			}
			else
			{
				string PrimaryKey = getPrimaryKey(this.TablaPrincipal);
				innerJoin = this.TablaPrincipal;
				for (int i = 0; i < Tablas.Count; i++)
				{
					innerJoin += string.Format(" inner join {0} on {1}.{2} = {3}.{4}", Tablas.ElementAt(i), this.TablaPrincipal, PrimaryKey, Tablas.ElementAt(i), Keys.ElementAt(i));
				}
			}
			return innerJoin;
		}


		private string getColumnas(List<string> Campos)
		{
			string columnas = "null";
			if (Campos.Count > 0)
			{
				columnas = Campos.ElementAt(0) + "." + Campos.ElementAt(1);
			}
			return columnas;
		}

		private string getPrimaryKey(string tabla)
		{
			string primaryKey = "";
			CNX = new SqlConnection(CadenaConexion);
			if (abrirConexion())
			{
				DataTable dt = new DataTable();
				string query = string.Format("SELECT FK_Table = FK.TABLE_NAME, FK_Column = CU.COLUMN_NAME, PK_Table = PK.TABLE_NAME, PK_Column = PT.COLUMN_NAME, Constraint_Name = C.CONSTRAINT_NAME "
					+ "FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK "
					+ "ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME INNER JOIN(SELECT i1.TABLE_NAME, i2.COLUMN_NAME "
					+ "FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1 INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY') PT "
					+ "ON PT.TABLE_NAME = PK.TABLE_NAME where PK.TABLE_NAME = '{0}';", tabla);
				dt = consultar(query);
				if (dt.Rows.Count > 0)
				{
					primaryKey = dt.Rows[0][3].ToString();
				}
				else
				{
					primaryKey = string.Empty;
				}
				cerrarConexion();
			}
			return primaryKey;
		}

		private string getForeignKey(string tabla)
		{
			string foreignKey = "";
			CNX = new SqlConnection(CadenaConexion);
			if (abrirConexion())
			{
				DataTable dt = new DataTable();
				string query = string.Format("SELECT FK_Table = FK.TABLE_NAME, FK_Column = CU.COLUMN_NAME, PK_Table = PK.TABLE_NAME, PK_Column = PT.COLUMN_NAME, Constraint_Name = C.CONSTRAINT_NAME "
					+ "FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK "
					+ "ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME INNER JOIN(SELECT i1.TABLE_NAME, i2.COLUMN_NAME "
					+ "FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1 INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2 ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY') PT "
					+ "ON PT.TABLE_NAME = PK.TABLE_NAME where FK.TABLE_NAME = '{0}' and PK.TABLE_NAME = '{1}';", tabla, this.TablaPrincipal);
				dt = consultar(query);
				if (dt.Rows.Count > 0)
				{
					foreignKey = dt.Rows[0][1].ToString();
				}
				else
				{
					foreignKey = string.Empty;
				}
				cerrarConexion();
			}
			return foreignKey;
		}

		public bool abrirConexion()
		{
			bool Exito = true;
			try
			{
				CNX.Open();
			}
			catch (Exception)
			{
				Exito = false;
			}
			return Exito;
		}

		public bool cerrarConexion()
		{
			bool Exito = true;
			try
			{
				CNX.Close();
			}
			catch (Exception)
			{
				Exito = false;
			}
			return Exito;
		}

		public DataTable consultar(string query)
		{
			DataTable dtResultado = new DataTable();
			try
			{
				SqlCommand Comando = new SqlCommand(query, CNX);
				Comando.CommandType = CommandType.Text;

				SqlDataAdapter Adapter = new SqlDataAdapter(Comando);
				Adapter.Fill(dtResultado);
			}
			catch
			{
				dtResultado = null;
			}
			return dtResultado;
		}

		~clsVista(){
			ListadtEnlacesTablas = null;
			CadenaConexion = string.Empty;
		}
	}
	public class clsEnlaceColumna
	{
		private DataTable dtColumnas;
		private int Vista;
		private int MaxRows;

		public DataTable getdtColumnas()
		{
			return this.dtColumnas;
		}

		public int getVista()
		{
			return this.Vista;
		}

		public int getMaxRows()
		{
			return this.MaxRows;
		}

		public clsEnlaceColumna(DataTable _dtColumnas, int _Vista, int _MaxRows)
		{
			this.dtColumnas = _dtColumnas;
			this.Vista = _Vista;
			this.MaxRows = _MaxRows;
		}
	}
}
