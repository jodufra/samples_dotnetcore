using Application.Domain.Entities;
using Application.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Persistence
{
    public class AppDbInitializer
    {
        private static readonly Random rnd = new Random((int)DateTime.Now.Ticks);

        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.Migrate();

            if (!context.UserTypes.Any())
            {
                SeedUserTypes(context);
            }

            if (!context.Users.Any())
            {
                SeedUsers(context);
            }
        }

        private static void SeedUserTypes(AppDbContext context)
        {
            context.UserTypes.AddRange(Enumeration.GetAll<UserType>());
            context.SaveChanges();
        }

        private static void SeedUsers(AppDbContext context)
        {
            var guests = new List<User>();
            for (var i = 0; i < 5; i++)
            {
                guests.Add(new User()
                {
                    Address = CreateAddress(),
                    Cellphone = CreatePhone(),
                    Telephone = CreatePhone(),
                    Name = RandomString(),
                    UserType = UserType.Guest
                });
            }

            var students = new List<User>();
            for (var i = 0; i < 1000; i++)
            {
                students.Add(new User()
                {
                    Address = CreateAddress(),
                    Cellphone = CreatePhone(),
                    Telephone = CreatePhone(),
                    Name = RandomString(),
                    UserType = UserType.Student
                });
            }

            var teachers = new List<User>();
            for (var i = 0; i < 50; i++)
            {
                teachers.Add(new User()
                {
                    Address = CreateAddress(),
                    Cellphone = CreatePhone(),
                    Telephone = CreatePhone(),
                    Name = RandomString(),
                    UserType = UserType.Teacher
                });
            }

            var admins = new List<User>();
            for (var i = 0; i < 5; i++)
            {
                admins.Add(new User()
                {
                    Address = CreateAddress(),
                    Cellphone = CreatePhone(),
                    Telephone = CreatePhone(),
                    Name = RandomString(),
                    UserType = UserType.Administrator
                });
            }

            context.Users.AddRange(guests);
            context.Users.AddRange(students);
            context.Users.AddRange(teachers);
            context.Users.AddRange(admins);
            context.SaveChanges();
        }

        private static Address CreateAddress()
        {
            return new Address(RandomString(), RandomString(), RandomString(), RandomString(), RandomString(), RandomString(), RandomString());
        }

        private static Phone CreatePhone()
        {
            return new Phone(RandomString(), RandomString());
        }

        private static string RandomString(int? length = null)
        {
            const string characters = " 01234 56789 ABCDEFGHIJKLMN OPQRSTUVWXYZ abcdefghijklm nopqrstuvwxyz ";

            var charactersLength = characters.Length;
            var resultLength = length.HasValue ? length.Value : rnd.Next(4, 128);

            var result = new StringBuilder(resultLength);
            for (var i = 0; i < resultLength; i++)
            {
                result.Append(characters[rnd.Next(charactersLength)]);
            }

            return result.ToString();
        }
    }
}
