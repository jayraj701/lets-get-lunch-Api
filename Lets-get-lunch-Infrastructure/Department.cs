using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lets_get_lunch_Infrastructure
{
    [Table("Department", Schema = "dbo")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Department Code")]
        public string DepartmentCode { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Department Description")]
        public string DepartmentName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }
    }


    [Table("Designation", Schema = "dbo")]
    public class Designation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DesignationId { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        [Display(Name = "Designation Code")]
        public string DesignationCode { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Designation Name")]
        public string DesignationName { get; set; }

        [ForeignKey("DepartmentInfo")]
        [Required]
        public int DepartmentId { get; set; }

        [NotMapped]
        public string DepartmentName { get; set; }

        public virtual Department DepartmentInfo { get; set; }
    }

}
