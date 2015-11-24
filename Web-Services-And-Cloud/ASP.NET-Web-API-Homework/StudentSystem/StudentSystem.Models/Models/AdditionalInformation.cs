namespace StudentSystem.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class AdditionalInformation
    {
        public AdditionalInformation()
        {
        }

        public AdditionalInformation(string email, string address)
        {
            this.Email = email;
            this.Address = address;
        }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Address")]
        public string Address { get; set; }
    }
}