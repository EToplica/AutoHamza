using AutoHamza.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AutoHamza.AccessLayer
{
    public class DAL_LLojetVetures
    {
        public static List<LlojiVetures> GetLlojiVeturesByVeturaID(int id)
        {
            List<LlojiVetures> llojiVetures = new List<LlojiVetures>();

            using (SqlConnection con = new SqlConnection(ConnectionWithDB.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("usp_GetAllVeturasByVeturaID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VeturaID", id);

                con.Open();

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    LlojiVetures lloji = new LlojiVetures();
                    lloji.LlojiID = int.Parse(sqlDataReader["LlojiID"].ToString());
                    lloji.Emri = sqlDataReader["Emrilloji"].ToString();
                    lloji.Foto = sqlDataReader["Foto"].ToString();
                    lloji.IsActive = bool.Parse(sqlDataReader["IsActive"].ToString()); 

                    Vetura st = new Vetura();

                    st.VeturaID = int.Parse(sqlDataReader["VeturaID"].ToString());
                    st.Emri = sqlDataReader["EmriVetura"].ToString();

                    lloji.Vetura = st;

                    llojiVetures.Add(lloji);
                }
            }

            return llojiVetures;
        }
    }
}