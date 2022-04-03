using WebAPI2022ArchitectureTest.Data.Extensibility.Enums;

namespace WebAPI2022ArchitectureTest.Endpoints.Todo
{
    public class GetResult
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public TodoItemStatus Status { get; set; }
    }
}
