using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context) => _context = context;

        public async Task<Student?> GetByIdAsync(Guid id) =>
            await _context.Students.FindAsync(id);

        public async Task AddAsync(Student student) =>
            await _context.Students.AddAsync(student);

        public async Task<List<Student>> GetAllAsync() =>
            await _context.Students.ToListAsync();

        public async Task SaveChangesAsync() =>
            await _context.SaveChangesAsync();
    }
}
