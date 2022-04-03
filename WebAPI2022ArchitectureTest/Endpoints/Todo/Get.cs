using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI2022ArchitectureTest.Business.Interfaces;

namespace WebAPI2022ArchitectureTest.Endpoints.Todo
{
    [Route("api/todo")]
    public class Get : EndpointBaseAsync
      .WithRequest<string>
      .WithResult<GetResult>
    {
        private readonly ITodoService _todoServices;
        private readonly IMapper _mapper;
        private readonly IAppHashIdService _appHashIdService;

        public Get(ITodoService todoServices, IMapper mapper, IAppHashIdService appHashIdService)
        {
            _todoServices = todoServices;
            _mapper = mapper;
            _appHashIdService = appHashIdService;
        }

        [HttpGet("get/{id}")]
        [SwaggerOperation(
            Summary = "Get Todo Item by id",
            Description = "Get specific Todo Item",
            OperationId = "TodoItem.Get",
            Tags = new[] { "TodoEndpoints" })]
        public override async Task<GetResult> HandleAsync(string id, CancellationToken cancellationToken = default)
        {
            var decodedId = _appHashIdService.Decode(id);
            var result = await _todoServices.GetById(decodedId);

            if (result.IsFailed)
                throw new System.Web.Http.HttpResponseException(System.Net.HttpStatusCode.BadRequest);

            return _mapper.Map<GetResult>(result.Value);
        }
    }
}
