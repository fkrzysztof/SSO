using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sasso.Data.Data.Data
{
    public class Offer
    {
        [Key]
        public int OfferID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        //IMG Cloud
        [NotMapped]
        public IFormFile FormFileItem { get; set; }
        public string MediaItem { get; set; }
    }
}
