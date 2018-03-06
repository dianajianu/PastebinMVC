namespace PastebinMVC.Models
{
    public class PasteModel
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public long? UserId { get; set; }
        public string SyntaxFormatterCode { get; set; }
    }
}