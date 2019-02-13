using AutoHamza.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AutoHamza.AccessLayer
{
    public class DAL_Brendet
    {
        public static List<Brendi> GetAllBrendet()
        {
            List<Brendi> brendet = new List<Brendi>();

            using (SqlConnection con = new SqlConnection(ConnectionWithDB.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("usp_GetAllBrands", con);

                con.Open();

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Brendi st = new Brendi();

                    st.BrendiID = int.Parse(sqlDataReader["BrendiID"].ToString());
                    st.Emri = sqlDataReader["Emri"].ToString();
                    st.Foto = sqlDataReader["Foto"].ToString();
                    st.IsActive = bool.Parse(sqlDataReader["IsActive"].ToString());

                    brendet.Add(st);
                }
            }

            return brendet;
        }

        public static Brendi GetBrendByID(int id)
        {
            Brendi brendi = new Brendi();

            using (SqlConnection con = new SqlConnection(ConnectionWithDB.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("usp_GetBrandByID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BrandID", id);

                con.Open();

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                { 
                    brendi.BrendiID = int.Parse(sqlDataReader["BrendiID"].ToString());
                    brendi.Emri = sqlDataReader["Emri"].ToString();
                    brendi.Foto = sqlDataReader["Foto"].ToString();
                    brendi.IsActive = bool.Parse(sqlDataReader["IsActive"].ToString()); 
                }
            }

            return brendi;
        }

        public static void AddBrand(Brendi brendi)
        {
            using (SqlConnection con = new SqlConnection(ConnectionWithDB.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("usp_AddBrand", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();
                cmd.Parameters.AddWithValue("@Emri", brendi.Emri);
                cmd.Parameters.AddWithValue("@Foto", brendi.Foto);

                cmd.ExecuteNonQuery(); 
            }
        }
    }
}