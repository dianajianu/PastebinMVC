using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PastebinMVC.Models
{
    public class GeneralPastesModel
    {
        public IEnumerable<PasteModel> PreviousPastes { get; set; }
        public PasteModel CurrentPaste { get; set; }
        [Display(Name = "Syntax highlighting:  ")]
        public string SyntaxFormatterCode { get; set; }
        public IEnumerable<SelectListItem> SyntaxFormatters { get; set; }
    }
}