using BeekeepersBlog_V2.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace BeekeepersBlog_V2.Controllers
{
    [Authorize]
    public class BlogController : Controller
    {
        // GET: Blog
        [AllowAnonymous]
        public ActionResult Index()
        {
            // Read the list
            var blogs = PostManager.Read();
            if (blogs != null)
            {
                // Just for sorting.
                blogs = (from blog in blogs
                         orderby blog.CreateTime descending
                         select blog).ToList();

                ViewBag.Empty = false;
                return View(blogs);
              }
            else
            {
                ViewBag.Empty = true;
                return View();
            }
        }
        [AllowAnonymous]
        [Route("blog/read/{id}")] // Set the ID parameter
        public ActionResult Read(int id)
        {
            if (Request.HttpMethod == "POST")
            {
                if (ApplicationDbContext.Create().Users.Find(User.Identity.GetUserId()) != null)
                {
                    Comment coment = new Comment();
                    coment.comentText = Request.Form["comment"].ToString();

                    var tPost = PostManager.Read().Find(x => x.ID == id);
                    // Read one single blog
                    var user = ApplicationDbContext.Create().Users.Find(User.Identity.GetUserId());
                    coment.User = user;
                    coment.CreateTime = DateTime.Now;
                    if (tPost.Coments == null)
                    { tPost.Coments = new List<Comment>(); }

                    tPost.Coments.Add(coment);

                    PostManager.Update(id, JsonConvert.SerializeObject(tPost));
                    return RedirectToAction("Read", new { id });
                }
                else { return RedirectToAction("Login", "Account"); } 
            }
            else
            {
                var blogs = PostManager.Read();
                BlogPostModel post = null;

                if (blogs != null && blogs.Count > 0)
                {
                    post = blogs.Find(x => x.ID == id);
                }

                if (post == null)
                {
                    ViewBag.PostFound = false;
                    return View();
                }
                else
                {

                    ViewBag.PostFound = true;
                    if (ApplicationDbContext.Create().Users.Find(User.Identity.GetUserId()) != null)
                        ViewBag.Email = ApplicationDbContext.Create().Users.Find(User.Identity.GetUserId()).Email;
                    return View(post);
                }
            }
        }
/*        [HttpPost]
        public ActionResult Read(Comment comment, int id)
        {
            var coment = Request.Form["comment"].ToString();

            var post = PostManager.Read().Find(x => x.ID == id);
            // Read one single blog
            post.Coments.Add(comment);

            PostManager.Update(id, JsonConvert.SerializeObject(post));
            return RedirectToAction("Read");
        }
        */
        public ActionResult Create(HttpPostedFileBase upload)
        {
            if (Request.HttpMethod == "POST")
            {
                // Post request method
                string fileName="";
                if (upload != null)
                {
                    // получаем имя файла
                   fileName = System.IO.Path.GetFileName(upload.FileName);
                    // сохраняем файл в папку Files в проекте
                    upload.SaveAs(Server.MapPath("~/Files/" + fileName));

                }

                var title = Request.Form["title"].ToString();
                var tags = Request.Form["tags"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var content = Request.Form["content"].ToString();


                 // Save content
               
               var user=ApplicationDbContext.Create().Users.Find(User.Identity.GetUserId());
                var post = new BlogPostModel { Title = title, CreateTime = DateTime.Now, Content = content, Tags = tags.ToList(), User = user, Filename = "~/Files/" + fileName
                };
                PostManager.Create(JsonConvert.SerializeObject(post));

                // Redirect
                return RedirectToAction("Index");
            }
            return View();
        }

    /*    [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/Files/" + fileName));
            }
            return RedirectToAction("Create");
        }
        */
        [Route("blog/edit/{id}")]
        public ActionResult Edit(int id)
        {
            if (Request.HttpMethod == "POST")
            {
                // Post request method
                var title = Request.Form["title"].ToString();
                var tags = Request.Form["tags"].ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var content = Request.Form["content"].ToString();
                var tPost = PostManager.Read().Find(x => x.ID == id);

                // Save content
                var post = new BlogPostModel { Title = title, CreateTime = DateTime.Now, Content = content, Tags = tags.ToList(),
                    User = ApplicationDbContext.Create().Users.Find(User.Identity.GetUserId()),Filename=tPost.Filename,Coments=tPost.Coments};
                PostManager.Update(id, JsonConvert.SerializeObject(post));

                // Redirect
                //  Response.Redirect("~/blog");
                return RedirectToAction("Index");
            }
            else
            {
                
                    // Find the required post.
                    var post = PostManager.Read().Find(x => x.ID == id);
                if (post != null )//&& post.User==ApplicationDbContext.Create().Users.Find(User.Identity.GetUserId()))
                {
                        // Set the values
                        ViewBag.Found = true;
                        ViewBag.PostTitle = post.Title;
                        ViewBag.Tags = post.Tags;
                        ViewBag.Content = post.Content;
                    }
                    else
                    {
                        ViewBag.Found = false;
                    }
                
            }

            // Finally return the view.
            return View();
        }
     }
   }
