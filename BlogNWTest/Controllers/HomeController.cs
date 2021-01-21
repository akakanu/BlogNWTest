using BlogNWTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNWTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public Categorie cat = new Categorie();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            BlogContext context = HttpContext.RequestServices.GetService(typeof(BlogContext)) as BlogContext;
            Blog blog = new Blog();
            if (context != null)
            {

                blog.categories = context.Categories.ToList();
                blog.posts = context.Posts.ToList();
            }
            
            return View(blog);
        }

        public IActionResult Opencat()
        {
            return View("Createcategorie");
        }
        public IActionResult AddCategorie(Categorie categorie)
        {
            BlogContext context = HttpContext.RequestServices.GetService(typeof(BlogContext)) as BlogContext;
            if (context != null)
            {
                context.Add(categorie);
                context.SaveChanges();
                ViewBag.message = "the record " + categorie.Title + " is saved successfully...!";
            }

            return View("Createcategorie");
        }
        [HttpGet]
        public IActionResult EditCategorie(int id)
        {
            BlogContext context = HttpContext.RequestServices.GetService(typeof(BlogContext)) as BlogContext;
            var catego = context.Categories.Where(a => a.CategorieId == id).FirstOrDefault();

            return View("Editcategory", catego);
        }
        [HttpPost]
        public IActionResult EditCategorie(int id, Categorie categorie)
        {
            BlogContext context = HttpContext.RequestServices.GetService(typeof(BlogContext)) as BlogContext;

            bool tracking = context.ChangeTracker.Entries<Categorie>().Any(x => x.Entity.CategorieId == id);
            if (tracking)
            {
                var entry = context.ChangeTracker.Entries<Categorie>().First(x => x.Entity.CategorieId == id).Entity;
                if (entry != null)
                {
                    context.Entry(entry).State = EntityState.Detached;
                }
            }
            
            categorie.CategorieId = id;

            context.Categories.Update(categorie);
            
            context.SaveChanges();
           
                context.Update(categorie);
                context.SaveChanges();

                return RedirectToAction("Index", "Home");           
        }

        public IActionResult OpenPost()
        {

            BlogContext context = HttpContext.RequestServices.GetService(typeof(BlogContext)) as BlogContext;
            Post post = new Post();
            post.Categorie = new Categorie();
            post.categories = context.Categories.ToList();
            
            return View("Createpost", post);
        }

        [HttpPost]
        public IActionResult AddPost(Post post, IFormCollection form)
        {
            var selectedValue1 = post.Categorie;
            string selectedValue = form["Categorie"].ToString();
            
            BlogContext context = HttpContext.RequestServices.GetService(typeof(BlogContext)) as BlogContext;
            if (context != null)
            {
                Categorie ca = new Categorie(selectedValue);
                post.Categorie = ca;
                context.Add(post);
                context.SaveChanges();
                ViewBag.message = "the record " + post.Title + " is saved successfully...!";
            }

            //return View("Createpost");
            return RedirectToAction("OpenPost", "Home");
        }
        [HttpGet]
        public IActionResult EditPost(int id)
        {
            BlogContext context = HttpContext.RequestServices.GetService(typeof(BlogContext)) as BlogContext;
            var po = context.Posts.Where(a => a.PostId == id).FirstOrDefault();
            return View("Editposts", po);
        }
        [HttpPost]
        public IActionResult EditPost(int id, Post post)
        {
            BlogContext context = HttpContext.RequestServices.GetService(typeof(BlogContext)) as BlogContext;

            bool tracking = context.ChangeTracker.Entries<Post>().Any(x => x.Entity.PostId == id);
            if (tracking)
            {
                var entry = context.ChangeTracker.Entries<Post>().First(x => x.Entity.PostId == id).Entity;
                if (entry != null)
                {
                    context.Entry(entry).State = EntityState.Detached;
                }
            }

            post.PostId = id;

            context.Posts.Update(post);
            //Commit the transaction
            context.SaveChanges();

            context.Update(post);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
           // return View("Editposts");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
