using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Dtos;

namespace Model.Request
{
    public class StudentsSubjectRequestDto
    {
        public List<StudentsSubjectDto> studentsSubject { get; set; } = new List<StudentsSubjectDto>();
    }

    
}
