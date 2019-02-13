using AutoHamza.Models.Model;
using AutoHamza.Models.ViewModel;
using System;
using System.Collections.Generic; 
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AutoHamza.AccessLayer
{
    public class DAL_Vetura
    {
        public static List<VM_VeturaWithLlojet> GetAllVeturasByBrandID(int id)
        {
            List<VM_VeturaWithLlojet> veturat = new List<VM_VeturaWithLlojet>();

            using (SqlConnection con = new SqlConnection(ConnectionWithDB.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("usp_GetAllVeturaByBrandID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BrendiID", id);

                con.Open();

                SqlDataReader sqlDataReader = cmd.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    VM_VeturaWithLlojet vm = new VM_VeturaWithLlojet();

                    Vetura st = new Vetura();

                    st.VeturaID = int.Parse(sqlDataReader["VeturaID"].ToString());
                    st.Emri = sqlDataReader["Emrivetura"].ToString(); 
                    st.IsActive = bool.Parse(sqlDataReader["IsActive"].ToString());

                    Brendi b = new Brendi();
                    b.BrendiID = int.Parse(sqlDataReader["BrendiID"].ToString());
                    b.Emri = sqlDataReader["Emribrendi"].ToString();

                    st.Brendi = b;

                    List<LlojiVetures> list = new List<LlojiVetures>();
                    list = DAL_LLojetVetures.GetLlojiVeturesByVeturaID(st.VeturaID);

                    vm.Vetura = st;
                    vm.llojetlist = list;

                    veturat.Add(vm);
                }
            }

            return veturat;
        }

        public static void AddVetura(VeturaCreate vetura)
        {
            using (SqlConnection con = new SqlConnection(ConnectionWithDB.GetConnection()))
            {
                SqlCommand cmd = new SqlCommand("usp_AddVetura", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                con.Open();

                cmd.Parameters.AddWithValue("@BrendiID", vetura.BrendiID);
                cmd.Parameters.AddWithValue("@Emri", vetura.Emri);

                cmd.ExecuteNonQuery();
            }
        }
    }
}