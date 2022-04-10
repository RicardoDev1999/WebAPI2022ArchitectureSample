using FluentResults;
using MediatR;
using WebAPI2022ArchitectureTest.Application.Common.Models;

namespace WebAPI2022ArchitectureTest.Application.TodoItems.Queries.Get
{
    public class GetTodoItemQuery : IRequest<Result<TodoItemDTO>>
    {
        public string Id { get; set; }
    }
}
