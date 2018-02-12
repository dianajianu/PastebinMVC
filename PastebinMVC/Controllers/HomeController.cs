using PastebinMVC.Models;
using PastebinMVC.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PastebinMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PasteModel model = new PasteModel();
            model.SyntaxFormatters = new List<SelectListItem> { new SelectListItem { Text = "C#", Value = "C#" }, new SelectListItem { Text = "Html", Value = "Html" } };

            if (User.Identity.IsAuthenticated)
                model.PreviousPastes = GetPreviousPastes();

            return View(model);
        }

        public IList<PreviousPastesModel> GetPreviousPastes()
        {
            var allText = Facade.GetTexts();

            var model = allText.Select(e => new PreviousPastesModel
            {
                Id = e.Id,
                Content = e.Content
            }).ToList();

            return model;
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Paste(PasteModel model)
        {
            long? id = null;
            if (User.Identity.IsAuthenticated)
            {
                Facade.AddText(model.CurrentPaste, Utils.Session.UserId, out id);
                return RedirectToAction("Paste", new { pasteId = id });
            }

            return PartialView("_RawText", model.CurrentPaste);
        }

        [HttpGet]
        public ActionResult Paste(long pasteId)
        {
            string text = Facade.GetTextById(pasteId).Content;

            return PartialView("_RawText", text);
        }

        public void Delete(long pasteId)
        {
            Facade.RemovePaste(pasteId);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}