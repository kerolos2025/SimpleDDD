using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateStudentCommand request)
        {
           
            var id = await _mediator.Send(request);
            return Ok(id);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var students = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(students);
        }
    }

   
}
