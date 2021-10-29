using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestCRUDWithStoredProcedure.Controllers
{
    public class tmpProductController : Controller
    {
        // GET: tmpProduct
        public ActionResult Index()
        {
            return View();
        }

        TestCRUDWithStoredProcedure.Models.dbTmpEntities1 db = new TestCRUDWithStoredProcedure.Models.dbTmpEntities1();

        [ValidateInput(false)]
        public ActionResult TmpProductGridViewPartial()
        {
            var model = db.tmp_product;
            return PartialView("_TmpProductGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TmpProductGridViewPartialAddNew(TestCRUDWithStoredProcedure.Models.tmp_product item)
        {
            var model = db.tmp_product;
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
            return PartialView("_TmpProductGridViewPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TmpProductGridViewPartialUpdate(TestCRUDWithStoredProcedure.Models.tmp_product item)
        {
            var model = db.tmp_product;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.product_id == item.product_id);
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
            return PartialView("_TmpProductGridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TmpProductGridViewPartialDelete(System.Int32 product_id)
        {
            var model = db.tmp_product;
            if (product_id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.product_id == product_id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_TmpProductGridViewPartial", model.ToList());
        }
    }
}