using System.ComponentModel.DataAnnotations;

namespace TravelPort.Domain.Models
{
    //CRUD to register people with name, surname, DNI and phone. The name, surname and DNI will be mandatory.
    //The pattern must include validation for the DNI, so that if it is entered incorrectly, the form will not be sent.
    public class People 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string DNI { get; set; }

        public string Phone { get; set; }
    }
}