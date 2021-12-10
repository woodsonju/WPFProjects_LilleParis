using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEchangeDeLivre.Models
{
    public class Book
    {
        public int? Id { get; set; }  //int? : Ce champ peut accepter des valeurs null

        [Required]
        public string Isbn { get; set; }

        [Required]
        public string Title { get; set; }

        public string Author { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime EditionDate { get; set; }

        [Required]
        public BookState State { get; set; }

        [ForeignKey("OwnerId")]
        public User Owner { get; set; }

        public int? OwnerId { get; set; }

        [NotMapped]
        public int PointsValue 
        { 
            get
            {
                //TODO : Définir une formule avec état, prix
                return Convert.ToInt32(Price);
            } 
        }

    }
}
