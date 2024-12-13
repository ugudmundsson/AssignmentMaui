using Business.Interface;

namespace Business.Services;

public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;
    

    public FileService(string fileName = "contactlist.json", string directoryPath = "Data")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
    }

    public bool SaveContactToList()
    {
        try
        {
            if (!Directory.Exists(_directoryPath)) {

        }
        catch
        {

           
        }
    }


    public string GetContactList()
    {
        throw new NotImplementedException();
    }


}
