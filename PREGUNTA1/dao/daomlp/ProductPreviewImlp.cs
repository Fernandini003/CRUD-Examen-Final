using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PREGUNTA1.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.Ajax.Utilities;

namespace PREGUNTA1.dao.daomlp
{
    public class ProductPreviewImlp : IProductoPreviewDao
    {
        public int operacionesGenerales(string indicador, productPreview c)
        {
            int procesar = -1;
            SqlConnection con = null;
            SqlCommand cmd = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks2022"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("SP_CRUD_PRODUCTPREVIEW", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Indicador", indicador);
                cmd.Parameters.AddWithValue("@ProductReviewID", c.ProductReviewID);
                cmd.Parameters.AddWithValue("@ProductID", c.ProductID);
                cmd.Parameters.AddWithValue("@ReviewerName", c.ReviewerName);
                cmd.Parameters.AddWithValue("@ReviewDate", c.ReviewDate);
                cmd.Parameters.AddWithValue("@EmailAddress", c.EmailAddress);
                cmd.Parameters.AddWithValue("@Rating", c.Rating);
                cmd.Parameters.AddWithValue("@Comments", c.Comments);
                cmd.Parameters.AddWithValue("@ModifiedDate", c.ModifiedDate);
                procesar = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("operacionesGenerales - Error : " + ex.Message);
            }
            finally 
            {
                 con.Close();   
            }
            return procesar;
        }

        public List<productPreview> operacioneslectura(string indicador, int ProductReviewID)
        {
            List<productPreview> List = new List<productPreview>();
            SqlConnection con = null;   
            SqlCommand cmd = null;
            SqlDataReader reader = null;

            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks2022"].ConnectionString);
                con.Open();
                cmd = new SqlCommand("SP_CRUD_PRODUCTPREVIEW", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Indicador", indicador);
                cmd.Parameters.AddWithValue("@ProductReviewID", ProductReviewID);
                cmd.Parameters.AddWithValue("@ProductID", 0);
                cmd.Parameters.AddWithValue("@ReviewerName", "");
                cmd.Parameters.AddWithValue("@ReviewDate", 0);
                cmd.Parameters.AddWithValue("@EmailAddress", "");
                cmd.Parameters.AddWithValue("@Rating", 0);
                cmd.Parameters.AddWithValue("@Comments", "");
                cmd.Parameters.AddWithValue("@ModifiedDate", 0);
                reader = cmd.ExecuteReader();

                productPreview objproductPreview;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objproductPreview = new productPreview()
                        {
                            ProductReviewID = reader.GetInt32(0),
                            ProductID = reader.GetInt32(1),
                            ReviewerName = reader.GetString(2),
                            ReviewDate = reader.GetDateTime(3),
                            EmailAddress = reader.GetString(4),
                            Rating = reader.GetInt32(5),
                            Comments = reader.GetString(6),
                            ModifiedDate = reader.GetDateTime(7),
                        };
                        List.Add(objproductPreview);
                    }
                }
                else
                {
                    Debug.WriteLine("Sin resultados.");
                }

            }

            catch (Exception ex)
            {
                Debug.WriteLine("operacionesLectura - Error: " + ex.Message);
                Debug.WriteLine("StackTrace: " + ex.StackTrace);
            }

            finally
            {
                reader.Close();
                con.Close();
            }
            return List;
        }  
    }
}