using FikretMungan.Entities;

namespace FikretMungan.Models
{
    public class DataRequestModel
    {
        public static List<About> Abouts { get; set; } = new List<About>();
        public static SiteSetting SiteSetting { get; set; } = new SiteSetting();
        public static List<Service> Services { get; set; } = new List<Service>();
        public static List<Blog> Blogs { get; set; } = new List<Blog>();
        public static List<Document> Documents { get; set; } = new List<Document>();

        public static void ClearData()
        {
            Abouts = new List<About>();
            SiteSetting = new SiteSetting();     
            Services = new List<Service>();
            Blogs = new List<Blog>();
            Documents = new List<Document>();
        }
    }
}
