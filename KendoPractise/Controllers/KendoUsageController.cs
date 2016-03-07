using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KendoPractise.Models;

namespace KendoPractise.Views.Kendo_Usage
{
    public class KendoUsageController : Controller
    {
        private string connString = @"Data Source=SHAMAJIT\SQLEXPRESS;Initial Catalog=AdventureWorks2012;Integrated Security=True";

        // GET: KendoUsage
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProducts(string text)
        {
            var productList = GetProductList();

            if (!string.IsNullOrEmpty(text))
            {
                productList = productList
                                    .Where(p => p.ProductName.IndexOf(text, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            }

            return Json(productList, JsonRequestBehavior.AllowGet);

        }

        public List<ProductModel> GetProductList()
        {
            List<ProductModel> productCollection = new List<ProductModel>();
            string productNumber;

            try
            {

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (var command = new SqlCommand("SELECT ProductNumber , Name FROM Production.Product", conn))
                    {
                        conn.Open();
                        using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                        {

                            while (reader.Read())
                            {
                                productCollection.Add(
                                    new ProductModel
                                    {
                                        ProductId = productNumber = Convert.ToString(reader["ProductNumber"]),
                                        ProductName = productNumber + " - " + Convert.ToString(reader["Name"])
                                    });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return productCollection;
        }
    }
}