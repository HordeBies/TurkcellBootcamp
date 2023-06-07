using AutoMapper;
using Kidega.Core.DTO;
using Kidega.Domain.Entities;

namespace Kidega.Core.Mappings
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<BookAddRequest, Book>();
            CreateMap<Book, BookUpdateRequest>().ReverseMap();
            CreateMap<Book, BookResponse>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<BookResponse, BookUpdateRequest>();

            CreateMap<CategoryAddRequest, Category>();
            CreateMap<Category, CategoryUpdateRequest>().ReverseMap();
            CreateMap<Category, CategoryResponse>();
            CreateMap<CategoryResponse, CategoryUpdateRequest>();
            
            CreateMap<AuthorAddRequest, Author>();
            CreateMap<Author, AuthorUpdateRequest>().ReverseMap();
            CreateMap<Author, AuthorResponse>();
            CreateMap<AuthorResponse, AuthorUpdateRequest>();
        }
    }
}
