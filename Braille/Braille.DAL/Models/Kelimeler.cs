using Braille.DAL.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braille.DAL.Models
{
    [Table("Kelimeler")]
    public class Kelimeler
    {
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KelimeId { get; set; }
        public string Kelime { get; set; }
        [JsonIgnore]
        public virtual ICollection<Skor> Skorlar { get; set; }
       
    }

}
