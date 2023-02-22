using AutoMapper;
using EntityFrameworkDemo.Dto;
using EntityFrameworkDemo.Models;

namespace EntityFrameworkDemo
{
    internal class CategoryProjector : Profile
    {
        public CategoryProjector()
        {
            CreateProjection<Category, CategotyDto>();
        }
    }
}