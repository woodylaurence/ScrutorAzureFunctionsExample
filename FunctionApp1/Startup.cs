using FunctionApp1;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

[assembly: FunctionsStartup(typeof(Startup))]
namespace FunctionApp1;

public class Startup : FunctionsStartup
{
	public override void Configure(IFunctionsHostBuilder builder)
	{
		builder.Services.AddLogging(x => x.AddConsole());

		builder.Services.AddSingleton<IService, BasicService>();
		builder.Services.Decorate<IService, DecoratedService>();
	}
}

public interface IService
{
	string GetDateTime();
}

public class BasicService : IService
{
	public string GetDateTime() => DateTime.UtcNow.ToString("F");
}

public class DecoratedService : IService
{
	private readonly IService _service;

	public DecoratedService(IService service)
	{
		_service = service;
	}

	public string GetDateTime() => _service.GetDateTime().ToUpper();
}