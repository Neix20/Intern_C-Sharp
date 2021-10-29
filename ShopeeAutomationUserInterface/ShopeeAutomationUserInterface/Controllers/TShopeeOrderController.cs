using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopeeAutomationUserInterface.Controllers
{
    public class TShopeeOrderController : Controller
    {
        // GET: TShopeeOrder
        public ActionResult Index()
        {
            return View();
        }

        ShopeeAutomationUserInterface.Models.dbJavaSeleniumEntity db = new ShopeeAutomationUserInterface.Models.dbJavaSeleniumEntity();

        [ValidateInput(false)]
        public ActionResult ShopeeOrderGridViewPartial()
        {
            var model = db.TShopeeOrders;
            return PartialView("_ShopeeOrderGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ShopeeOrderGridViewPartialAddNew(ShopeeAutomationUserInterface.Models.TShopeeOrder item)
        {
            var model = db.TShopeeOrders;
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
            return PartialView("_ShopeeOrderGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ShopeeOrderGridViewPartialUpdate(ShopeeAutomationUserInterface.Models.TShopeeOrder item)
        {
            var model = db.TShopeeOrders;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.order_id == item.order_id);
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
            return PartialView("_ShopeeOrderGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ShopeeOrderGridViewPartialDelete(System.String order_id)
        {
            var model = db.TShopeeOrders;
            if (order_id != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.order_id == order_id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_ShopeeOrderGridViewPartial", model.ToList());
        }
    }
}