using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ListBooks.Models
{
    public class BookModels
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please input Title")]     
        public string Title { get; set; }  
        [Required(ErrorMessage ="Please input Author")]
        [StringLength(50,ErrorMessage ="Author less than 50 characters")]
        public string Author { get; set; }  
        public  int PublicYear { get; set; }    
        public  double Price { get; set; }  
        public string Cover { get; set; }

        public BookModels()
        {
        }

        public BookModels(int id, string title, string author, int publicYear, double price, string cover)
        {
            Id = id;
            Title = title;
            Author = author;
            PublicYear = publicYear;
            Price = price;
            Cover = cover;
        }
    }
}