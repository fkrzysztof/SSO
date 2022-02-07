using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sasso.Data.Data.Data
{
    public class Projects
    {
        [Key]
        public int ProjectsID { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name="Aktualności")]
        public string News { get; set; }
        [Display(Name = "O Projekcie")]
        public string About { get; set; }
        [Display(Name = "Uczestnicy")]
        public string Participants { get; set; }
        [Display(Name = "Formy wsparia")]
        public string FormOfSupport { get; set; }
        [Display(Name = "Rekrutacja")]
        public string Recruitment { get; set; }
        [Display(Name = "Kontakt")]
        public string Contact { get; set; }
        [Display(Name = "Data publikacji")]
        public DateTime DateOfPublication { get; set; }
        public DateTime EndProject { get; set; }
        public DateTime StartProject { get; set; }
        //IMG Cloud
        [NotMapped]
        public IFormFile FormFileItem { get; set; }
        public string MediaItem { get; set; }
        public bool Active { get; set; }
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx|.pdf)$", ErrorMessage = "akceptowalne fomaty to: .doc, .docx, .pdf")]
        public ICollection<File> Files { get; set; }


    }
}
