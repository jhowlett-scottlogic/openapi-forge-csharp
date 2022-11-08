using System;
using Gherkin.Ast;
using RichardSzalay.MockHttp;
using Xunit;
using Xunit.Abstractions;
using Xunit.Gherkin.Quick;

namespace Features
{
    [FeatureFile(nameof(Tags) + Constants.FeatureFileExtension)]
    public sealed class Tags : FeatureBase
    {
        private readonly Dictionary<string, string> _responses = new Dictionary<string, string>();

        public Tags(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        [Then(@"the method ""(.*)"" should be present")]
        public void ThenMethodExists(String method)
        {
            var apiClient = _testHelper.CreateApiClient(_mockHttp.ToHttpClient(), 0);
            var methodInfo = apiClient.GetType().GetMethod(method);
            Assert.NotNull(methodInfo);
        }

        [Then(@"the method ""(.*)"" should not be present")]
        [And(@"the method ""(.*)"" should not be present")]
        public void ThenMethodDoesNotExist(String method)
        {
            var apiClient = _testHelper.CreateApiClient(_mockHttp.ToHttpClient(), 0);
            var methodInfo = apiClient.GetType().GetMethod(method);
            Assert.Null(methodInfo);
        }
    }
}