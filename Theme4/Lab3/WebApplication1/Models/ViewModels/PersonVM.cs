using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WebApplication1.Models.ViewModels
{
    public class PersonVM
    {
        public System.Guid Id { get; set; }

        [Required]
        [DisplayName("Фамилия")]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        [Required]
        [Range(18, 100)]
        [DisplayName("Полных лет")]
        public int Age { get; set; }

        [DisplayName("Пол")]
        public string Gender { get; set; }

        [Required]
        [DisplayName("Трудоустроен")]
        public bool HasJob { get; set; }
    }
}