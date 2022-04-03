using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI2022ArchitectureTest.Business.Interfaces;

namespace WebAPI2022ArchitectureTest.Endpoints.Todo
{
    [Route("api/todo")]
    public class List : EndpointBaseAsync
      .WithoutRequest
      .WithResult<IEnumerable<ListResult>>
    {
        private readonly ITodoService _todoServices;
        private readonly IMapper _mapper;

        public List(ITodoService todoServices, IMapper mapper)
        {
            _todoServices = todoServices;
            _mapper = mapper;
        }

        [HttpGet("list")]
        [SwaggerOperation(
            Summary = "List all Todo Items",
            Description = "List all Todo's",
            OperationId = "TodoItem.List",
            Tags = new[] { "TodoEndpoints" })
        ]
        public override async Task<IEnumerable<ListResult>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var list = (await _todoServices.GetAllAsync()).Select(x => _mapper.Map<ListResult>(x));
            return list;
        }
    }
}
