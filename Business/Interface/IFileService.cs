using Business.Models;

namespace Business.Interface;

public interface IFileService
{

    bool SaveContactToList(List<ContactRegForm> list);

    IEnumerable<ContactRegForm> GetContactList();

}
