using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngularJSMVC.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Gender")]
        public int GenderId { get; set; }

        [Column(TypeName = "DATE"), DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        [Column(TypeName = "MONEY"), DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public virtual Gender Gender { get; set; }
    }
}