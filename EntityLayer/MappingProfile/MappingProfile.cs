using AutoMapper;
using EntityLayer.Dto;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Question, QuestionDto>();
            CreateMap<AnswerType, AnswerTypeDto>();
            CreateMap<AnswerValue, AnswerValueDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Quiz, QuizDto>();
            CreateMap<QuizUser, QuizUserDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<User, UserDto>();
            CreateMap<UserRole, UserRoleDto>();
        }
    }
}
