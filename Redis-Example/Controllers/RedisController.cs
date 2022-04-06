using EasyCaching.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Redis_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly IEasyCachingProvider cachingProvider;
        private readonly IEasyCachingProviderFactory _providerFactory;
        public RedisController(IEasyCachingProviderFactory providerFactory)
        {
            _providerFactory = providerFactory;
            this.cachingProvider = this._providerFactory.GetCachingProvider("redis1");
        }

        

        [HttpGet("Set")]
        public IActionResult SetItemInQuery()
        {
            this.cachingProvider.Set("KeyValue123", "here is my value", TimeSpan.FromDays(100));

            return Ok();
        }

        [HttpGet("Get")]
        public IActionResult GetItemInQuery()
        {
            var item = this.cachingProvider.Get<string>("KeyValue123");

            return Ok(item);    
        }
    }
}
