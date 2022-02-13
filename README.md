# Github_Gists

GitHub Gists - Add comment POST request API Validation

Code to execute, validate and induce error responses. This has been achieved by varying the inputs, authorization etc.

Framework - C# RestSharp

Feature Files – Translates all the test cases in Gherkin format.
Hooks – Acts as an entry point to the execution. Responsible for loading data files prior to the execution.
Resources – Builds request, sends request GET or POST, receives response.
StepDefinitions – Converts the Gherkin file into steps to execute. Filters and initiates calls to the resources for different validations.
Utils – Contains Data Models to be used throughout the execution.
AppSettings.json – Json file to be initiated at the start of execution.