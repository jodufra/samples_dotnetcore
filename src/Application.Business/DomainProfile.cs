using Application.Business.Requests.Courses;
using Application.Business.Requests.Departments;
using Application.Business.Requests.Enrollments;
using Application.Business.Requests.Entities;
using Application.Business.Requests.UserCourses;
using Application.Business.Requests.Users;
using Application.Domain.Entities;
using AutoMapper;

namespace Application.Business
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            // Courses
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<UpdateCourseCommand, Course>();
            CreateMap<Course, CourseDetailModel>();
            CreateMap<Course, CoursesItemModel>();

            // Departments
            CreateMap<CreateDepartmentCommand, Department>();
            CreateMap<UpdateDepartmentCommand, Department>();
            CreateMap<Department, DepartmentDetailModel>();
            CreateMap<Department, DepartmentsItemModel>();

            // Enrollments
            CreateMap<CreateEnrollmentCommand, Enrollment>();
            CreateMap<UpdateEnrollmentCommand, Enrollment>();
            CreateMap<Enrollment, EnrollmentDetailModel>();
            CreateMap<Enrollment, EnrollmentsItemModel>();

            // Entities
            CreateMap<CreateEntityCommand, Entity>();
            CreateMap<UpdateEntityCommand, Entity>();
            CreateMap<Entity, EntityDetailModel>();
            CreateMap<Entity, EntitiesItemModel>();

            // UserCourses
            CreateMap<CreateUserCourseCommand, UserCourse>();
            CreateMap<UpdateUserCourseCommand, UserCourse>();
            CreateMap<UserCourse, UserCourseDetailModel>();
            CreateMap<UserCourse, UserCoursesItemModel>();

            // Users
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
            CreateMap<User, UserDetailModel>();
            CreateMap<User, UsersItemModel>();
        }
    }
}
