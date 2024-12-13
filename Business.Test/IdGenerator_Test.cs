using Business.Helpers;

namespace Business.Test;

public class IdGenerator_Test
{

    [Fact]


    public void IdGenerator_ShouldReturnAsString()
    {

        //Arrange

        //Act
        var result = IdGenerator.UniqueIdGenerator();


        //Assert
        Assert.NotNull(result);
        Assert.IsType<string>(result);
        Assert.True(Guid.TryParse(result, out _));
    }


}
