
using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pet.GetById;

public class GetPetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        return new ResponsePetJson
        {
            Id = id,
            Name = "Pipoca",
            Type= Communication.Enums.PetType.Cat,
            Birthday = new DateTime(year: 2024, month: 08, day: 13)
            
        };

    }
}
