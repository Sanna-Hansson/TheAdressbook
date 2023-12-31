

using Adressbook.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Adressbook.Services;

public class ContactService
{
    private readonly FileService _fileService;

    public ContactService(string filePath)
    {
        _fileService = new FileService(filePath);
    }

    public ContactService()
    {

    }

    public void SaveContactsToFile(List<ContactModel> contacts)
    {
        string json = JsonConvert.SerializeObject(contacts) ?? "default";
        _fileService.SaveContentToFile(json);
    }

    public List<ContactModel> GetContactsFromFile()
    {
        string json = _fileService.GetContentFromFile();
        if (json != null)
        {
            return JsonConvert.DeserializeObject<List<ContactModel>>(json) ?? new List<ContactModel>();
        }
        return new List<ContactModel>();
    }

    private readonly List<ContactModel> _contacts = new List<ContactModel>();
    public bool AddToList(ContactModel contactModel)
    {
        try 
        {
            _contacts.Add(contactModel);
            return true;
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message );
            return false;
        }
        
        
     

    }
}
