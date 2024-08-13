using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Petfolio.Application.UseCases.Pet.GetAll;
using Petfolio.Application.UseCases.Pet.GetById;
using Petfolio.Application.UseCases.Pet.Register;
using Petfolio.Application.UseCases.Pet.Update;
using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;

namespace Petfolio.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PetController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredPetJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestPetJson request)
    {
        var registerPetUseCase = new RegisterPetUseCase();

        registerPetUseCase.Execute(request);
        return Created();
    }


    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Update(int id, [FromBody] RequestPetJson request)
    {
        var updatePetuseCase = new UpdatePetUseCase();

        updatePetuseCase.Execute(id, request);

        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllPetJson), StatusCodes.Status200OK)]
    [ProducesResponseType( StatusCodes.Status204NoContent)]
    public IActionResult GetAll()
    {
        var getAllPetsUseCase = new GetAllPetsUseCase();

       var response =  getAllPetsUseCase.Execute();

        if (response.Pets.Any()) { 
            return Ok(response);
        }

        return NoContent();
    }


    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponsePetJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Get(int id)
    {
        var getPetByIdUseCase = new GetPetByIdUseCase();

        var response = getPetByIdUseCase.Execute(id);

        return Ok(response);
    }
}
