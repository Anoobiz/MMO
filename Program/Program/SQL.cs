using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Program
{
	class SQL
	{
		public static void Change(string sql)
		{
			using (SqlConnection con = new SqlConnection(SQLcon.SQLconnection))
			{
				con.Open();
				SqlCommand cmd = new SqlCommand(sql, con);
				cmd.ExecuteNonQuery();
			}
		}
		public static void SelectAllDataKunde(string sql)
		{
			DataTable table = new DataTable();
			using (SqlConnection con = new SqlConnection(SQLcon.SQLconnection))
			{
				con.Open();
				SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
				adapter.Fill(table);
				if (table.Rows.Count < 1)
				{
					Console.WriteLine("Intet at se her.");
				}
				else
				{
					foreach (DataRow item in table.Rows)
					{
						Console.WriteLine("Kunde ID: " + item["KundeId"].ToString() + ". ");
						Console.WriteLine("Navn: " + item["Navn"].ToString() + " ");
						Console.WriteLine("Efternavn: " + item["EfterNavn"].ToString() + " ");
						Console.WriteLine("Adresse: " + item["Adresse"].ToString() + " ");
						Console.WriteLine("Postnummer: " + item["PostNr"].ToString() + " ");
						Console.WriteLine("Telefonnummer: " + item["Tlf"].ToString() + " ");
						Console.WriteLine("E-Mail adresse: " + item["Email"].ToString() + " ");
						Console.WriteLine("Oprettelses dato: " + item["OpretDato"].ToString() + " ");
						Console.WriteLine();
					}
				}

			}
		}
		public static void SelectFewKunde(string sql)
		{
			DataTable table = new DataTable();
			using (SqlConnection con = new SqlConnection(SQLcon.SQLconnection))
			{
				con.Open();
				SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
				adapter.Fill(table);
				if (table.Rows.Count < 1)
				{
					Console.WriteLine("Intet at se her.");
				}
				else
				{
					foreach (DataRow item in table.Rows)
					{
						Console.Write(item["KundeId"].ToString() + ". ");
						Console.Write(item["Navn"].ToString() + " ");
						Console.Write(item["EfterNavn"].ToString() + " ");
						Console.WriteLine();
					}
				}
			}
		}
		public static void SelectAllDataBil(string sql)
		{
			DataTable table = new DataTable();
			using (SqlConnection con = new SqlConnection(SQLcon.SQLconnection))
			{
				con.Open();
				SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
				adapter.Fill(table);
				if (table.Rows.Count < 1)
				{
					Console.WriteLine("Intet at se her.");
				}
				else
				{
					foreach (DataRow item in table.Rows)
					{
						Console.WriteLine("Bil ID: " + item["BilId"].ToString() + " ");
						Console.WriteLine("Kunde ID: " + item["KundeId"].ToString() + ". ");
						Console.WriteLine("Mærke: " + item["Mærke"].ToString() + " ");
						Console.WriteLine("Model: " + item["Model"].ToString() + " ");
						Console.WriteLine("Årgang: " + item["Årgang"].ToString() + " ");
						Console.WriteLine("Km kørt: " + item["KmKørt"].ToString() + " ");
						Console.WriteLine("Brændstof: " + item["Brændstof"].ToString() + " ");
						Console.WriteLine("Reg Nr: " + item["RegNr"].ToString() + " ");
						Console.WriteLine();
					}
				}
			}
		}
		public static void SelectFewBil(string sql)
		{
			DataTable table = new DataTable();
			using (SqlConnection con = new SqlConnection(SQLcon.SQLconnection))
			{
				con.Open();
				SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
				adapter.Fill(table);
				if (table.Rows.Count < 1)
				{
					Console.WriteLine("Ingen biler registreret.");
				}
				else
				{
					foreach (DataRow item in table.Rows)
					{
						Console.Write("BilID: " + item["BilId"].ToString() + " - ");
						Console.Write("KundeID: " + item["KundeId"].ToString() + " - ");
						Console.Write("Mærke: " + item["Mærke"].ToString() + " - ");
						Console.Write("Model: " + item["Model"].ToString() + " - ");
						Console.Write("Årgang: " + item["Årgang"].ToString() + " - ");
						Console.Write("RegNr: " + item["RegNr"].ToString() + " ");
						Console.WriteLine();
					}
				}
			}
		}
		public static void SelectBesøg(string sql)
		{
			DataTable table = new DataTable();
			using (SqlConnection con = new SqlConnection(SQLcon.SQLconnection))
			{
				con.Open();
				SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
				adapter.Fill(table);
				if (table.Rows.Count < 1)
				{
					Console.WriteLine("Log findes ikke.");
				}
				else
				{
					foreach (DataRow item in table.Rows)
					{
						Console.Write("LogID: " + item["FakturaNr"].ToString() + " - ");
						Console.Write("BilID: " + item["BilId"].ToString() + " - ");
						Console.Write("Dato: " + item["Dato"].ToString() + " - ");
						Console.Write("Udført: " + item["Udført"].ToString());
						Console.WriteLine();
					}
				}
			}
		}
		public static DataTable Liste(string sql)
		{
			DataTable table = new DataTable();
			using (SqlConnection con = new SqlConnection(SQLcon.SQLconnection))
			{
				con.Open();
				SqlDataAdapter adapter = new SqlDataAdapter(sql, con);			
				adapter.Fill(table);
				return table;
			}
		}
	}
}
