namespace PastebinMVC.Models
{
    public class PreviousPastesModel
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public long? UserId { get; set; }
    }
}