using BlogNWTest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogNWTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Categories : ControllerBase
    {
        // GET: <Categories>/5/Posts
        [HttpGet("{id}/posts")]
        public IEnumerable<Post> GetPosts(int id)
        {

            Categorie current = Get(id);
            return current.posts;
        }

        // GET: api/<Categories>
        [HttpGet]
        public IEnumerable<Categorie> Get()
        {

            BlogContext context = HttpContext.RequestServices.GetService(typeof(BlogContext)) as BlogContext;
            if (context != null)
            {
                return context.Categories.ToList();
            }
            return new Categorie[] { };
        }

        // GET api/<Categories>/5
        [HttpGet("{id}")]
        public Categorie Get(int id)
        {
            BlogContext context = HttpContext.RequestServices.GetService(typeof(BlogContext)) as BlogContext;
            if (context != null)
            {
                return context.Categories.Where(x => x.CategorieId == id).FirstOrDefault();
            }
            return new Categorie();
        }

        // POST api/<Categories>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Categories>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Categories>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
