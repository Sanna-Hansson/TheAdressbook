using Adressbook.Models;
using Newtonsoft.Json;


namespace Adressbook.Services;

internal class MenuService
{
    
    public void ShowMenu(List<ContactModel> contacts)
    {
       
        // Displaying the menu

        Console.Clear();
        Console.WriteLine(" #  MENU");
        Console.WriteLine(" Choose an option:");
        Console.WriteLine("  1) Add Contact Information");
        Console.WriteLine("  2) Show Contactlist");
        Console.WriteLine("  3) Edit Contact");
        Console.WriteLine("  4) Remove Contact");
        Console.WriteLine("  5) Exit");
        Console.Write("Enter your choice (1-5): ");

        // Getting the user input

        var userInput = Convert.ToInt32(Console.ReadLine());

        // Processing the user input

        string input;
        bool run = true;
        switch (userInput)
        {
            case 1:
                Console.Clear();
                Console.WriteLine("#  ADD A CONTACT");


                while (run)
                {
                    ContactModel newContact = new ContactModel();

                    Console.Write("  1. Write the first name of your contact: ");

                    newContact.ContactFirstName = Console.ReadLine() ?? "Empty";

                    Console.Write("  2. Write the last name of your contact: ");
                    newContact.ContactLastName = Console.ReadLine() ?? "Empty";

                    Console.Write("  3. Write the email of your contact: ");
                    newContact.ContactEmail = Console.ReadLine() ?? "Empty";

                    Console.Write("  4. Write the phonenumber of your contact: ");
                    newContact.ContactPhone = Console.ReadLine() ?? "Empty";

                    Console.Write("  5. Write the adresss of your contact: ");
                    newContact.ContactAddress = Console.ReadLine() ?? "Empty";


                    contacts.Add(newContact);
                   

                  Console.WriteLine("Contact added successfully!");
                  
                    break;
                }
           
                Console.ReadKey();                   
                break;


            case 2:
                Console.Clear();
                Console.WriteLine("#  Showing all contacts");
                //Write a foreach to show the whole list
                foreach (ContactModel contact in contacts)
                {
                   contact.ContactInformation();
                   
                }

                Console.ReadKey();
                break;



            case 3:
                Console.Clear();
                Console.WriteLine("# EDIT CONTACT");
                Console.WriteLine("Enter a unique identifier (e.g., email) for the contact you want to edit:");

                string? identifierToEdit = Console.ReadLine();

                // Find contacts with the specified identifier
                List<ContactModel> matchingContacts = contacts
                    .Where(c => c.ContactEmail == identifierToEdit || c.ContactPhone == identifierToEdit)
                    .ToList();

                if (matchingContacts.Count > 1)
                {
                        // If theres more than one 
                    Console.WriteLine("Multiple contacts found. Please select the contact to edit:");

                    for (int i = 0; i < matchingContacts.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {matchingContacts[i].ContactFirstName} {matchingContacts[i].ContactLastName}");
                    }
                    //changing the contact
                    if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= matchingContacts.Count)
                    {
                        ContactModel contactToEdit = matchingContacts[selectedIndex - 1];
                        Console.WriteLine($"Editing contact: {contactToEdit.ContactFirstName} {contactToEdit.ContactLastName}");

                        Console.Write("Enter the new first name: ");
                        contactToEdit.ContactFirstName = Console.ReadLine() ?? "Empty";

                        Console.Write("Enter the new last name: ");
                        contactToEdit.ContactLastName = Console.ReadLine() ?? "Empty";

                        Console.Write("Enter the new email adress: ");
                        contactToEdit.ContactEmail = Console.ReadLine() ?? "Empty";

                        Console.Write("Enter the new phone number for your contact: ");
                        contactToEdit.ContactPhone = Console.ReadLine() ?? "Empty";

                        Console.Write("Enter the new adress: ");
                        contactToEdit.ContactAddress = Console.ReadLine() ?? "Empty";
                        // Add similar lines for other properties

                        Console.WriteLine("Contact updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. No contact was edited.");
                    }
                }
                else if (matchingContacts.Count == 1)
                {
                    // Only one contact found, proceed with editing
                    ContactModel contactToEdit = matchingContacts[0];
                    Console.WriteLine($"Contact found: {contactToEdit.ContactFirstName} {contactToEdit.ContactLastName}");

                    Console.Write("Enter the new first name: ");
                    contactToEdit.ContactFirstName = Console.ReadLine() ?? "Empty";

                    // Add similar lines for other properties

                    Console.WriteLine("Contact updated successfully!");
                }
                else
                {
                    Console.WriteLine($"No contact found with identifier {identifierToEdit}.");
                }

                Console.ReadKey();
                break;

            case 4:

                Console.Clear();

                Console.WriteLine("#REMOVE CONTACT");
                Console.Write("Write the coresponding email adress of the contact you want to remove :");
                run = true;
                while (run)
                {
                    input = Console.ReadLine() ?? "ingen input";

                    ContactModel? contactToDelete = contacts.FirstOrDefault(c => c.ContactEmail == input);
                    if (contactToDelete != null)
                    {
                        contacts.Remove(contactToDelete);
                        Console.WriteLine($"The Contact with the email {input} is now removed.");
                        run = false;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Adressen hittas inte, försök igen!");
                        Console.ReadKey();
                    }
                }
                
                //visa den kontakt som har epost och fråga om det är rätt kontakt, svara med J/N (normalisera svar)

                break;

            case 5:
                Console.Clear();

                Console.WriteLine("#CLOSING THE PROGRAM");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Do you want to quit ? ( y / n )");

                string? quitInput = Console.ReadLine();
                 

                if(quitInput?.ToLower() =="y") 
                {
                    Console.WriteLine("Exiting the program ...");
                    Environment.Exit(0);
                }
                 break;

            default:
                Console.Clear();

                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                break;
        }

    }
}
