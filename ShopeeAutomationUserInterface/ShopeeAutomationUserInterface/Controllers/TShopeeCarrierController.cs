using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopeeAutomationUserInterface.Controllers
{
    public class TShopeeCarrierController : Controller
    {
        // GET: TShopeeCarrier
        public ActionResult Index()
        {
            return View();
        }

        ShopeeAutomationUserInterface.Models.dbJavaSeleniumShopeeCarrier db = new ShopeeAutomationUserInterface.Models.dbJavaSeleniumShopeeCarrier();

        [ValidateInput(false)]
        public ActionResult ShopeeCarrierGridViewPartial()
        {
            var model = db.TShopeeCarriers;
            return PartialView("_ShopeeCarrierGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult ShopeeCarrierGridViewPartialAddNew(ShopeeAutomationUserInterface.Models.TShopeeCarrier item)
        {
            var model = db.TShopeeCarriers;
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
            return PartialView("_ShopeeCarrierGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ShopeeCarrierGridViewPartialUpdate(ShopeeAutomationUserInterface.Models.TShopeeCarrier item)
        {
            var model = db.TShopeeCarriers;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.carrier_id == item.carrier_id);
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
            return PartialView("_ShopeeCarrierGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ShopeeCarrierGridViewPartialDelete(System.Int32 carrier_id)
        {
            var model = db.TShopeeCarriers;
            if (carrier_id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.carrier_id == carrier_id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_ShopeeCarrierGridViewPartial", model.ToList());
        }
    }
}