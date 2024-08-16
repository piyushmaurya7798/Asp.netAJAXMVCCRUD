using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Asp.netAJAXMVC.Models
{
    public class ProductDAL
    {
        string cf = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
        SqlConnection conn;
        public ProductDAL() { 
        conn=new SqlConnection(cf);
            conn.Open();
        }
        public List<Product> GetAllProducts() 
        {
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec sp_show", conn);
            DataTable dt=new DataTable();
            sqlDataAdapter.Fill(dt);

            List<Product> products = new List<Product>();
            foreach (DataRow dr in dt.Rows)
            {
                products.Add(new Product
                {
                    Id = int.Parse(dr["id"].ToString()),
                    pname = dr["pname"].ToString(),
                    pcat = dr["pcat"].ToString(),
                    price = double.Parse(dr["price"].ToString())


                });
            }
            return products;
        }
        public void AddProduct(Product p) 
        {
            string q = $"exec sp_insert {p.pname},{p.pcat},{p.price}";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
        }
         
        public void DeleteProduct(int id) 
        {
            string q = $"exec sp_delete {id}";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
        }
        
        public void UpdateProduct(Product p) 
        {
            string q = $"exec sp_update {p.Id},{p.pname},{p.pcat},{p.price}";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.ExecuteNonQuery();
        }
    }
}