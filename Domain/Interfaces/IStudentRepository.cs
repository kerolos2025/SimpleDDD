using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student?> GetByIdAsync(Guid id);
        Task AddAsync(Student student);
        Task<List<Student>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
