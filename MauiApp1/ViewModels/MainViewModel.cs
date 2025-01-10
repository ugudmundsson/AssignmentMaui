using Business.Factories;
using Business.Interface;
using Business.Models;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Pages;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModels;

public partial class MainViewModel : ObservableObject

{
    private readonly IContactService _contactService;

    [ObservableProperty]
    private ContactRegForm _registrationForm;


    public MainViewModel(IContactService contactService)
    {
        _contactService = contactService;
        UpdateContact();
        _registrationForm = ContactFactory.CreateContact();
        
    }




    [ObservableProperty]
    private ObservableCollection<ContactRegForm> _contactList = [];



    [RelayCommand]
    public void CreateContact()
    {
        if (RegistrationForm != null && !string.IsNullOrWhiteSpace(RegistrationForm.FirstName))
        {
            _contactService.CreateContact(RegistrationForm);
            UpdateContact();
            RegistrationForm = new();
        }
    }



    [RelayCommand]
    public void RemoveContactFromList(ContactRegForm contact)
    {
        if (contact != null)
        {
            var result = _contactService.RemoveContactFromList(contact);
            if (result)
            {
                
                UpdateContact();
            }
        }
    }

    [RelayCommand]
    public async Task NavigateToAddPage()
    {
        await Shell.Current.GoToAsync(nameof(AddPage));
    }



   public void UpdateContact()
    {
        ContactList = new ObservableCollection<ContactRegForm>(_contactService.GetContacts());
    }


}
