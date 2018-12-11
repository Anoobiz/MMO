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
		public static void SelectAllKunde(string sql)
		{
			DataTable table = new DataTable();
			using (SqlConnection con = new SqlConnection(SQLcon.SQLconnection))
			{
				con.Open();
				SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
				adapter.Fill(table);

				foreach (DataRow item in table.Rows)
				{
					Console.Write(item["KundeId"].ToString() + ". ");
					Console.Write(item["Navn"].ToString() + " ");
					Console.Write(item["EfterNavn"].ToString() + " ");
					Console.Write(item["Adresse"].ToString() + " ");
					Console.Write(item["PostNr"].ToString() + " ");
					Console.Write(item["Tlf"].ToString() + " ");
					Console.Write(item["OpretDato"].ToString() + " ");
					Console.Write(item["Email"].ToString() + " ");


					Console.WriteLine();
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

				foreach (DataRow item in table.Rows)
				{
					Console.Write(item["KundeId"].ToString() + ". ");
					Console.Write(item["Navn"].ToString() + " ");
					Console.Write(item["EfterNavn"].ToString() + " ");
					Console.WriteLine();
				}
			}

		}
		public static void SelectBil(string sql)
		{
			DataTable table = new DataTable();
			using (SqlConnection con = new SqlConnection(SQLcon.SQLconnection))
			{
				con.Open();
				SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
				adapter.Fill(table);

				foreach (DataRow item in table.Rows)
				{
					Console.Write(item["KundeId"].ToString() + " ");
					Console.Write(item["BilId"].ToString() + " ");
					Console.Write(item["Mærke"].ToString() + " ");
					Console.Write(item["Model"].ToString() + " ");
					Console.Write(item["Årgang"].ToString() + " ");
					Console.Write(item["KmKørt"].ToString() + " ");
					Console.Write(item["Brændstof"].ToString() + " ");
					Console.Write(item["RegNr"].ToString() + " ");



					Console.WriteLine();
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

				foreach (DataRow item in table.Rows)
				{
					Console.Write(item["KundeId"].ToString() + " ");
					Console.Write(item["BilId"].ToString() + " ");
					Console.Write(item["FakturaNr"].ToString() + " ");
					Console.Write(item["Dato"].ToString() + " ");
					Console.Write(item["Udført"].ToString() + " ");


					Console.WriteLine();
				}
			}

		}

	}
}
