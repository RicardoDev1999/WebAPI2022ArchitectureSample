using WebAPI2022ArchitectureTest.Domain.Enums;

namespace WebAPI2022ArchitectureTest.Application.Common.Models
{
    public class TodoItemDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public TodoItemStatus Status { get; set; }
    }
}
