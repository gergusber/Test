using System.ComponentModel.DataAnnotations;

namespace TravelPort.Domain.Models
{
    //CRUD to register people with name, surname, DNI and phone. The name, surname and DNI will be mandatory.
    //The pattern must include validation for the DNI, so that if it is entered incorrectly, the form will not be sent.
    public class People 
    {
        [Key]
        public int Id { get; set; }
        [Required, MinLength(3)]

        //[StringLength(10000,ErrorMessage = "Name min Length is 3", MinimumLength = 3)]
        public string Name { get; set; }

        [Required,MinLength(3)]
        //[StringLength(10000,ErrorMessage = "Surname min Length is 3", MinimumLength = 3)]
        public string Surname { get; set; }

        [Required, MinLength(3)]
        //[StringLength(10000,ErrorMessage = "DNI min Length is 3", MinimumLength = 3)]
        public string DNI { get; set; }

     [Phone]   
        public string Phone { get; set; }
    }
}