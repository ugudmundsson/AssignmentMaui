using Business.Models;

namespace Business.Interface;

public interface IContactService
{
    public void CreateContact(ContactRegForm contactRegForm);

    public IEnumerable<ContactRegForm> GetContacts();

}
