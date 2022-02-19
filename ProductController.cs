using _210940320091.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _210940320091.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public List<Producthai> show()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=210940320091;Integrated Security=True;";
            cn.Open();

            SqlCommand cmdShow = new SqlCommand();
//            cmdShow.CommandType = System.Data.CommandType.Text;
            cmdShow.CommandType = System.Data.CommandType.StoredProcedure;
  //          cmdShow.CommandText = "Select * from Product_tbl";
            
            cmdShow.CommandText = "Show_Product";
            //cmdShow.Parameters.Add

            SqlDataReader dr = cmdShow.ExecuteReader();

            List<Producthai> li = new List<Producthai>();

            while(dr.Read())
            {
                li.Add(new Producthai
                {
                    ProductId = (int)dr["ProductId"],
                    ProductName = dr["ProductName"].ToString(),
                    Rate = (decimal)dr["Rate"],
                    Description = dr["Description"].ToString(),
                    CategoryName = dr["CategoryName"].ToString()
                });
            }
            dr.Close();
            cn.Close();
            return li;
        }



        // GET: Product/Details/102
        public ActionResult Details(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=210940320091;Integrated Security=True;";
            cn.Open();

            SqlCommand cmdDet = new SqlCommand();
            cmdDet.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDet.CommandText = "Detail_Product";

            SqlDataReader dr = cmdDet.ExecuteReader();
            List<Producthai> li = new List<Producthai>();
            Producthai list = null;

            if(dr.Read())
            {
                list = new Producthai
                {
                    ProductId = (int)dr["ProductId"],
                    ProductName = dr["ProductName"].ToString(),
                    Rate = (decimal)dr["Rate"],
                    Description = dr["Description"].ToString(),
                    CategoryName = dr["CategoryName"].ToString()
                };
                dr.Close();
                cn.Close();
            }

            return View();
        }

        

        // Updatehai: Product/Update
        [HttpPost]
        public void Update(int ProductId,Producthai prod )
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=210940320091;Integrated Security=True";
            cn.Open();

            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.CommandType = System.Data.CommandType.StoredProcedure;
            cmdUpdate.CommandText = "Update_Product";

            cmdUpdate.Parameters.AddWithValue("@ProductId", prod.ProductId);
            cmdUpdate.Parameters.AddWithValue("@ProductName", prod.ProductName);
            cmdUpdate.Parameters.AddWithValue("@Rate", prod.Rate);
            cmdUpdate.Parameters.AddWithValue("@Description", prod.Description);
            cmdUpdate.Parameters.AddWithValue("@CategoryName", prod.CategoryName);

                cmdUpdate.ExecuteNonQuery();
                cn.Close();


        }

       
    }
}
