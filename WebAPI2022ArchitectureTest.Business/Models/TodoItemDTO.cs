using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI2022ArchitectureTest.Data.Extensibility.Enums;

namespace WebAPI2022ArchitectureTest.Business.Models
{
    public class TodoItemDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public TodoItemStatus Status { get; set; }
    }
}
