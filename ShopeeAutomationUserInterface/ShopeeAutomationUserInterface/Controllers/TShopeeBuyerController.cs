using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopeeAutomationUserInterface.Controllers
{
    public class TShopeeBuyerController : Controller
    {
        // GET: TShopeeBuyer
        public ActionResult Index()
        {
            return View();
        }

        ShopeeAutomationUserInterface.Models.dbJavaSeleniumShopeeBuyer db = new ShopeeAutomationUserInterface.Models.dbJavaSeleniumShopeeBuyer();

        [ValidateInput(false)]
        public ActionResult ShopeeBuyerGridViewPartial()
        {
            var model = db.TShopeeBuyers;
            return PartialView("_ShopeeBuyerGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ShopeeBuyerGridViewPartialAddNew(ShopeeAutomationUserInterface.Models.TShopeeBuyer item)
        {
            var model = db.TShopeeBuyers;
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
            return PartialView("_ShopeeBuyerGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ShopeeBuyerGridViewPartialUpdate(ShopeeAutomationUserInterface.Models.TShopeeBuyer item)
        {
            var model = db.TShopeeBuyers;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.buyer_id == item.buyer_id);
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
            return PartialView("_ShopeeBuyerGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ShopeeBuyerGridViewPartialDelete(System.Int32 buyer_id)
        {
            var model = db.TShopeeBuyers;
            if (buyer_id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.buyer_id == buyer_id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_ShopeeBuyerGridViewPartial", model.ToList());
        }
    }
}