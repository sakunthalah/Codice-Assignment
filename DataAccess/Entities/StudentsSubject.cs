using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public partial class StudentsSubject
{
    [Key]
    [Column("id")]
    public decimal Id { get; set; }

    [Column("student_id")]
    public decimal? StudentId { get; set; }

    [Column("subject_id")]
    public decimal? SubjectId { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Subject? Subject { get; set; }
}
