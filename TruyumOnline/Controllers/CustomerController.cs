using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TruyumOnline.Helper;
using TruyumOnline.Models;

namespace TruyumOnline.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerDataAccessLayer customerDataAccessLayer;
        public CustomerController(ICustomerDataAccessLayer customerDataAccessLayer)
        {
            this.customerDataAccessLayer = customerDataAccessLayer;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetAllActiveItems()
        {
            try
            {
                List<Items> itemsList = new List<Items>();
                itemsList = customerDataAccessLayer.GetAllActiveItems().ToList();
                return View(itemsList);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult Cart(int? id)
        {
            try
            {
                Items item = customerDataAccessLayer.GetMenuItemAdminById(id);
                customerDataAccessLayer.AddToCart(item);
                return View(item);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAllCartItems()
        {
            try
            {
                return View(customerDataAccessLayer.GetAllCartItems());
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult DeleteCartItem(int? id)
        {
            return View(customerDataAccessLayer.GetCartItem(id));
        }
        [HttpPost, ActionName("DeleteCartItem")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCartItem(int id)
        {
            customerDataAccessLayer.DeleteCartItem(id);
            return RedirectToAction("GetAllCartItems");
        }
    }
}