using Microsoft.VisualBasic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System;
using System.Collections;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Drawing;

	public class clsCheckExist
	{
		
		object objValue;
		string strFieldName;
		string strTableName;
		string strWhereClause;
		object objValueExt1;
		string strFieldNameExt1;
		object objValueExt2;
		string strFieldNameExt2;
		object objValueExt3;
		string strFieldNameExt3;
		object objValueExt4;
		string strFieldNameExt4;
		string strOperator;
		string strOperator1;
		string strOperator2;
		string strOperator3;
		string strOperator4;
		string strFieldOutput;
		public string FieldOutput
		{
			get
			{
				return strFieldOutput;
			}
			set
			{
				strFieldOutput = value;
			}
		}
		public string Operator
		{
			get
			{
				return strOperator;
			}
			set
			{
				strOperator = value;
			}
		}
		public string Operator1
		{
			get
			{
				return strOperator1;
			}
			set
			{
				strOperator1 = value;
			}
		}
		public string Operator2
		{
			get
			{
				return strOperator2;
			}
			set
			{
				strOperator2 = value;
			}
		}
		public string Operator3
		{
			get
			{
				return strOperator3;
			}
			set
			{
				strOperator3 = value;
			}
		}
		public string Operator4
		{
			get
			{
				return strOperator4;
			}
			set
			{
				strOperator4 = value;
			}
		}
		public object Value
		{
			get
			{
				return objValue;
			}
			set
			{
				objValue = value;
			}
		}
		
		public string FieldName
		{
			get
			{
				return strFieldName;
			}
			set
			{
				strFieldName = value;
			}
		}
		
		public string TableName
		{
			get
			{
				return strTableName;
			}
			set
			{
				strTableName = value;
			}
		}
		
		public string WhereClause
		{
			get
			{
				return strWhereClause;
			}
			set
			{
				strWhereClause = value;
			}
		}
		
		public object ValueExt1
		{
			get
			{
				return objValueExt1;
			}
			set
			{
				objValueExt1 = value;
			}
		}
		
		public string FieldNameExt1
		{
			get
			{
				return strFieldNameExt1;
			}
			set
			{
				strFieldNameExt1 = value;
			}
		}
		
		public object ValueExt2
		{
			get
			{
				return objValueExt2;
			}
			set
			{
				objValueExt2 = value;
			}
		}
		
		public string FieldNameExt2
		{
			get
			{
				return strFieldNameExt2;
			}
			set
			{
				strFieldNameExt2 = value;
			}
		}
		
		public object ValueExt3
		{
			get
			{
				return objValueExt3;
			}
			set
			{
				objValueExt3 = value;
			}
		}
		
		public string FieldNameExt3
		{
			get
			{
				return strFieldNameExt3;
			}
			set
			{
				strFieldNameExt3 = value;
			}
		}
		
		public object ValueExt4
		{
			get
			{
				return objValueExt4;
			}
			set
			{
				objValueExt4 = value;
			}
		}
		
		public string FieldNameExt4
		{
			get
			{
				return strFieldNameExt4;
			}
			set
			{
				strFieldNameExt4 = value;
			}
		}
		
		public clsCheckExist()
		{
		}
		
		~clsCheckExist()
		{
			//			base.Finalize();
		}
		
		
		public clsCheckExist(string varTableName, string varFieldName, string varValue, string varWhereClause)
		{
			strTableName = varTableName;
			strFieldName = varFieldName;
			objValue = varValue;
			strWhereClause = varWhereClause;
		}
		
		public clsCheckExist(string varTableName, string varFieldName, string varValue, string varFieldNameExt1, string varValueExt1)
		{
			strTableName = varTableName;
			strFieldName = varFieldName;
			objValue = varValue;
			strFieldNameExt1 = varFieldNameExt1;
			objValueExt1 = varValueExt1;
		}
		
		public clsCheckExist(string varTableName, string varFieldName, string varValue, string varFieldNameExt1, string varValueExt1, string varFieldNameExt2, string varValueExt2)
		{
			strTableName = varTableName;
			strFieldName = varFieldName;
			objValue = varValue;
			strFieldNameExt1 = varFieldNameExt1;
			objValueExt1 = varValueExt1;
			strFieldNameExt2 = varFieldNameExt2;
			objValueExt2 = varValueExt2;
		}
		
		public clsCheckExist(string varTableName, string varFieldName, string varValue, string varFieldNameExt1, string varValueExt1, string varFieldNameExt2, string varValueExt2, string varFieldNameExt3, string varValueExt3)
		{
			strTableName = varTableName;
			strFieldName = varFieldName;
			strFieldNameExt1 = varFieldNameExt1;
			objValueExt1 = varValueExt1;
			strFieldNameExt2 = varFieldNameExt2;
			objValueExt2 = varValueExt2;
			strFieldNameExt3 = varFieldNameExt3;
			objValueExt3 = varValueExt3;
			objValue = varValue;
		}
		
		public clsCheckExist(string varTableName, string varFieldName, string varValue, string varFieldNameExt1, string varValueExt1, string varFieldNameExt2, string varValueExt2, string varFieldNameExt3, string varValueExt3, string varFieldNameExt4, string varValueExt4)
		{
			strTableName = varTableName;
			strFieldName = varFieldName;
			strFieldNameExt1 = varFieldNameExt1;
			objValueExt1 = varValueExt1;
			strFieldNameExt2 = varFieldNameExt2;
			objValueExt2 = varValueExt2;
			strFieldNameExt3 = varFieldNameExt3;
			objValueExt3 = varValueExt3;
			strFieldNameExt4 = varFieldNameExt4;
			objValueExt4 = varValueExt4;
			objValue = varValue;
		}
		
		public bool CheckExist(System.Data.SqlClient.SqlConnection SqlCnn)
		{
			if (SqlCnn.State == ConnectionState.Closed)
			{
				SqlCnn.Open();
			}
			DataTable dt = new DataTable();
			System.Data.SqlClient.SqlDataAdapter SqlAdp = new System.Data.SqlClient.SqlDataAdapter();
			System.Data.SqlClient.SqlTransaction SqlTrans = SqlCnn.BeginTransaction();
			string strSQL;
			SqlAdp.SelectCommand = new System.Data.SqlClient.SqlCommand();
			System.Data.SqlClient.SqlCommand with_1 = SqlAdp.SelectCommand;
			try
			{
				strSQL = "SELECT " + strFieldName + " FROM " + strTableName + " WHERE " + strFieldName + "=@" + strFieldName;
				if (!string.IsNullOrEmpty(strFieldNameExt1))
				{
					strSQL += " AND " + strFieldNameExt1 + "=@" + strFieldNameExt1;
				}
				if (!string.IsNullOrEmpty(strFieldNameExt2))
				{
					strSQL += " AND " + strFieldNameExt2 + "=@" + strFieldNameExt2;
				}
				if (!string.IsNullOrEmpty(strFieldNameExt3))
				{
					strSQL += " AND " + strFieldNameExt3 + "=@" + strFieldNameExt3;
				}
								
				with_1.Connection = SqlCnn;
				with_1.Transaction = SqlTrans;
				with_1.CommandText = strSQL;
				with_1.CommandType = CommandType.Text;
				with_1.Parameters.Add("@" + strFieldName, SqlDbType.NVarChar, 1000).Value = objValue;
				if (!string.IsNullOrEmpty(strFieldNameExt1))
				{
					with_1.Parameters.Add("@" + strFieldNameExt1, SqlDbType.NVarChar, 1000).Value = objValueExt1;
				}
				if (!string.IsNullOrEmpty(strFieldNameExt2))
				{
					with_1.Parameters.Add("@" + strFieldNameExt2, SqlDbType.NVarChar, 1000).Value = objValueExt2;
				}
				if (!string.IsNullOrEmpty(strFieldNameExt3))
				{
					with_1.Parameters.Add("@" + strFieldNameExt3, SqlDbType.NVarChar, 1000).Value = objValueExt3;
				}
//				if (strFieldNameExt4.Trim() != "")
//				{
//					with_1.Parameters.Add("@" + strFieldNameExt4, SqlDbType.NVarChar, 1000).Value = objValueExt4;
//				}
				with_1.Connection = SqlCnn;
				with_1.Transaction = SqlTrans;
				with_1.CommandText = strSQL;
				with_1.CommandType = CommandType.Text;
				SqlAdp.Fill(dt);
				with_1.Transaction.Commit();
			}
			catch (System.Data.SqlClient.SqlException)
			{
				with_1.Transaction.Rollback();
			}
			finally
			{
				with_1.Parameters.Clear();
			}
			if (SqlAdp != null)
			{
				if (SqlAdp.SelectCommand != null)
				{
					SqlAdp.SelectCommand.Dispose();
				}
				if (SqlAdp.InsertCommand != null)
				{
					SqlAdp.InsertCommand.Dispose();
				}
				if (SqlAdp.UpdateCommand != null)
				{
					SqlAdp.UpdateCommand.Dispose();
				}
				if (SqlAdp.DeleteCommand != null)
				{
					SqlAdp.DeleteCommand.Dispose();
				}
				SqlAdp.Dispose();
			}
			if (dt == null)
			{
				return false;
			}
			if (dt != null)
			{
				if (dt.Rows.Count > 0)
				{
					return true;
				}
			}
			return false;
		}
		public void CreateTempTable(string strTable, string strField, object objValue, System.Data.SqlClient.SqlConnection SqlCnn)
		{
			string strBuildSQL;
			strBuildSQL = "SELECT \'" + objValue + "\' AS " + strField + " INTO #" + strTable;
			//Exec(strBuildSQL, SqlCnn)
		}
		public string GetSQLStatement(string strField, string strTable)
		{
			string strSQL;
			strSQL = "SELECT " + strField + " FROM #" + strTable;
			return strSQL;
		}
		public bool CheckInExist(System.Data.SqlClient.SqlConnection SqlCnn)
		{
			if (SqlCnn.State == ConnectionState.Closed)
			{
				SqlCnn.Open();
			}
			DataTable dt = new DataTable();
			System.Data.SqlClient.SqlDataAdapter SqlAdp = new System.Data.SqlClient.SqlDataAdapter();
			System.Data.SqlClient.SqlTransaction SqlTrans = SqlCnn.BeginTransaction();
			string strSQL;
			SqlAdp.SelectCommand = new System.Data.SqlClient.SqlCommand();
			System.Data.SqlClient.SqlCommand with_1 = SqlAdp.SelectCommand;
			try
			{
				strSQL = "SELECT * " + " FROM " + strTableName + " WHERE 1=1 ";
				if (!string.IsNullOrEmpty(strFieldName.Trim()))
				{
					strSQL += " AND CAST(" + strFieldName + " AS NVarchar(8)) IN(@" + strFieldName + ")";
				}
				if (!string.IsNullOrEmpty(strFieldNameExt1.Trim()))
				{
					strSQL += " AND CAST(" + strFieldNameExt1 + " AS NVarchar(8)) IN(@" + strFieldNameExt1 + ")";
				}
				if (!string.IsNullOrEmpty(strFieldNameExt2.Trim()))
				{
					strSQL += " AND CAST(" + strFieldNameExt2 + " AS NVarchar(8))  IN(@" + strFieldNameExt2 + ")";
				}
				if (!string.IsNullOrEmpty(strFieldNameExt3.Trim()))
				{
					CreateTempTable("TempTable3", strFieldNameExt3, objValueExt3, SqlCnn);
					strSQL += " AND CAST(" + strFieldNameExt3 + " AS NVarchar(8))  IN(@" + strFieldNameExt3 + ")";
				}
				
				if (!string.IsNullOrEmpty(strFieldNameExt4.Trim()))
				{
					strSQL += " AND CAST(" + strFieldNameExt4 + " AS NVarchar(8))  IN(@" + strFieldNameExt4 + ")";
				}
				if (!string.IsNullOrEmpty(strWhereClause.Trim()))
				{
					strSQL += " AND " + strWhereClause;
				}
				if (!string.IsNullOrEmpty(strFieldName.Trim()))
				{
					with_1.Parameters.Add("@" + strFieldName, SqlDbType.NVarChar, 1000).Value = objValue; //GetSQLStatement(strFieldName, "TempTable")
				}
				if (!string.IsNullOrEmpty(strFieldNameExt1.Trim()))
				{
					with_1.Parameters.Add("@" + strFieldNameExt1, SqlDbType.NVarChar, 1000).Value = objValueExt1; //GetSQLStatement(strFieldNameExt1, "TempTable1") 'objValueExt1
				}
				if (!string.IsNullOrEmpty(strFieldNameExt2.Trim()))
				{
					with_1.Parameters.Add("@" + strFieldNameExt2, SqlDbType.NVarChar, 1000).Value = objValueExt2; //GetSQLStatement(strFieldNameExt2, "TempTable2") 'objValueExt2
				}
				if (!string.IsNullOrEmpty(strFieldNameExt3.Trim()))
				{
					with_1.Parameters.Add("@" + strFieldNameExt3, SqlDbType.NVarChar, 1000).Value = objValueExt3; //GetSQLStatement(strFieldNameExt3, "TempTable3") 'objValueExt3
				}
				if (!string.IsNullOrEmpty(strFieldNameExt4.Trim()))
				{
					with_1.Parameters.Add("@" + strFieldNameExt4, SqlDbType.NVarChar, 1000).Value = objValueExt4; //GetSQLStatement(strFieldNameExt4, "TempTable4") 'objValueExt4
				}
				with_1.Connection = SqlCnn;
				with_1.Transaction = SqlTrans;
				with_1.CommandText = strSQL;
				with_1.CommandType = CommandType.Text;
				SqlAdp.Fill(dt);
				with_1.Transaction.Commit();
			}
			catch (System.Data.SqlClient.SqlException)
			{
				with_1.Transaction.Rollback();
			}
			finally
			{
				with_1.Parameters.Clear();
			}
			if (SqlAdp != null)
			{
				if (SqlAdp.SelectCommand != null)
				{
					SqlAdp.SelectCommand.Dispose();
				}
				if (SqlAdp.InsertCommand != null)
				{
					SqlAdp.InsertCommand.Dispose();
				}
				if (SqlAdp.UpdateCommand != null)
				{
					SqlAdp.UpdateCommand.Dispose();
				}
				if (SqlAdp.DeleteCommand != null)
				{
					SqlAdp.DeleteCommand.Dispose();
				}
				SqlAdp.Dispose();
			}
			if (dt == null)
			{
				return false;
			}
			if (dt != null)
			{
				if (dt.Rows.Count > 0)
				{
					return true;
				}
			}
			return false;
		}
		
	}
	
	

