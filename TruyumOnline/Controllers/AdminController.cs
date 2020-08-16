using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TruyumOnline.Helper;
using TruyumOnline.Models;

namespace TruyumOnline.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMenuItemDaoSql imenuItemDaoSql;
        public AdminController(IMenuItemDaoSql imenuItemDaoSql)
        {
            this.imenuItemDaoSql = imenuItemDaoSql;
        }
        public IActionResult Index()
        {
            try
            {
                List<Items> itemsList = new List<Items>();
                itemsList = imenuItemDaoSql.GetMenuItemListAdmin().ToList();
                return View(itemsList);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult AddNewItem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewItem(Items items)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    imenuItemDaoSql.AddMenuItemAdmin(items);
                    return RedirectToAction("Index");
                }
               return View(items);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult ModifyMenuItemAdmin(int? id)
        {
            Items item = imenuItemDaoSql.GetMenuItemAdminById(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ModifyMenuItemAdmin(int id,Items items)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    imenuItemDaoSql.ModifyMenuItemAdmin(items);
                    return RedirectToAction("Index");
                }
                return View(items);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult GetMenuItemAdminById(int? id)
        {
            try
            {
                Items item = imenuItemDaoSql.GetMenuItemAdminById(id);
                return View(item);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet]
        public IActionResult DeleteMenuItemAdmin(int? id)
        {
            return View(imenuItemDaoSql.GetMenuItemAdminById(id));
        }
        [HttpPost,ActionName("DeleteMenuItemAdmin")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMenuItemAdmin(int id)
        {
            imenuItemDaoSql.DeleteMenuItemAdmin(id);
            return RedirectToAction("Index");
        }
    }
}