using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Wipster.Refactoring.Domain.Entities;
using Wipster.Refactoring.Application.DTOs.Employee;
using Wipster.Refactoring.Application.DTOs.Category;
using Wipster.Refactoring.Application.DTOs.Products;

namespace Wipster.Refactoring.Api.Profiles
{
    public class WipsterProfile : Profile
    {
        public WipsterProfile()
        {
            //CreateMap(ReadingSource -> Target)
            //Read
            CreateMap<Employee, GetEmpDto>();
            //Create New Employee
            CreateMap<CreateEmpDto, Employee>();
            //Update New Employee
            CreateMap<UpdateEmpDto, Employee>();

            CreateMap<Category, GetCategoryDto>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<Product, GetProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();

        }
       
    }
}
