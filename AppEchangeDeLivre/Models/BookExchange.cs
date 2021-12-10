using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEchangeDeLivre.Models
{
    public class BookExchange
    {      
        public int? Id { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public int? BookId { get; set; }

        [ForeignKey("OldOwnerId")]
        public User OldOwner { get; set; }
        public int? OldOwnerId{ get; set; }

    }
}
