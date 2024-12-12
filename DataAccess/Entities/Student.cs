using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Dtos;

namespace DataAccess.Entities;

public partial class Student
{
    [Key]
    public decimal Id { get; set; }

    [Column("ssn")]
    [StringLength(10)]
    public string? Ssn { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    public string? FirstName { get; set; }

    [Column("last_name")]
    [StringLength(50)]
    public string? LastName { get; set; }

    [Column("permenant_address")]
    public string? PermenantAddress { get; set; }

    [Column("dob")]
    public DateTime? Dob { get; set; }

    [Column("admission_date")]
    public DateTime? AdmissionDate { get; set; }
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
