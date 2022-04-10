using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI2022ArchitectureTest.Application.Common.Models;

namespace WebAPI2022ArchitectureTest.Application.TodoItems.Queries.GetAll
{
    public class GetAllTodoItemQuery : IRequest<Result<IEnumerable<TodoItemDTO>>>
    {
    }
}
