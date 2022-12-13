using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dari.Domain.Entities
{
    public class Rate
    {
        [Key]
        public int RateId { get; set; }
        public int Rating { get; set; }
       public int AnnonceID { get; set; }

    }
}
