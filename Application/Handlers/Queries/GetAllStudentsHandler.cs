using Application.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Queries
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, List<Student>>
    {
        private readonly IStudentRepository _repo;

        public GetAllStudentsHandler(IStudentRepository repo) => _repo = repo;

        public async Task<List<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAllAsync();
        }
    }
}
