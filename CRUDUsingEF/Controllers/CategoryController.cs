using CRUDUsingEF.Models;
using CRUDUsingEF.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CRUDUsingEF.Controllers
{
    public class CategoryController : ApiController
    {
        ProductDbContext _dbContext = new ProductDbContext();

        [HttpGet]
        [ResponseType(typeof(IEnumerable<Category>))]
        public IHttpActionResult GetAll()
        {
            var categories = _dbContext.Categories.ToList();
            return Ok(categories); // 200
        }

        [HttpGet]
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetById([FromUri] int? id)
        {
            if (id > 0)
            {
                Category category = _dbContext.Categories.Find(id);

                if (category != null)
                {
                    return Ok(category); // 200
                }
                else
                {
                    return NotFound(); // 404
                }
            }

            return BadRequest("Category Id should be greater than 0"); // 400
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] Category category)
        {
            if (category != null)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();

                return Created("DefaultApi", category);
            }

            return BadRequest(); // 400
        }

        [HttpPut]
        public IHttpActionResult Update([FromUri] int? id, [FromBody] Category category)
        {
            if (id > 0)
            {
                if (id == category.Id)
                {
                    Category dbCategory = _dbContext.Categories.Find(id);

                    if (dbCategory != null)
                    {
                        dbCategory.Name = category.Name;
                        dbCategory.Rating = category.Rating;

                        _dbContext.SaveChanges();

                        return Ok(); // 200
                    }

                    return NotFound(); // 404
                }

                return BadRequest(); // 400
            }

            return BadRequest(); // 400
        }

        [HttpDelete]
        public IHttpActionResult Delete(int? id)
        {
            if (id > 0)
            {
                Category category = _dbContext.Categories.Find(id);

                if (category != null)
                {
                    _dbContext.Categories.Remove(category);
                    _dbContext.SaveChanges();

                    return Ok(); // 200
                }

                return NotFound(); // 404
            }

            return BadRequest(); // 400
        }
    }
}
