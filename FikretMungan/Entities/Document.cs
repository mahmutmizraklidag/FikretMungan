using System.ComponentModel.DataAnnotations;

namespace FikretMungan.Entities
{
    public class Document
    {
        public int Id { get; set; }
        [Display(Name = "Başlık"), Required(ErrorMessage = "Lütfen bir başlık giriniz.")]
        public string Title { get; set; }
        public string? Image { get; set; }
        [Display(Name = "Anasayfada Göster")]
        public bool IsHome { get; set; }
    }
}
