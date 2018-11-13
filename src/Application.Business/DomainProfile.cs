using Application.Business.Services.Courses;
using Application.Business.Services.Departments;
using Application.Business.Services.Enrollments;
using Application.Business.Services.UserCourses;
using Application.Business.Services.Users;
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
