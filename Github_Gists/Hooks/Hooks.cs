using BoDi;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace Github_Gists.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void StartUp()
        {
            //Adds json and registers instance to be used throughout the execution
            IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                            .Build();
            _objectContainer.RegisterInstanceAs(configuration);
        }
    }
}
