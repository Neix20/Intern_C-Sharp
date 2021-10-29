using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopeeAutomationUserInterface.Controllers
{
    public class TShopeeProductController : Controller
    {
        // GET: TShopeeProduct
        public ActionResult Index()
        {
            return View();
        }

        ShopeeAutomationUserInterface.Models.dbJavaSeleniumShopeeProduct db = new ShopeeAutomationUserInterface.Models.dbJavaSeleniumShopeeProduct();

        [ValidateInput(false)]
        public ActionResult ShopeeProductGridViewPartial()
        {
            var model = db.TShopeeProducts;
            return PartialView("_ShopeeProductGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ShopeeProductGridViewPartialAddNew(ShopeeAutomationUserInterface.Models.TShopeeProduct item)
        {
            var model = db.TShopeeProducts;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_ShopeeProductGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ShopeeProductGridViewPartialUpdate(ShopeeAutomationUserInterface.Models.TShopeeProduct item)
        {
            var model = db.TShopeeProducts;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.product_transaction_id == item.product_transaction_id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_ShopeeProductGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ShopeeProductGridViewPartialDelete(System.Int32 product_transaction_id)
        {
            var model = db.TShopeeProducts;
            if (product_transaction_id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.product_transaction_id == product_transaction_id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_ShopeeProductGridViewPartial", model.ToList());
        }
    }
}