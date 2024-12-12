using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Dtos;

namespace Model.Response
{
    public class SubjectResponseDto : BaseDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string SubjectName { get; set; }
        public decimal? Teacher { get; set; }
    }
}
