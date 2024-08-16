using Asp.netAJAXMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Asp.netAJAXMVC.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        ProductDAL pd=new ProductDAL();
        public ActionResult Index()
        {
           var data= pd.GetAllProducts();
            return View(data);
        }

        public ActionResult AddProduct() 
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product p) 
        {
            pd.AddProduct(p);
            TempData["Success"] = "<script>alert('Product Added Successfully')</script>";
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id) 
        {
           pd.DeleteProduct(id);
            TempData["Success"] = "<script>alert('Product Deleted Successfully')</script>";
            return RedirectToAction("Index");
        }
        
        public ActionResult EditProduct(int id) 
        {
          var d= pd.GetAllProducts().Find(x=>x.Id.Equals(id));
            return View(d);
        }
        [HttpPost]
        public ActionResult EditProduct(Product p) 
        {
            pd.UpdateProduct(p);
               TempData["Success"] = "<script>alert('Product Updated Successfully')</script>";
            return RedirectToAction("Index");
        }
    }

}