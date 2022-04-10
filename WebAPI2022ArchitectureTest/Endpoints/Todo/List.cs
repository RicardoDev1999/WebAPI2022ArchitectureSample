using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI2022ArchitectureTest.Application.Common.Interfaces;
using WebAPI2022ArchitectureTest.Application.Common.Models;
using WebAPI2022ArchitectureTest.Application.TodoItems.Queries.GetAll;

namespace WebAPI2022ArchitectureTest.Endpoints.Todo
{
    [Route("api/todo")]
    public class List : EndpointBaseAsync
      .WithoutRequest
      .WithResult<IEnumerable<TodoItemDTO>>
    {
        private ISender _mediator;

        public List(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        [SwaggerOperation(
            Summary = "List all Todo Items",
            Description = "List all Todo's",
            OperationId = "TodoItem.List",
            Tags = new[] { "TodoEndpoints" })
        ]
        public override async Task<IEnumerable<TodoItemDTO>> HandleAsync(CancellationToken cancellationToken = default)
        {
            var result = await _mediator.Send(new GetAllTodoItemQuery());

            if (result.IsFailed) { 
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                return new List<TodoItemDTO>();
            }

            return result.Value;
        }
    }
}
