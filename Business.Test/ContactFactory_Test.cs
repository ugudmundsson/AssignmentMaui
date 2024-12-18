using Business.Factories;
using Business.Models;

namespace Business.Test;

public class ContactFactory_Test
{
    [Fact]

    public void Create_ShouldReturnContact()
    {
        //arrange
        
        
        //act
        var result = ContactFactory.CreateContact();

        //assert
        Assert.NotNull(result);
        Assert.IsType<ContactRegForm>(result);

    }   
}
