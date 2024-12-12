using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class StudentsSubject
{
    public decimal? StudentId { get; set; }

    public decimal? SubjectId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Subject? Subject { get; set; }
}
