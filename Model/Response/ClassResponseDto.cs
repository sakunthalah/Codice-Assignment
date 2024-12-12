using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Dtos;

namespace Model.Response
{
    public class ClassResponseDto : BaseDto
    {
        public int Id { get; set; }
        public string ClassCode { get; set; }
        public string ClassName { get; set; }
        public int Grade { get; set; }
        public int TeacherInCharge { get; set; }

    }
}
