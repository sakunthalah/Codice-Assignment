using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Dtos;

namespace DataAccess.Entities;

public partial class Subject : BaseDto
{
    [Key]
    [Column("id")]
    public decimal Id { get; set; }

    [Column("code")]
    [StringLength(10)]
    public string? Code { get; set; }

    [Column("subject_name")]
    [StringLength(50)]
    public string? SubjectName { get; set; }

    [Column("teacher")]
    public decimal? Teacher { get; set; }
    
    public virtual Teacher? TeacherNavigation { get; set; }
}
