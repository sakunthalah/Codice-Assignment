using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Dtos;

namespace Model.Response
{
    public class StudentResponseDto : BaseDto
    {
        public int Id { get; set; }
        public string Ssn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PermenantAddress { get; set; }
        public DateTime Dob { get; set; }
        public DateTime AdmissionDate { get; set; }

        public ICollection<SubjectDto> Subjects { get; set; } = new List<SubjectDto>();
    }
}
