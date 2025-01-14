using CRUDUsingEF_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Configuration;

namespace CRUDUsingEF_Client.Controllers
{
   
    public class CategoryController : Controller
    {
        HttpClient client;
        public CategoryController()
        {
            client = new HttpClient();
            string apiUrl = ConfigurationManager.AppSettings["apiUrl"];
            client.BaseAddress = new Uri(apiUrl);
        }

        // GET: Category
        [HttpGet]
        public ActionResult Index()
        {
            List<Category> categories = new List<Category>();
            //list of category using api

            // api url https://localhost:44399/

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:44399/api/");

           HttpResponseMessage response= client.GetAsync("Category").Result;

            if(response.IsSuccessStatusCode)
            {
                string jsonResult = response.Content.ReadAsStringAsync().Result;
                ViewBag.Response = jsonResult;
                // Deserialization json to c#
                categories = JsonConvert.DeserializeObject<List<Category>>(jsonResult);

            }
            /*client.Dispose();*/// close and dispose connection object
            return View(categories);
        }

        [HttpGet]
        public ActionResult Details(int? id) 
        { 
            Category category = new Category();
            // api call GetById api/1

           category = GetById(id);

            return View(category);

            //return RedirectToAction("Index");
        }

        [NonAction]

        public Category GetById(int? id)
        {
            Category category= new Category();

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:44399/api/");

            HttpResponseMessage response =
                 client.GetAsync($"category/{id}").Result;

            if (response.IsSuccessStatusCode)
            {

                string jsonResult = response.Content.ReadAsStringAsync().Result;

                category = JsonConvert.DeserializeObject<Category>(jsonResult);

                //client.Dispose();
            }

            return category;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            //call post category api
            //HttpClient client = new HttpClient();
            try
         { 
           
            //client.BaseAddress = new Uri("https://localhost:44399/api/");

            string request = JsonConvert.SerializeObject(category);

            StringContent requestBody = new StringContent(request,
                Encoding.UTF8,"application/json");

          HttpResponseMessage response = 
                client.PostAsync("category", requestBody).Result;

            if (response.IsSuccessStatusCode)
            {
                //client.Dispose();

               return RedirectToAction("Index");
            }

                ViewBag.Message = "Create Api Failed";
                return View();
          }
            catch(Exception ex)
            {
               
                ViewBag.Message = ex.Message;
                return View();
            }
            finally
            {
                if(client != null)
                {
                    //client.Dispose();
                }
            }

           
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Category category = new Category();
            category=GetById(id);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            //call post category api
            //HttpClient client = new HttpClient();
            try
            {

                //client.BaseAddress = new Uri("https://localhost:44399/api/");

                string request = JsonConvert.SerializeObject(category);

                StringContent requestBody = new StringContent(request,
                    Encoding.UTF8, "application/json");

                HttpResponseMessage response =
                      client.PutAsync($"category/{category.Id}", requestBody).Result;

                if (response.IsSuccessStatusCode)
                {
                    //client.Dispose();

                    return RedirectToAction("Index");
                }

                ViewBag.Message = "Create Api Failed";
                return View();
            }
            catch (Exception ex)
            {

                ViewBag.Message = ex.Message;
                return View();
            }
            finally
            {
                if (client != null)
                {
                    //client.Dispose();
                }
            }


        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Category category = GetById(id);
            return View(category);

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? Id)
        {
        
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:44399/api/");
           HttpResponseMessage response = 
                client.DeleteAsync($"category/{Id}").Result;

            if (response.IsSuccessStatusCode)
            {
                //client.Dispose();
                return RedirectToAction("Index");
            }
            //client.Dispose();
            Category category = GetById(Id);
            return View(category);

        }


    }
}