using System.Security.Cryptography;
using System;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;

namespace StudentInformationSystem.Utilities.Dto
{
    public record MarksDto
    {
        public string CourseCharacters { get; set; }
        public string CourseNumber { get; set; }
        public string CourseName { get; set; }
        public string Section { get; set; }
        public int Hours { get; set; }
        public int MidTermMarks { get; set; }
        public int WorkMarks { get; set; }
        public int CollectionMarks { get; set; }
    }

    public class CourseMarksDto
    {
        public CourseMarksDto()
        {
            MarksDto = new List<MarksDto>();
        }
        public long SemesterId { get; set; }
        public List<MarksDto> MarksDto { get; set; }

    }
}
