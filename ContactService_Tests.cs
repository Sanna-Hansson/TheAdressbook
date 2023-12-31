

using Adressbook.Models;

namespace Adressbook.Tests;

public class ContactService_Tests
{
    [Fact]
    public void AddContactToList_ShouldItAdd_ReturnTrue()
    {
        //Arrange
       Adressbook.Models.ContactModel contactModel = new Adressbook.Models.ContactModel { ContactFirstName ="Adam", ContactLastName ="Äppelflod",
                                                       ContactEmail="Adam.Appelflod@domain.se", ContactPhone="040-557568", ContactAddress="Malmö"};

        Adressbook.Services.ContactService contactService = new Services.ContactService();

        //Act

        bool result = contactService.AddToList(contactModel);

        //Assert

        Assert.True(result);
    }

}
