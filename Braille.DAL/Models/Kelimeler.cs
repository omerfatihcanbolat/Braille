
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Braille.DAL.Models
{
    [Table("Kelimeler")]
    public class Kelimeler
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KelimeId { get; set; }
        public string Kelime { get; set; }


        public virtual List<Skor> Skorlar { get; set; }

       
    }


}
