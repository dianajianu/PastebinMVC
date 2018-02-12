using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PastebinMVC.Models
{
    public class PasteModel
    {
        public IEnumerable<PreviousPastesModel> PreviousPastes { get; set; }
        public string CurrentPaste { get; set; }
        [Display(Name = "Syntax highlighting:  ")]
        public string SyntaxFormatterCode { get; set; }
        public IEnumerable<SelectListItem> SyntaxFormatters { get; set; }
    }
}