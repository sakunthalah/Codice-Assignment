using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos
{
    public class StudentDto : BaseDto
    {
        public int Id { get; set; }
        public string Ssn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PermenantAddress { get; set; }
        public DateTime Dob { get; set; }
        public DateTime AdmissionDate { get; set; }

    }
}
