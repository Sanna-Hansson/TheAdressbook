using Adressbook.Models;
using Adressbook.Services;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        List<ContactModel> contacts = new List<ContactModel>();

        string filePath = @"C:\Education\c-sharp\Adressbook\Adressbook\Services\contacts.json";

        ContactService contactService = new ContactService(filePath);

        // Load existing contacts from the file
        List<ContactModel> Contacts = contactService.GetContactsFromFile();


        MenuService menu = new MenuService();
        bool exit = false;
        do
        {
            menu.ShowMenu(contacts);

            // Save the contacts to the file after each menu operation
            contactService.SaveContactsToFile(contacts);

            // Add a line break for better readability
            Console.WriteLine();

        } while (!exit);

        Console.ReadLine();
    }
}






