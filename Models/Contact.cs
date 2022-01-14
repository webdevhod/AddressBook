using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [NotMapped]
        public string? FullName { get { return $"{FirstName} {LastName}"; } }
        public string? Address1 { get; set; }        
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [DataType(DataType.PostalCode)]
        public int? ZipCode { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }

        [NotMapped]
        [Display(Name = "Image")]
        [DataType(DataType.Upload)]
        public IFormFile? ImageFile { get; set; }

        public byte[]? ImageData { get; set; }
        [NotMapped]
        public string? ImageType { get; set; }

    }
}
