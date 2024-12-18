using Business.Factories;
using Business.Interface;
using Business.Services;
using System.ComponentModel;
using System.Net.Quic;

namespace PresentationMainApp.MenuService;

public class MenuService(IContactService contactService) : IMenuService
{

    private readonly IContactService _contactService = contactService;

    bool isOn = true;
    public void MainMenu()
    {

        do
        {
            Console.Clear();
            Console.WriteLine("  *------------- MENY ------------*");
            Console.WriteLine("  | 1. Add Contact:               |");
            Console.WriteLine("  | 2. Show Contactlist:          |");
            Console.WriteLine("  | Q. Exit AppConsole            |");
            Console.WriteLine("  `-------------------------------´");
            Console.WriteLine("");
            Console.Write("Your Choice: ");
            string option = Console.ReadLine()!;
            switch (option.ToLower())
            {
                case "1":
                    CreateContacts();
                    break;
                case "2":
                    ShowContacts();
                    break;
                case "q":
                    CloseMenu();
                    break;
                default:
                    Console.WriteLine("Choose again!");
                    break;
            }
        }
        while (isOn);
    }





    public void CreateContacts()
    {
        var contact = ContactFactory.CreateContact();

        Console.Write("Enter your Firstname:");
        contact.FirstName = Console.ReadLine()!;
        Console.Write("Enter your Lastname: ");
        contact.LastName = Console.ReadLine()!;
        Console.Write("Enter your Email: ");
        contact.Email = Console.ReadLine()!;
        Console.Write("Enter your Phonenumber: ");
        contact.Phone = Console.ReadLine()!;
        Console.Write("Enter your Street: ");
        contact.Street = Console.ReadLine()!;
        Console.Write("Enter your ZipCode: ");
        contact.ZipCode = Console.ReadLine()!;
        Console.Write("Enter your City: ");
        contact.City = Console.ReadLine()!;
        Console.WriteLine("");
       
        _contactService.CreateContact(contact);

        
        Console.WriteLine(" Press 'Enter' for return to menu.");
        Console.ReadKey();

    }









    public void ShowContacts()
    {

        Console.Clear();

        Console.WriteLine("");
        Console.WriteLine("---------- All Contacts -----------");
        Console.WriteLine("");

        var contacts = _contactService.GetContacts();
        if (contacts.Count() == 0)
        {
            Console.WriteLine("No contacts found in list");
            return;
        }
        foreach (var contact in contacts)
        {
            
            Console.WriteLine($"{"Id: ", -20}{contact.Id}");
            Console.WriteLine($"{"Name:",-20}{contact.FirstName}, {contact.LastName}");
            Console.WriteLine($"{"Email:",-20}{contact.Email}");
            Console.WriteLine($"{"Phone:",-20}{contact.Phone}");
            Console.WriteLine($"{"Street:",-20}{contact.Street}");
            Console.WriteLine($"{"ZipCode/City:",-20}{contact.ZipCode}, {contact.City}");
            Console.WriteLine();
        }
        
        Console.WriteLine(" Press 'Enter' for return to menu.");
        Console.ReadKey();

        

    }







    public void CloseMenu()
    {
        Console.WriteLine("You wanna exit contactApp? y/n: ");
        string quitApp = Console.ReadLine()!;
        if (quitApp.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            isOn = false;
        }
    }

   
}
