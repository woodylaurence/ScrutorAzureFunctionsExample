using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionApp1
{
	public class Function1
	{
		private readonly IService _service;

		public Function1(IService service)
		{
			_service = service;
		}

		[FunctionName("Function1")]
		public void Run([TimerTrigger("* * * * * *")] TimerInfo myTimer, ILogger log)
		{
			log.LogInformation(_service.GetDateTime());
		}
	}
}
