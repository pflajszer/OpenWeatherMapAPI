
# OpenWeatherMapAPI
A wrapper library for OpenWeatherMap API built in .NET Core 3.1
Currently, the package supports the following endpoints:
- Current Weather Data:
	- By geographic coordinates

And the following API versions were tested:
- v2.5

## Installation

#### Package Manager:
`Install-Package OpenWeatherMapAPI.ClientLibrary`
#### .NET CLI:
`dotnet add package OpenWeatherMapAPI.ClientLibrary`

## Setup

When using dependency injection in .NET Core 3.X, you can register type like so, by registering a type in the ```ConfigureServices()``` method:

Startup.cs:
```csharp
public void ConfigureServices(IServiceCollection services)
{
	services.AddScoped<IOpenWeatherMapAPIClient>(provider => new OpenWeatherMapAPIClient("MY_API_KEY"));
}
```

MyClass.cs:

```csharp
public class MyClass
{
	private readonly IOpenWeatherMapAPIClient _api;

	public EmailManager(IOpenWeatherMapAPIClient api)
	{
		_api = api;
	}
}
```

Alternatively, you don't have to inject/instantiate the whole API client and only choose services that you need, by injecting i.e. `ICurrentWeatherDataService` - each service should take the same parameters as the `IOpenWeatherMapAPIClient` constructor. If you use `IOpenWeatherMapAPIClient`, all the constructed services will use the same API version you provide in the main constructor.

You can control which version of OpenWeatherMap API you're using by providing an optional `APIUrl` parameter to your constructors and using `OpenWeatherMapAPI.Models.Shared.Constants` class (i.e. `Constants.APIUrl_Ver2_5`), or provide the version yourself.

## Usage

The example project that uses the below code can be found under `OpenWeatherMapAPI.SystemTests`. Feel free to clone and play around!

Quickstart:

```csharp
var apiClient = new OpenWeatherMapAPIClient("MY_API_KEY");
var currentWeather = apiClient.CurrentWeatherData;

var request = new ByGeographicCoordinatesRequest()
{
	Latitude = 53.7998,
	Longitude = 1.5584
};

var result = await currentWeather.ByGeographicCoordinatesAsync(request);

// {"coord":{"lon":1.5584,"lat":53.7998},"weather":[{"id":804,"main":"Clouds","description":"overcast clouds","icon":"04d"}],"base":"stations","main":{"temp":286.48,"feels_like":286.11,"temp_min":286.48,"temp_max":286.48,"pressure":1015,"humidity":86},"visibility":10000,"wind":{"speed":9.68,"deg":180},"clouds":{"all":100},"dt":1634563421,"sys":{"type":2,"id":2029944,"country":"GB","sunrise":1634538410,"sunset":1634575838},"timezone":0,"id":2650519,"name":"Easington","cod":200}

```
## Testing

Some Integration and System tests are available in the repo, but make sure you update the `OpenWeatherMapAPI.TestResources.BaseConstants.APIkey` constant.


## Development

In order to add a new service to the library, you'll need to:
- Add a new endpoint constant in `OpenWeatherMapAPI.Models.Shared.Constants`
- Add a new folder under `OpenWeatherMapAPI.Models` with your new service name. In that folder, add a POCO response class
- For each method you're adding, also add a request class in the above namespace
- Add a folder under `OpenWeatherMapAPI.Services` with the new service you're adding and add a concrete class and an abstract interface. Derive your class from `APIGateway` class. Don't call the API yourself - use your service to construct the request object you need to pass on and use the `ExecuteGetAsync<T>` method to do the calling for you
- Add your new interface to the `OpenWeatherMapAPIClient` and `IOpenWeatherMapAPIClient` as a property
- Following the existing structure, add any sample requests/responses to `OpenWeatherMapAPI.TestResources` project, add integration tests in `OpenWeatherMapAPI.IntegrationTests` project and a logic for system tests in `OpenWeatherMapAPI.SystemTests`

##### Thanks for reading and feel free to reach out!
##### Pav
