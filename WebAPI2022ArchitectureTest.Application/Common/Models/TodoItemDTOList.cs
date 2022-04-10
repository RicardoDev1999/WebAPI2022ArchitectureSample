using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI2022ArchitectureTest.Application.Common.Models
{
    public class TodoItemDTOList
    {
        public TodoItemDTOList() { 
            Items = new List<TodoItemDTO>();
        }

        public List<TodoItemDTO> Items { get; set; }
    }
}
