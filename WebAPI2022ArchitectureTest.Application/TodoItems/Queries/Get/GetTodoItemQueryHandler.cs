using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentResults;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI2022ArchitectureTest.Application.Common.Errors;
using WebAPI2022ArchitectureTest.Application.Common.Interfaces;
using WebAPI2022ArchitectureTest.Application.Common.Models;

namespace WebAPI2022ArchitectureTest.Application.TodoItems.Queries.Get
{
    public class GetTodoItemQueryHandler : IRequestHandler<GetTodoItemQuery, Result<TodoItemDTO>>
    {

        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IAppHashIdService _appHashIdService;

        public GetTodoItemQueryHandler(IApplicationDbContext applicationDbContext, IAppHashIdService appHashIdService, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _appHashIdService = appHashIdService;
            _mapper = mapper;  
        }

        public async Task<Result<TodoItemDTO>> Handle(GetTodoItemQuery request, CancellationToken cancellationToken)
        {
            var decodedId = _appHashIdService.Decode(request.Id);

            var item = await _applicationDbContext.TodoItems
                .Where(x => x.Id == decodedId)
                .ProjectTo<TodoItemDTO>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);
        
            if (item == null)
                return Result.Fail(new DbNotFound());

            return item.ToResult(); 
        }
    }
}
