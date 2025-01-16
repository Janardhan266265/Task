using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace Task.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly FeatureFlagRepository _repository = new FeatureFlagRepository();

        [HttpGet]
        [Route("api/featureflags/{domain}")]
        public IHttpActionResult GetFeatureFlags(string domain)
        {
            var featureFlags = _repository.GetFeatureFlagsByDomain(domain);
            return Ok(featureFlags);
        }

        [HttpPost]
        [Route("api/featureflags")]
        public IHttpActionResult AddFeatureFlag(FeatureFlag featureFlag)
        {
            _repository.AddFeatureFlag(featureFlag);
            return Ok();
        }

        [HttpPut]
        [Route("api/featureflags/{id}")]
        public IHttpActionResult UpdateFeatureFlagStatus(int id, [FromBody] bool isEnabled)
        {
            _repository.UpdateFeatureFlagStatus(id, isEnabled);
            return Ok();
        }

        [HttpDelete]
        [Route("api/featureflags/{id}")]
        public IHttpActionResult DeleteFeatureFlag(int id)
        {
            _repository.DeleteFeatureFlag(id);
            return Ok();
        }

    }
}



   

