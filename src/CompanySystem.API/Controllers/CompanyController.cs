using CompanySystem.Application.CompanyApplication.Commands.CreateCompany;
using CompanySystem.Application.CompanyApplication.Commands.DeleteCompany;
using CompanySystem.Application.CompanyApplication.Commands.UpdateCompany;
using CompanySystem.Application.CompanyApplication.Queries.GetCompanies;
using CompanySystem.Application.CompanyApplication.Queries.GetCompanyById;
using CompanySystem.Contracts.Company.CreateCompany;
using CompanySystem.Contracts.Company.GetCompany;
using CompanySystem.Contracts.Company.UpdateCompany;
using CompanySystem.Domain.CompanyAggregate;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CompanySystem.API.Controllers;

[Route("api/[controller]")]
public class CompanyController(ISender sender, IMapper mapper) : ApiController
{
    private readonly ISender _sender = sender;
    private readonly IMapper _mapper = mapper;

    [HttpPost("CreateCompany")]
    public async Task<IActionResult> CreateCompany(CreateCompanyRequest request)
    {
        var command = _mapper.Map<CreateCompanyCommand>(request);
        var result = await _sender.Send(command);

        return result.Match(
            result => Ok(_mapper.Map<CreateCompanyResponse>(result)),
            errors => Problem(errors));
    }

    [HttpGet("GetCompanies")]
    public async Task<IActionResult> GetCompanies()
    {
        var query = new GetCompaniesQuery();
        var result = await _sender.Send(query);

        return result.Match(
            result => Ok(_mapper.Map<List<Company>>(result)),
            errors => Problem(errors));
    }
        
    [HttpGet("GetCompanyById/{id}")]
    public async Task<IActionResult> GetCompanyById(Guid id)
    {
        var query = new GetCompanyByIdQuery(id);
        var result = await _sender.Send(query);

        return result.Match(
            result => Ok(_mapper.Map<GetCompanyResponse>(result)),
            errors => Problem(errors));
    }

    [HttpPut("UpdateCompany")]
    public async Task<IActionResult> UpdateCompany(UpdateCompanyRequest request)
    {
        var command = _mapper.Map<UpdateCompanyCommand>(request);
        var result = await _sender.Send(command);

        return result.Match(
            result => Ok(_mapper.Map<UpdateCompanyResponse>(result)),
            errors => Problem(errors));
    }

    [HttpDelete("DeleteCompany/{id}")]
    public async Task<IActionResult> DeleteCompany(Guid id)
    {
        var command = new DeleteCompanyCommand(id);
        var result = await _sender.Send(command);

        return result.Match(
            result => Ok(),
            errors => Problem(errors));
    }

}
