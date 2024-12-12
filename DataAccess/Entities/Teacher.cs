using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public partial class Teacher
{
    [Key]
    public decimal Id { get; set; }

    [Column("teacher-name")]
    public string? TeacherName { get; set; }
    [Column("active")]
    public bool Active { get; set; }

    [Column("created_by")]
    public string CreatedBy { get; set; }
    [Column("created_date")]
    public DateTime CreatedDate { get; set; }
    [Column("modified_by")]
    public string ModifiedBy { get; set; }
    [Column("modified_date")]
    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();
}
