using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos
{
    public class StudentsSubjectDto
    {
        public decimal Id { get; set; }
        public decimal? StudentId { get; set; }

        public decimal? SubjectId { get; set; }

    }
}
