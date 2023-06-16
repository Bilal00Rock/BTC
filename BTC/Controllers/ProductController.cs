using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using BE;
using BLL;
using DAL;
using Microsoft.AspNetCore.Identity;

namespace BTC.Controllers
{
    public class ProductController : Controller
    {
        private UserManager<UserApp> userManager;
        private SignInManager<UserApp> signInManager;
        
        private IWebHostEnvironment Environment;
        public ProductController(IWebHostEnvironment _enviroment, UserManager<UserApp> userManager, SignInManager<UserApp> signInManager)
        {
            Environment = _enviroment;
            this.userManager = userManager;
            this.signInManager = signInManager;
        } 
        public IActionResult Index()
        {
            return View();
        }

        //GET: /Product/Create
        public async Task<IActionResult> Create()
        {
            if (User.Identity.IsAuthenticated)
            {

                return View("Create");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        //POST: /Product/Create
       [HttpPost]
        public async Task<IActionResult> Create(Models.ProductModel product, IFormFile pictureFile)
        {

            if (User.Identity.IsAuthenticated)
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);

                ProductBLL blp = new ProductBLL();
                BE.Product p = new Product();
                p.Name = product.Name;
                p.Description = product.Description;
                p.Address = product.Address;
                p.User = user.Name;
                UploadFile upf = new UploadFile(Environment);
                p.PictureFileName = upf.Upload(product.PictureFileName);
                blp.Create(p);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }

    }
}
