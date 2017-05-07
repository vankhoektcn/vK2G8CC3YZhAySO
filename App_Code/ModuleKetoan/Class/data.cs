using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

   public class data 
	{
        //==============================================================
		public static string dec2bin(object rightid,int max,string def) 
		{
			if (rightid==null||rightid.ToString()=="") return def;
			int num = int.Parse(rightid.ToString());
			string tmp="";
			while (num!=0) 
			{
				int x = num%2;
				tmp = x.ToString()+tmp;
				num = (int)num/2;
			}
			for(int i=tmp.Length;i<max;i++) tmp="0"+tmp; 
			return tmp;
		}
		//==============================================================
		public static string bin2dec(string bin) 
		{
			if (bin=="") return "0";
			int re=0;
			for(int i=0;i<bin.Length;i++) 
			{
				int sub=1;
				if (bin[i]!='0')
					for(int j=0;j<bin.Length-i-1;j++) sub*=2; 
				else sub=0;
				re+=sub;
			}
			return re.ToString();
		}
		//==============================================================
		public static bool checkAt(object pos,object rightid,int max,string def) 
		{
			if (pos==null||pos.ToString()=="") return false;
			if (rightid==null||rightid.ToString()=="") return false;
			string tmp = dec2bin(rightid,max,def);
			int ipos=int.Parse(pos.ToString());
			if (ipos>tmp.Length) return false;
			if (data.compare(tmp[ipos],1)) return true;
			return false;
		}
		/* decrypt password */
		public static string Decrypt(object str) 
		{
			if (str==null) return "";
			string cstr=str.ToString();
			string re="";
			foreach(char c in cstr.ToCharArray()) { char m=(char)(c-10); re+=char.ToString(m); }
			return re;
		}
		/* encrypt password */
		public static string Encrypt(object str) 
		{
			if (str==null) return "";
			string cstr=str.ToString();
			string re="";
			foreach(char c in cstr.ToCharArray()) { char m=(char)(c+10); re+=char.ToString(m); }
			return re;
		}

  		//==============================================================
		public static  SqlConnection getConn() 
		{
            //string strAccessConn = System.Configuration.ConfigurationManager.AppSettings.Get("sqlConectionString");
            //string UID = ConfigurationManager.AppSettings.Get("UID");
            //string PSW = ConfigurationManager.AppSettings.Get("PSW");
            
            //UID = Decrypt(unescape(UID));
            //PSW = Decrypt(unescape(PSW));
            //return new SqlConnection(strAccessConn.Replace("UID", UID).Replace("PSW", PSW));
            //return DataAcess.Connect.Conn;
            return new SqlConnection(DataAcess.Connect.GetConnectionString());

		}

       public static Double GetNumBer(string objnum)
       {
           if (objnum == "") return 0;
           string[] arr = objnum.Split('.');
           string snum = "";
           for (int i = 0; i < arr.Length; i++)
           {
               snum = snum + arr[i];
           }
           return ParseFloat(snum);
       }

		
		//==============================================================
		public static SqlDataReader SQLReader(string sqlString, SqlConnection conn) 
		{
			try
			{
				return new SqlCommand(sqlString, conn).ExecuteReader();
			}
			catch(SqlException ex)
			{
				HttpContext curr=HttpContext.Current;
				curr.Session["querystr"]=sqlString;
				throw(ex);
			}
		}
		//==============================================================
		public static Hashtable SQLHashReader(string sqlString, SqlConnection conn) 
		{
			SqlDataReader reader = SQLReader(sqlString,conn);
			Hashtable hashreader = new Hashtable();
			if(reader.Read())
				for(int i=0;i<reader.FieldCount;i++)
					if(!hashreader.Contains(reader.GetName(i)))
						if(reader[i]==null || reader.IsDBNull(i))
							hashreader.Add(reader.GetName(i),"");	
						else 
							hashreader.Add(reader.GetName(i),reader[i]);
			reader.Close(); 
			return hashreader;
		}
		//==============================================================
		public static ArrayList SQLMultiHashReader(string sqlString, SqlConnection conn) 
		{
			SqlDataReader reader = SQLReader(sqlString,conn);
			ArrayList arrhash =  new ArrayList();
			int fieldcount = reader.FieldCount;
			Hashtable hashreader;
			while (reader.Read()) 
			{
				hashreader = new Hashtable(); 
				for(int i=0;i<fieldcount;i++)
					if(!hashreader.Contains(reader.GetName(i)))
						if(reader.IsDBNull(i) || reader[i]==null || reader[i].ToString()=="")
							hashreader.Add(reader.GetName(i),"");	
						else 
							hashreader.Add(reader.GetName(i),reader[i]);
				arrhash.Add (hashreader);
			}
			reader.Close();
			return arrhash;
		}
		//==============================================================
		public static ArrayList SQLMultiHashReader(string SpName,Hashtable paramaters,SqlConnection conn) 
		{
			SqlCommand command = new SqlCommand();
			command.Connection = conn;
			command.CommandType = CommandType.StoredProcedure;
			command.CommandText = SpName;
			
			foreach(string key in paramaters.Keys) 
			{
				command.Parameters.AddWithValue(key,paramaters[key]); 
			}

			SqlDataReader reader = command.ExecuteReader();
			command.Dispose();
			command=null;
			ArrayList arrhash =  new ArrayList();
			int fieldcount = reader.FieldCount;
			Hashtable hashreader;
			while (reader.Read()) 
			{
				hashreader = new Hashtable(); 
				for(int i=0;i<fieldcount;i++)
					if(!hashreader.Contains(reader.GetName(i)))
						if(reader.IsDBNull(i) || reader[i]==null || reader[i].ToString()=="")
							hashreader.Add(reader.GetName(i),"");	
						else 
							hashreader.Add(reader.GetName(i),reader[i]);
				arrhash.Add (hashreader);
			}
			reader.Close();
			return arrhash;
		}
		//==============================================================
		public static string SQLScalar(string sqlString, SqlConnection conn) 
		{
			try
			{
				object temp = new SqlCommand(sqlString, conn).ExecuteScalar();
				if (temp==null) return "";
				return temp.ToString();
			}
			catch(SqlException ex)
			{
				HttpContext curr = HttpContext.Current;
				curr.Session["querystr"] = sqlString;
				throw(ex);
			}
		}
		//==============================================================
		public static void SQLUpdate(string sqlString, SqlConnection conn) 
		{
			SqlCommand cmd = new SqlCommand(sqlString, conn);
			try
			{
				cmd.ExecuteNonQuery();
			}
			catch(SqlException ex)
			{
				HttpContext curr=HttpContext.Current;
				curr.Session["querystr"]=sqlString;
				throw(ex);
			}
		}
		
		//==============================================================		
		
		public static string formatn(object ob,int decimals)
		{
			//float tmpnumber;
            Double tmpnumber;
			//Int64 tmp2;
            Double tmp2;
			string de,de2="";
			switch(decimals)
			{
                case 4: de = ".0"; break;
                case 1:de="0.0";break;
				case 2:de="0.00";break;
				case 3:de="0.000";break;
				default:de="0.";break;
			}
			try
			{
                tmpnumber=Double.Parse(ob.ToString()); 
				//tmpnumber=float.Parse(ob.ToString()); 
			}
			catch
			{
				tmpnumber=0;
			}
			try
			{
				tmp2=(Double)tmpnumber; 
			}
			catch
			{
				tmp2=0;
			}
			if (tmp2.ToString().Length<=3)
			{
				de2="";
			}
			else if (tmp2.ToString().Length<=6)
			{
				de2="0,00";
			}
			else if (tmp2.ToString().Length<=9)
			{
				de2="0,000,00";
			}
			else if (tmp2.ToString().Length<=12)
			{
				de2="0,000,000,00";
			}
			return tmpnumber.ToString(de2+de);
		}

       
		//==============================================================
		public static string escape(object str)
		{
			if(str!=null)
			{
				string tmp=str.ToString();
				if(tmp!="")
				{
					tmp=tmp.Replace("'","`"); 
					tmp=tmp.Replace("\"","&quot;");
					tmp = tmp.Replace("<","[");
					tmp = tmp.Replace(">","]");
                    tmp = tmp.Replace("--", "");
					return tmp;
				}
				else
					return "";
			}
			else
				return "";
		}
		//==============================================================
		public static string unescape(object str)
		{
			if (str==null) return "";
			string tmp=str.ToString();
			if(tmp!="")
			{
				tmp = tmp.Replace("[","<");
				tmp = tmp.Replace("]",">");
				tmp = tmp.Replace("&quot;","\"");
				return tmp;
			}
			else
				return "";
		}
	
		//==============================================================
		public static string toTitleCase(object str) 
		{
			if (str==null) return string.Empty;
			string re = "";
			string source = str.ToString();
			for(int i=0;i<source.Length;i++)
				if (i==0 || (i>0 && source.Substring(i-1,1)==" ")) re+= source.Substring(i,1).ToUpper(); else re+=source.Substring(i,1).ToLower();
			return re;
		}
		//==============================================================
		public static int ParseInt(object ojb)
		{
			try
			{
				if(ojb==null) return 0;
				return int.Parse(ojb.ToString());
			}
			catch
			{
				return 0;
			}
		}
		//==============================================================
		public static float ParseFloat(object ojb)
		{
			try
			{
				return float.Parse(ojb.ToString());
			}
			catch
			{
				return 0;
			}
		}
		//==============================================================
		public static string ReplaceNewLineBr(object str) 
		{
			if (str==null) return string.Empty;
			return str.ToString().Replace('\r',' ').Replace('\n',' ');
		}
		//==============================================================
		public static string ReplaceNewLineBlank(object str) 
		{
			if (str==null) return string.Empty;
			return str.ToString().Replace((char)13,' ').Replace((char)10,' ');
		}
		//==============================================================
		
		public static string trim(object s) 
		{
			if (s==null || compare(s,"")) return "";
			try
			{
				return s.ToString().Trim();
			}
			catch
			{
				return string.Empty;
			}
		}

       public static Boolean compare(object ob1, object ob2)
       {
           if (ob1 == null || ob2 == null)
               return false;
           else if (ob1.ToString().Trim().ToLower() == ob2.ToString().Trim().ToLower())
               return true;
           return false;
       }

		//==============================================================
		
        public static string MyUnescape(string str)
       {
           str = str.Replace("dd", "đ");
           str = str.Replace("DD", "Đ");
           str = str.Replace("z03", "ạ");
           str = str.Replace("Z03", "Ạ");
           str = str.Replace("z05", "ả");
           str = str.Replace("Z05", "Ả");
           str = str.Replace("z06", "ã");
           str = str.Replace("Z06", "Ã");

           str = str.Replace("z61", "ấ");
           str = str.Replace("Z61", "Ấ");
           str = str.Replace("Z62", "Ầ");
           str = str.Replace("z62", "ầ");
           str = str.Replace("Z65", "Ậ");
           str = str.Replace("z65", "ậ");
           str = str.Replace("Z63", "Ẩ");
           str = str.Replace("z63", "ẩ");
           str = str.Replace("Z64", "Ẫ");
           str = str.Replace("z64", "ẫ");

           str = str.Replace("z80", "ă");
           str = str.Replace("Z80", "Ă");
           str = str.Replace("z81", "ắ");
           str = str.Replace("Z81", "Ắ");
           str = str.Replace("z82", "ằ");
           str = str.Replace("Z82", "Ằ");
           str = str.Replace("Z85", "Ặ");
           str = str.Replace("z85", "ặ");
           str = str.Replace("Z83", "Ẳ");
           str = str.Replace("z83", "ẳ");
           str = str.Replace("Z84", "Ẵ");
           str = str.Replace("z84", "ẵ");

           str = str.Replace("e61", "ế");
           str = str.Replace("E61", "Ế");
           str = str.Replace("e62", "ề");
           str = str.Replace("E62", "Ề");
           str = str.Replace("e63", "ể");
           str = str.Replace("E63", "Ể");
           str = str.Replace("e64", "ễ");
           str = str.Replace("E64", "Ễ");
           str = str.Replace("e65", "ệ");
           str = str.Replace("E65", "Ệ");

           str = str.Replace("o03", "ỏ");
           str = str.Replace("O03", "Ỏ");
           str = str.Replace("o05", "ọ");
           str = str.Replace("O05", "Ọ");
           str = str.Replace("O04", "Õ");

           str = str.Replace("o61", "ố");
           str = str.Replace("O61", "Ố");
           str = str.Replace("o62", "ồ");
           str = str.Replace("O62", "Ồ");
           str = str.Replace("o63", "ổ");
           str = str.Replace("O63", "Ổ");
           str = str.Replace("o64", "ỗ");
           str = str.Replace("O64", "Ỗ");
           str = str.Replace("o65", "ộ");
           str = str.Replace("O65", "Ộ");

           str = str.Replace("o705", "ơ");
           str = str.Replace("O705", "Ơ");
           str = str.Replace("o715", "ớ");
           str = str.Replace("O715", "Ớ");
           str = str.Replace("o725", "ờ");
           str = str.Replace("O725", "Ờ");
           str = str.Replace("o735", "ở");
           str = str.Replace("O735", "Ở");
           str = str.Replace("o745", "ỡ");
           str = str.Replace("O745", "Ỡ");
           str = str.Replace("o755", "ợ");
           str = str.Replace("O755", "Ợ");

           str = str.Replace("u70", "ư");
           str = str.Replace("U70", "Ư");
           str = str.Replace("u71", "ứ");
           str = str.Replace("U71", "Ứ");
           str = str.Replace("u72", "ừ");
           str = str.Replace("U72", "Ừ");
           str = str.Replace("u73", "ử");
           str = str.Replace("U73", "Ử");
           str = str.Replace("u74", "ữ");
           str = str.Replace("U74", "Ữ");
           str = str.Replace("u75", "ự");
           str = str.Replace("U75", "Ự");

           str = str.Replace("e1", "é").Replace("e2", "è");
           str = str.Replace("e5", "ẹ").Replace("e4", "ẽ").Replace("e3", "ẻ");
           str = str.Replace("E5", "Ẹ").Replace("E4", "Ẽ").Replace("E3", "Ẻ");
           str = str.Replace("E1", "É").Replace("E2", "È");

           str = str.Replace("y1","ý").Replace("y2","ỳ");
           str = str.Replace("y5", "ỵ").Replace("y4", "ỹ").Replace("y3", "ỷ");
           str = str.Replace("Y5", "Ỵ").Replace("Y4", "Ỹ").Replace("Y3", "Ỷ");
           str = str.Replace("Y1", "Ý").Replace("Y2", "Ỳ");

           str = str.Replace("e6", "ê").Replace("z60", "â").Replace("o06", "ô");
           str = str.Replace("E6", "Ê").Replace("Z60", "Â").Replace("O06", "Ô");
           str = str.Replace("o02", "ò").Replace("e2", "è").Replace("z02", "à");
           str = str.Replace("O02", "Ò").Replace("E2", "È").Replace("Z02", "À");
           str = str.Replace("o01", "ó").Replace("e1", "é").Replace("z01", "á");
           str = str.Replace("O01", "Ó").Replace("E1", "É").Replace("Z01", "Á");
           str = str.Replace("o04", "õ").Replace("z04", "ã").Replace("O04", "Õ");
           str = str.Replace("Z04", "Ã").Replace("i1","í").Replace("i2","ì");
           str = str.Replace("i5", "ị").Replace("i4", "ĩ").Replace("i3", "ỉ");
           str = str.Replace("I5", "Ị").Replace("I4", "Ĩ").Replace("I3", "Ỉ");
           str = str.Replace("I1", "Í").Replace("I2", "Ì").Replace("--","");
           str = str.Replace("U5", "Ụ").Replace("U4", "Ũ").Replace("U3", "Ủ");
           str = str.Replace("U2", "Ù").Replace("U1", "Ú").Replace("u5", "ụ");
           str = str.Replace("u4", "ũ").Replace("u3", "ủ").Replace("u2", "ù");
           str = str.Replace("u1", "ú");
           return str;
       }     
   }

