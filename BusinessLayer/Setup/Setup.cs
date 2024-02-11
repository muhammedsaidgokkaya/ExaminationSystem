using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Setup
{
    public static class Setup
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IQuestionService, QuestionManager>();
            services.AddScoped<IAnswerTypeService, AnswerTypeManager>();
            services.AddScoped<IAnswerValueService, AnswerValueManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IQuizService, QuizManager>();
            services.AddScoped<IQuizUserService, QuizUserManager>();
            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<IUserRoleService, UserRoleManager>();
            services.AddScoped<IUserService, UserManager>();

            services.AddScoped<IQuestionDal, QuestionRepository>();
            services.AddScoped<IAnswerTypeDal, AnswerTypeRepository>();
            services.AddScoped<IAnswerValueDal, AnswerValueRepository>();
            services.AddScoped<ICategoryDal, CategoryRepository>();
            services.AddScoped<IQuizDal, QuizRepository>();
            services.AddScoped<IQuizUserDal, QuizUserRepository>();
            services.AddScoped<IRoleDal, RoleRepository>();
            services.AddScoped<IUserRoleDal, UserRoleRepository>();
            services.AddScoped<IUserDal, UserRepository>();
        }
    }
}
