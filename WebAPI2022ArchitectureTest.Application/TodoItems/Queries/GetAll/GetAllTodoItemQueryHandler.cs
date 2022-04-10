using AutoMapper;
using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI2022ArchitectureTest.Application.Common.Interfaces;
using WebAPI2022ArchitectureTest.Application.Common.Mappings;
using WebAPI2022ArchitectureTest.Application.Common.Models;

namespace WebAPI2022ArchitectureTest.Application.TodoItems.Queries.GetAll
{
    public class GetAllTodoItemQueryHandler : IRequestHandler<GetAllTodoItemQuery, Result<IEnumerable<TodoItemDTO>>>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IAppHashIdService _appHashIdService;

        public GetAllTodoItemQueryHandler(IMapper mapper, IApplicationDbContext applicationDbContext, IAppHashIdService appHashIdService)
        {
            _mapper = mapper;
            _applicationDbContext = applicationDbContext;
            _appHashIdService = appHashIdService;
        }

        public async Task<Result<IEnumerable<TodoItemDTO>>> Handle(GetAllTodoItemQuery request, CancellationToken cancellationToken)
        {
            List<TodoItemDTO> list = await _applicationDbContext.TodoItems
                .AsQueryable()
                .ProjectToListAsync<TodoItemDTO>(_mapper.ConfigurationProvider, cancellationToken);

            if (!list.Any())
                return Result.Fail("Error");

            return list.AsEnumerable().ToResult();
        }
    }
}
