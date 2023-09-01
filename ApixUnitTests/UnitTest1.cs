using Fatec_Ades.Services;
using System.Configuration;

namespace ApixUnitTests;

public class UnitTest1
{
    [Fact]
    public async void Test1()
    {


        Fatec_Ades.DTOs.UsuarioDTO teste = new Fatec_Ades.DTOs.UsuarioDTO();
        teste.Email = "wallace.silva@ecoportosantos.com.br";
         var result = await teste.EnviarEmail(teste);
        Assert.True(result);
    }
}