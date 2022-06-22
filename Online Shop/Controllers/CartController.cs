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

        public IActionResult Remove(int id)
        {
          
            List<Cart> li = new List<Cart>();

            if (HttpContext.Session.Get<IEnumerable<Cart>>(WC.SessionCart) != null && HttpContext.Session.Get<IEnumerable<Cart>>(WC.SessionCart).Count() > 0)
            {

                li = HttpContext.Session.Get<List<Cart>>(WC.SessionCart);
            }

            li.Remove(li.FirstOrDefault(c => c.Id == id));

            HttpContext.Session.Set(WC.SessionCart, li);

            return RedirectToAction("ShoppingCart");
        }

    }
}
