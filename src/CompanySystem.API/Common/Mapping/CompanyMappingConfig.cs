using Mapster;
using CompanySystem.Domain.CompanyAggregate;
using CompanySystem.Contracts.Company.CreateCompany;
using CompanySystem.Contracts.Company.UpdateCompany;
using CompanySystem.Contracts.Company.GetCompany;
using CompanySystem.Application.CompanyApplication.Commands.UpdateCompany;
using CompanySystem.Application.CompanyApplication.Commands.CreateCompany;
using CompanySystem.Application.CompanyApplication.Common;

namespace CompanySystem.API.Common.Mapping;

public class CompanyMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateCompanyRequest, CreateCompanyCommand>();

        config.NewConfig<Company, CreateCompanyResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Size, src => src.Size.Value);

        config.NewConfig<Company, GetCompanyResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Size, src => src.Size.Value)
            .Map(dest => dest, src => src);

        config.NewConfig<UpdateCompanyRequest, UpdateCompanyCommand>();

        config.NewConfig<Company, UpdateCompanyResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Size, src => src.Size.Value);
    }
}
