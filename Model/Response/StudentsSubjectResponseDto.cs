using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Dtos;

namespace Model.Response
{
    public class StudentsSubjectResponseDto
    {
        public List<StudentsSubjectDto> studentsSubject { get; set; } = new List<StudentsSubjectDto>();
    }
}
