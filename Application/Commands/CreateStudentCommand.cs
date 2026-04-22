using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public record CreateStudentCommand(string Name, string Email, int Grade, string Street, string City, string ZipCode) : IRequest<Guid>;
}
