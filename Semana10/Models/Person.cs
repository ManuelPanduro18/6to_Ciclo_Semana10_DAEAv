using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Semana10.Models
{
    public class Person
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Last name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "¿Activo?")]
        public string Activo { get; set; }
        [Required]
        [StringLength(50,ErrorMessage ="No puede ser mas de 50 caracteres")]
        [Column("FirstName")]
        [Display(Name ="First Name")]
        public string FirstMidName { get; set; }
        [Display(Name ="Full Name")]
        public string FullName
        {
            get
            {
                return LastName + "," + FirstMidName;
            }
        }

    }
}