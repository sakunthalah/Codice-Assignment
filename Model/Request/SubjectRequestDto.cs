using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Request
{
    public class SubjectRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string SubjectName { get; set; }
        public decimal? Teacher { get; set; }
    }
}
