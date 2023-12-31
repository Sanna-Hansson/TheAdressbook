

namespace Adressbook.Models
{
    public class ContactModel
    {
        public string ContactFirstName { get; set; } = null!;
        public string ContactLastName { get; set; } = null!;
        public string ContactEmail { get; set; } = null!;
        public string ContactPhone { get; set; } = null!;
        public string ContactAddress { get; set; } = null!;
        

        public void ContactInformation() 
        {
            Console.WriteLine($"Surname: {ContactFirstName}");
            Console.WriteLine($"Lastname {ContactLastName}");
            Console.WriteLine($"Email: {ContactEmail}");
            Console.WriteLine($"Phone: {ContactPhone}");
            Console.WriteLine($"Adress: {ContactAddress}");
            Console.WriteLine("-------------------------------------------");

        }

    }
}
