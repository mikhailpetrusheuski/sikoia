# Sikoia

This is an API application built with .NET 7 that integrates with multiple third-party services to provide a unified view of company data for Sikoia's customers. It makes use of [Fluent Assertions](https://fluentassertions.com/) and [xUnit](https://xunit.net/) for testing, and [Coverlet](https://github.com/coverlet-coverage/coverlet) for code coverage.

## Getting Started

### Prerequisites

- .NET 7.0 SDK
- [Coverlet](https://github.com/coverlet-coverage/coverlet) for code coverage (optional)

### Running the project

1. Clone the repository:

`git clone https://github.com/mikhailpetrusheuski/sikoia.git`


2. Navigate to the cloned repository and build the project:

`cd src`

`dotnet build`


3. Run the project:

`dotnet run dotnet run --project ./Web/API`


The API should now be running at `http://localhost:5173`.

### Running the tests

To run the tests, use the `dotnet test` command:

`dotnet test ./Tests/UnitTests`

`dotnet test ./Tests/IntegrationTests`

### Checking code coverage

To generate a code coverage report, you'll need to install Coverlet. The easiest way to do this is to install the Coverlet.Console global tool:

`dotnet tool install --global coverlet.console`

Once you've installed Coverlet, you can generate a code coverage report by running the following command:

`dotnet test ./Tests/UnitTests --collect:"XPlat Code Coverage"`
`dotnet test ./Tests/IntegrationTests --collect:"XPlat Code Coverage"`

## Contributing

For any changes, please open an issue first to discuss what you would like to change. Pull requests are welcome.

## License

[MIT](https://choosealicense.com/licenses/mit/)





