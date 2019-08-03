using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using CRUDExample.Models;

namespace CRUDExample.Controllers
{
    public class ListController : ApiController
    {
              
        //All List Get        
        [Route("api/list")]  
        public List<myProduct> GetMyList()
        {
            using (WebApiEntities db = new WebApiEntities())
            {
                return db.myProduct.ToList();

            }                   
        }

        //Finded id get list
        [Route("api/list/{p_id:int}")]
        public List<myProduct> GetMyList(int p_id)
        {
            using (WebApiEntities db=new WebApiEntities())
            {
                return db.myProduct.Where(sa => sa.product_id == p_id).ToList();
                
            }
        }


        //post operation
        [Route("api/list/values")]
        public List<myProduct> PostMyProducts(myProduct mp)
        {
            using (var db=new WebApiEntities())
            {
                db.myProduct.Add(mp);
                db.SaveChanges();
                return db.myProduct.ToList();    
            }               
        }

        //update operation
        [Route("api/list/update/{id:int}")]
        public List<myProduct> PutMyProducts(int id,myProduct mp)
        {
            using(var db=new WebApiEntities())
            {
                var finded = db.myProduct.FirstOrDefault(sa => sa.product_id == id);

                finded.product_name = mp.product_name;
                finded.product_cate = mp.product_cate;
                finded.product_price = mp.product_price;
                db.SaveChanges();
                return db.myProduct.ToList();
                
            }
        }

        //delete operation
        [Route("api/list/delete/{id:int}")]
        public List<myProduct> DeleteMyProducts(int id)
        {
            using (var db=new WebApiEntities())
            {
                var finded = db.myProduct.Find(id);
                db.myProduct.Remove(finded);
                db.SaveChanges();
                return db.myProduct.ToList();
            }

        }

        
    }
}
