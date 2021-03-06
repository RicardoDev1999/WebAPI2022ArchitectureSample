using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI2022ArchitectureTest.Application.Common.Models;

namespace WebAPI2022ArchitectureTest.Application.Common.Interfaces
{
    public interface ITodoService
    {
        Task<TodoItemDTOList> GetAllAsync();
        Task<Result<TodoItemDTO>> GetById(string id);
    }
}
