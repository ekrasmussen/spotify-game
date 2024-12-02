using Core.Common.Options;
using MediatR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Application.FeatureFlags
{
    public class GetFeatureFlagQuery : IRequest<List<string>>
    {
        public class GetFeatureFlagQueryHandler(IOptions<FeatureFlagOptions> options) : IRequestHandler<GetFeatureFlagQuery, List<string>>
        {
            public async Task<List<string>> Handle(GetFeatureFlagQuery query, CancellationToken cancellationToken)
            {
                return options.Value.AllowedNames;
            }
        }
    }
}
