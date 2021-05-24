namespace API.Models
{
    public class UserAttachment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
    }
}