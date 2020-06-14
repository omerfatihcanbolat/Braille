using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Braille.DAL.Models
{
    [Table("Skorlar")]
    public class Skor
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkorId { get; set; }
        public string Telefon { get; set; }
        public int Sure { get; set; }
        public int KelimeId { get; set; }
        public virtual Kelimeler Kelimeler { get; set; }

    }
}
