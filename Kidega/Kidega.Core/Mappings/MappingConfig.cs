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
            CreateMap<Book, BookResponse>();

            CreateMap<CategoryAddRequest, Category>();
            CreateMap<Category, CategoryUpdateRequest>().ReverseMap();
            CreateMap<Category, CategoryResponse>();
            
            CreateMap<AuthorAddRequest, Author>();
            CreateMap<Author, AuthorUpdateRequest>().ReverseMap();
            CreateMap<Author, AuthorResponse>();
        }
    }
}
