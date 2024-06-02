﻿using Mapster;
using CompanySystem.Domain.CompanyAggregate;
using CompanySystem.Contracts.Company.CreateCompany;
using CompanySystem.Contracts.Company.UpdateCompany;
using CompanySystem.Contracts.Company.GetCompanyById;
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

        config.NewConfig<GetCompanyByIdResult, GetCompanyByIdResponse>()
            .Map(dest => dest.Id, src => src.Company.Id.Value)
            .Map(dest => dest.Size, src => src.Company.Size.Value)
            .Map(dest => dest, src => src.Company);

        config.NewConfig<UpdateCompanyRequest, UpdateCompanyCommand>();

        config.NewConfig<Company, UpdateCompanyResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Size, src => src.Size.Value);
    }
}
