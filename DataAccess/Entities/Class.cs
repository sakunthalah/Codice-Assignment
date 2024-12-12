using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public partial class Class
{
    [Key]
    [Column("id")]
    public decimal Id { get; set; }

    [Column("class_code")]
    public string? ClassCode { get; set; }

    [Column("class_name")]
    public string? ClassName { get; set; }

    [Column("grade")]
    public decimal? Grade { get; set; }

    [Column("teacher_in_charge")]
    public decimal? TeacherInCharge { get; set; }
    public virtual Teacher? TeacherInChargeNavigation { get; set; }
    [Column("active")]
    public bool Active { get; set; }
    [Column("created_by")]
    public string? CreatedBy { get; set; }
    [Column("created_date")]
    public DateTime? CreatedDate { get; set; }
    [Column("modified_by")]
    public string? ModifiedBy { get; set; }
    [Column("modified_date")]
    public DateTime? ModifiedDate { get; set; }
}
