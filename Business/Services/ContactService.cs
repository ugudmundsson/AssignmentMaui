using Business.Interface;
using Business.Models;

namespace Business.Services;

public class ContactService(IFileService fileService) : IContactService
{

    private readonly IFileService _fileService = fileService;
    private List<ContactRegForm> _contacts = (List<ContactRegForm>)fileService.GetContactList();


    public void CreateContact(ContactRegForm contactRegForm)
    {
        _contacts.Add(contactRegForm);
        _fileService.SaveContactToList(_contacts);
    }





    public IEnumerable<ContactRegForm> GetContacts()
    {
        return _fileService.GetContactList();
    }

}
