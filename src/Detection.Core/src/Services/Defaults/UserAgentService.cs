// Copyright (c) 2014-2020 Sarin Na Wangkanai, All Rights Reserved.
// The Apache v2. See License.txt in the project root for license information.

using System;
using System.Linq;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Wangkanai.Detection.Services
{
    /// <summary>
    /// Provides the APIs for query client access device.
    /// </summary>
    public class UserAgentService : IUserAgentService
    {
        /// <summary>
        /// Get HttpContext of the application service
        /// </summary>
        public HttpContext Context { get; }
        /// <summary>
        /// Get user agnet of the request client
        /// </summary>
        public UserAgent UserAgent { get; }

        public UserAgentService(IServiceProvider services)
            : this(services.GetRequiredService<IHttpContextAccessor>().HttpContext) { }

        public UserAgentService(HttpContext context)
        {
            if (context is null)
                throw new ArgumentNullException(nameof(context));

            Context = context;
            UserAgent = CreateUserAgentFromContext(Context);
        }

        private static UserAgent CreateUserAgentFromContext(HttpContext context)
            => new UserAgent(context.Request.Headers["User-Agent"].FirstOrDefault());
    }
}
