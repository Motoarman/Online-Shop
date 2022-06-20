using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Shop.Models;
using Online_Shop.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Shop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult ShoppingCart()
        {
            Cart c = new Cart();
            List<Cart> li = new List<Cart>();

            if (HttpContext.Session.Get<IEnumerable<Cart>>(WC.SessionCart) != null && HttpContext.Session.Get<IEnumerable<Cart>>(WC.SessionCart).Count() > 0)
            {

                li = HttpContext.Session.Get<List<Cart>>(WC.SessionCart);
            }


            return View(li);
        }

        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var products = await _context.Products
        //            .Include(p => p.Category)
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (products == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(products);
        //    }

        //    // POST: Products1/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var products = await _context.Products.FindAsync(id);
        //        _context.Products.Remove(products);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool ProductsExists(int id)
        //    {
        //        return _context.Products.Any(e => e.Id == id);
        //    }
        //}
    }
}
