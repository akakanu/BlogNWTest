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
    public class Posts : ControllerBase
    {
        // GET: api/<Posts>
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            BlogContext context = HttpContext.RequestServices.GetService(typeof(BlogContext)) as BlogContext;
            if (context != null)
            {
               return context.Posts.ToList();
            }
            return new Post[] {};
        }

        // GET api/<Posts>/5
        [HttpGet("{id}")]
        public Post Get(int id)
        {
            BlogContext context = HttpContext.RequestServices.GetService(typeof(BlogContext)) as BlogContext;
            if (context != null)
            {
                return context.Posts.Where(x=> x.PostId == id).FirstOrDefault();
            }
            return new Post();
        }

        // POST api/<Posts>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Posts>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Posts>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
