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
            GeneralPastesModel model = new GeneralPastesModel();
            model.SyntaxFormatters = new List<SelectListItem> { new SelectListItem { Text = "C#", Value = "language-csharp" }, new SelectListItem { Text = "Html", Value = "language-html" }, new SelectListItem { Text = "Css", Value = "language-css" } };

            if (User.Identity.IsAuthenticated)
                model.PreviousPastes = GetPreviousPastes();

            return View(model);
        }

        public IList<PasteModel> GetPreviousPastes()
        {
            var allText = Facade.GetTexts();

                var model = allText.Select(e => new PasteModel
                {
                    Id = e.Id,
                    Content = (e.Content?.Length >= 20) ? e.Content.Substring(0, 20) : e.Content
                }).ToList();

            return model;
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Paste(PasteModel model)
        {
            long id;
            long? syntaxFormatterId = Facade.GetSyntaxFormatterByCode(model.SyntaxFormatterCode)?.Id;
            if (User.Identity.IsAuthenticated)
            {
                Facade.AddText(model.Content, Utils.Session.UserId, syntaxFormatterId, out id);
                model.Id = id;
                return RedirectToAction("PasteDetails", new { pasteId  = id });
            }

            return PartialView("_RawText", model);
        }

        [HttpGet]
        public ActionResult PasteDetails(long pasteId)
        {
            var paste = Facade.GetTextById(pasteId);
            long? syntaxFormatterId = paste.SyntaxFormatterId;

            PasteModel model = new PasteModel
            {
                Id = paste.Id,
                Content = paste.Content,
                SyntaxFormatterCode = (syntaxFormatterId != null) ? Facade.GetSyntaxFormatterById((long)paste.SyntaxFormatterId)?.FormatterCode : string.Empty
            };

            return PartialView("_RawText", model);
        }

        [HttpGet]
        public ActionResult Delete(long pasteId)
        {
            Facade.RemovePaste(pasteId);
            return RedirectToAction("Index");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}