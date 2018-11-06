using Application.Domain.Infrastructure;
using System;

namespace Application.Domain.Entities
{
    public class Enrollment : BaseEntity
    {
        public Enrollment()
        {
        }

        public int CourseId { get; set; }
        public int UserId { get; set; }
        public float? Grade { get; set; }
        public DateTime? DateGraded { get; set; }

        public Course Course { get; set; }
        public User User { get; set; }
    }
}