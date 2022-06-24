using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Shop.Data;
using Online_Shop.Models;
using Online_Shop.Utility;
using Online_Shop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Online_Shop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly Online_ShopContext _context;
        public SummeryVm SummeryVm { get; set; }

        public OrdersController(Online_ShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        List<Cart> li = new List<Cart>();
        public IActionResult Summery()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);


            Cart c = new Cart();
           

            if (HttpContext.Session.Get<IEnumerable<Cart>>(WC.SessionCart) != null && HttpContext.Session.Get<IEnumerable<Cart>>(WC.SessionCart).Count() > 0)
            {

                li = HttpContext.Session.Get<List<Cart>>(WC.SessionCart);
            }

            SummeryVm = new SummeryVm()
            {
                Online_ShopUser = _context.Online_ShopUser.FirstOrDefault(u => u.Id == claim.Value),
                CartItems = li
            };
            return View(SummeryVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Summery(string Title, int Quantity, int Amount, string FullName, string PhoneNumber, string Email, string Address)
        {
          
            Orders orders = new Orders();
            orders.Title = Title;
            orders.Quantity = Quantity;
            orders.Amount = Amount;
            orders.Email = Email;
            orders.Address = Address;
            orders.PhoneNumber = PhoneNumber;
            orders.FullName = FullName;
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                li.Clear();
                HttpContext.Session.Set(WC.SessionCart, li);

            }

            return RedirectToAction(nameof(Index));
        }
    }


}
