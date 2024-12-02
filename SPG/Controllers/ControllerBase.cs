using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SPG.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public abstract class ControllerBase<T> : ControllerBase where T : ControllerBase<T>
    {
        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>() ?? throw new SystemException(nameof(_mediator));
    }
}
