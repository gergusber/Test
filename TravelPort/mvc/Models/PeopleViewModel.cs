using System.ComponentModel.DataAnnotations;

namespace TravelPoint.Client.Models
{
    public class PeopleViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string DNI { get; set; }

        public string Phone { get; set; }
    }
}