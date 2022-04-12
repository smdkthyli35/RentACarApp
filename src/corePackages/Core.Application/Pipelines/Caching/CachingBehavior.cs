using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Caching
{
    public class CacheSettings
    {
        public int SlidingExpiration { get; set; }
    }

    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICachableRequest, IRequest<TResponse>
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger _logger;

        public CachingBehavior(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response;
            if (request.BypassCache) return await next();

            async Task<TResponse> GetResponseAndAddToCache()
            {
                response = await next();

                var slidingExpiration = request.SlidingExpiration == null ? TimeSpan.FromHours(2) : request.SlidingExpiration;

                var cacheOptions = new DistributedCacheEntryOptions
                {
                    SlidingExpiration = slidingExpiration
                };

                var serializedData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(response));

                await _cache.SetAsync(request.CacheKey, serializedData, cacheOptions, cancellationToken);
                return response;
            }

            var cachedResponse = await _cache.GetAsync(request.CacheKey, cancellationToken);
            if (cachedResponse != null)
            {
                response = JsonConvert.DeserializeObject<TResponse>(Encoding.Default.GetString(cachedResponse));
            }
            else
            {
                response = await GetResponseAndAddToCache();
            }

            return response;
        }
    }
}
