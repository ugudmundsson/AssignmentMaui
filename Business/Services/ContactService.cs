using Business.Interface;
using Business.Models;

namespace Business.Services;

public class ContactService(IFileService fileService) : IContactService
{

    private readonly IFileService _fileService = fileService;

    /// <summary>
    /// Denna kod string löste ChatGPT
    /// </summary>
    public List<ContactRegForm> _contacts { get; private set; } = (List<ContactRegForm>)fileService.GetContactList().ToList() ?? new List<ContactRegForm>();


    public void CreateContact(ContactRegForm contactRegForm)
    {
        _contacts.Add(contactRegForm);
        _fileService.SaveContactToList(_contacts);
    }





    public IEnumerable<ContactRegForm> GetContacts()
    {
        return _fileService.GetContactList();
    }


    public bool RemoveContactFromList(ContactRegForm contact)
    {
        if (!string.IsNullOrWhiteSpace(contact.FirstName))
        {
            var existingContact = _contacts.FirstOrDefault(x => x.FirstName == contact.FirstName);
            if (existingContact != null)
            {
                _contacts.Remove(existingContact);
                _fileService.SaveContactToList(_contacts);
                return true;
            }
        }

        return false;
    }




}
