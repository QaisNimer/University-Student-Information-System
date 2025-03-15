using StudentInformationSystem.Infrastructure.Entities;
using StudentInformationSystem.Utilities.Dto;

namespace StudentInformationSystem.Infrastructure.Repository.Interfaces
{
    public interface IMarks : IGenericRepository<Marks>
    {
        dynamic GetMarksBySemester(int SemesterId, int StudentId);
        Task<AcademicDetailsDto> GetAcademicDetail(long StudentId);
    }
}
