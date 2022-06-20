using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Shop.Data;
using Online_Shop.Models;
using static System.Collections.Specialized.BitVector32;
using Microsoft.Extensions.DependencyInjection;
using Online_Shop.Utility;

namespace Online_Shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly OnlineShopContext _context;
        private readonly IWebHostEnvironment _hostEnviroment;
        IHttpContextAccessor HttpContextAccessor;
    

        List<Cart> li = new List<Cart>();

       
        public ProductsController(OnlineShopContext context, IWebHostEnvironment hostEnviroment)
        {
            _context = context;
            _hostEnviroment = hostEnviroment;
          

        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var onlineShopContext = _context.Products.Include(p => p.Category);
            return View(await onlineShopContext.ToListAsync());
        }

        // GET: Products1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }


        // GET: Products1/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id,int qty)
        {
           


            Products products = await _context.Products
            .Include(p => p.Category)
            .SingleOrDefaultAsync(m => m.Id == id);

            Cart c = new Cart();
            c.Id = id;
            c.Title = products.Title;
            c.Image = products.Image;
            c.Discription = products.Discription;
            c.Quantity = qty;
            c.Amount = qty * (int)products.Price;

          

            if (HttpContext.Session.Get<IEnumerable<Cart>>(WC.SessionCart)!=null && HttpContext.Session.Get<IEnumerable<Cart>>(WC.SessionCart).Count() >0)
            {

                li = HttpContext.Session.Get<List<Cart>>(WC.SessionCart);
            }
            li.Add(c);
            HttpContext.Session.Set(WC.SessionCart, li);

            return RedirectToAction("Index");
        }
        //GET: ProductsByCategory/1
        public async Task<IActionResult> ProductsByCategory(int? id)
        {


            var product = await _context.Products
                .Include(p => p.Category)
                .Where(m => m.CategoryId == id).ToListAsync();

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Category");
            return View();
        }

        // POST: Products1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Discription,ImageFile,Price,CategoryId")] Products products)
        {
            if (ModelState.IsValid)
            {
                string wwwwRootPath = _hostEnviroment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(products.ImageFile.FileName);
                string extension = Path.GetExtension(products.ImageFile.FileName);
                products.Image = filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwwRootPath + "/Image/", filename);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await products.ImageFile.CopyToAsync(filestream);
                }
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Category", products.CategoryId);
            return View(products);
        }

        // GET: Products1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Category", products.CategoryId);
            return View(products);
        }

        // POST: Products1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Discription,Image,Price,CategoryId")] Products products)
        {
            if (id != products.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Category", products.CategoryId);
            return View(products);
        }

        // GET: Products1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

       
    }
}
