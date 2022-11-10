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

        private String getTagFileName(String tag)
        {
            return (tag == "") ? "" : tag[0].ToString().ToUpper() + tag.Substring(1);
        }

        [Then(@"the api file with tag ""(.*)"" exists")]
        [And(@"the api file with tag ""(.*)"" exists")]
        public void ThenApiFileWithTagExists(String tag)
        {
            Assert.NotNull(_testHelper.TryGetType($"ApiClient{getTagFileName(tag)}"));
            Assert.NotNull(_testHelper.TryGetType($"IApiClient{getTagFileName(tag)}"));
        }

        [Then(@"the api file with tag ""(.*)"" does not exist")]
        [And(@"the api file with tag ""(.*)"" does not exist")]
        public void ThenApiFileWithTagDoesNotExist(String tag)
        {
            Assert.Null(_testHelper.TryGetType($"ApiClient{getTagFileName(tag)}"));
            Assert.Null(_testHelper.TryGetType($"IApiClient{getTagFileName(tag)}"));
        }

        [Then(@"the method ""(.*)"" should be present in the api file with tag ""(.*)""")]
        [And(@"the method ""(.*)"" should be present in the api file with tag ""(.*)""")]
        public void ThenMethodExists(String method, String tag)
        {
            var methodInfo = _testHelper.TryGetType($"ApiClient{getTagFileName(tag)}").GetMethod(method);
            Assert.NotNull(methodInfo);
        }

        [Then(@"the method ""(.*)"" should not be present in the api file with tag ""(.*)""")]
        [And(@"the method ""(.*)"" should not be present in the api file with tag ""(.*)""")]
        public void ThenMethodDoesNotExist(String method, String tag)
        {
            var methodInfo = _testHelper.TryGetType($"ApiClient{getTagFileName(tag)}").GetMethod(method);
            Assert.Null(methodInfo);
        }
    }
}