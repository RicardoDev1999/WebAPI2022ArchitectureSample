using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI2022ArchitectureTest.Application.Common.Models;
using WebAPI2022ArchitectureTest.Application.TodoItems.Queries.Get;

namespace WebAPI2022ArchitectureTest.Endpoints.Todo
{
    [Route("api/todo")]
    public class Get : EndpointBaseAsync
      .WithRequest<GetTodoItemQuery>
      .WithResult<TodoItemDTO>
    {
        private ISender _mediator;

        public Get(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get")]
        [SwaggerOperation(
            Summary = "Get Todo Item by id",
            Description = "Get specific Todo Item",
            OperationId = "TodoItem.Get",
            Tags = new[] { "TodoEndpoints" })]
        public override async Task<TodoItemDTO> HandleAsync([FromQuery]GetTodoItemQuery query, CancellationToken cancellationToken = default) 
        { 
            var result = await _mediator.Send(query, cancellationToken);
            return result.Value;
        }
    }
}
