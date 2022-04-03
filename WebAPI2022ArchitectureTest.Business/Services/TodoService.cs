using FluentResults;
using WebAPI2022ArchitectureTest.Business.Errors;
using WebAPI2022ArchitectureTest.Business.Interfaces;
using WebAPI2022ArchitectureTest.Business.Models;

namespace WebAPI2022ArchitectureTest.Business.Services
{
    public class TodoService : ITodoService
    {
        public TodoItemDTOList todoItemDTOs { get; set; }

        public TodoService()
        {
            todoItemDTOs = new TodoItemDTOList
            {
                new TodoItemDTO() { Id = 0, Title = "Create a webapp", CreationDate = DateTime.Now, Status = Data.Extensibility.Enums.TodoItemStatus.Created },
                new TodoItemDTO() { Id = 1, Title = "Test the webapp", CreationDate = DateTime.Now, Status = Data.Extensibility.Enums.TodoItemStatus.Created },
                new TodoItemDTO() { Id = 1, Title = "Deploy to azure", CreationDate = DateTime.Now, Status = Data.Extensibility.Enums.TodoItemStatus.Draft }
            };
        }

        public async Task<TodoItemDTOList> GetAllAsync()
        {
            return await Task.FromResult(todoItemDTOs);
        }

        public async Task<Result<TodoItemDTO>> GetById(int id)
        {
            var item = todoItemDTOs.FirstOrDefault(x => x.Id == id);

            if (item == null)
                return Result.Fail(new NullError());

            return await Task.FromResult(Result.Ok(item));
        }
    }
}
