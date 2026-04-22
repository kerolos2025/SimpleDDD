using Application.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Guid>
    {
        private readonly IStudentRepository _repo;

        public CreateStudentHandler(IStudentRepository repo) => _repo = repo;

        public async Task<Guid> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = Student.Create(request.Name, request.Email, request.Grade, request.Street, request.City, request.ZipCode);
            await _repo.AddAsync(student);
            await _repo.SaveChangesAsync();
            return student.Id;
        }
    }
}
