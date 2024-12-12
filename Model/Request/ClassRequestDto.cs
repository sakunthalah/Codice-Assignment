using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Dtos;

namespace Model.Request
{
    public class ClassRequestDto
    {
        [Required]
        public string ClassCode { get; set; }
        [Required]
        public string ClassName { get; set; }
        [Required]
        public int Grade { get; set; }
        [Required]
        public int TeacherInCharge { get; set; }
    }
}
