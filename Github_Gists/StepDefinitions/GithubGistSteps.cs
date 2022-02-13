using Github_Gists.Resources;
using Github_Gists.Utils;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Github_Gists.StepDefinitions
{
    [Binding]
    public class GithubGistSteps
    {
        private readonly TestConfig _test;
        private readonly ScenarioContext _scenarioContext;
        private readonly GistResource _gistResource;
        private readonly RequestBuilder _requestBuilder;

        public GithubGistSteps(IConfiguration configuration, ScenarioContext scenarioContext)
        {
            _test = configuration.GetSection("Github_Gist").Get<TestConfig>();  //Provides data from json
            _scenarioContext = scenarioContext;
            _gistResource = new GistResource();
            _requestBuilder = new RequestBuilder();
        }

        [Given(@"I have request '(.*)'")]
        public void GivenIHaveARequestBody(string parameterType, Table parameterTable)
        {
            var requestParameters = parameterTable.CreateSet<RequestParams>();
            switch (parameterType)
            {
                case "body":
                    JsonObject requestBody = _requestBuilder.AddRequestBody(requestParameters);
                    _scenarioContext.Add("RequestBody", requestBody);
                    break;
                case "headers":
                    Dictionary<string, string> headers = _requestBuilder.AddHeaders(requestParameters, _test);
                    _scenarioContext.Add("Headers", headers);
                    break;
            }
        }
        
        [When(@"I '(.*)' '(.*)' endpoint")]
        public void GivenIEndpoint(string requestMethod, string endpoint)
        {
            RestResponse response;
            Dictionary<string, string> headers = _scenarioContext.TryGetValue("Headers", out headers) ? headers : null;
            Dictionary<string, string> queryParameters = _scenarioContext.TryGetValue("QueryParameters", out queryParameters) ? queryParameters : null;
            JsonObject requestBody = _scenarioContext.TryGetValue("RequestBody", out requestBody) ? requestBody : null;
            switch (requestMethod)
            {
                case "GET":
                    response = _gistResource.GetGistResponse(_test.host + endpoint.Replace("gist_id", _test.gistId), headers, queryParameters);
                    //Can be used to effectively validate the added comment 
                    _scenarioContext.Add("Response", response);
                    break;
                case "POST":
                    response = _gistResource.PostGistResponse(_test.host + endpoint.Replace("gist_id", _test.gistId), headers, queryParameters, requestBody);
                    _scenarioContext.Add("Response", response);
                    break;
            }
        }
        
        [Then(@"I should get '(.*)' Response")]
        public void ThenIShouldGetResponse(int statusCode)
        {
            RestResponse response = _scenarioContext.TryGetValue("Response", out response) ? response : null;
            Assert.AreEqual(statusCode, (int)response.StatusCode);
        }
    }
}
