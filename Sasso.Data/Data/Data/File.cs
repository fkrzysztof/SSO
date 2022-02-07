using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sasso.Data.Data.Data
{
    public class File
    {
        [Key]
        public int FileID { get; set; }
        public string Path { get; set; }

        public int? ProjectsID { get; set; }
        [ForeignKey("ProjectsID")]
        public Projects Projects { get; set; }

        [NotMapped]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx|.pdf)$", ErrorMessage = "akceptowalne fomaty to: .doc, .docx, .pdf")]
        public IFormFile FileItem { get; set;} 
    }
}
