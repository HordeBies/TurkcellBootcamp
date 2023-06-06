using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace HangFire_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangfireController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from hangfire web api");
        }

        // Fire and Forget Jobs
        [HttpPost]
        [Route("[action]")]
        public IActionResult Welcome()
        {
            var jobId = BackgroundJob.Enqueue(() => SendWelcomeEmail("Welcome to our app"));
            return Ok($"Job with id = {jobId} has been fired to welcome the user.");
        }

        [ApiExplorerSettings(IgnoreApi = true)] // makes swagger to skip exploring this method 
        public void SendWelcomeEmail(string message)
        {
            // send email logic
            Console.WriteLine(message);
        }

        // Delayed Jobs
        [HttpPost]
        [Route("[action]")]
        public IActionResult Discount()
        {
            var delayInSeconds = 30;
            var discountRate = 10.00;
            var jobId = BackgroundJob.Schedule(() => SendDiscountEmail("Congratulations, you have a %{0} discount waiting in your account.", discountRate),TimeSpan.FromSeconds(delayInSeconds));
            return Ok($"Job with id = {jobId} has been scheduled for {delayInSeconds} seconds later to remind the user with discount.");
        }
        [ApiExplorerSettings(IgnoreApi = true)] // makes swagger to skip exploring this method 
        public void SendDiscountEmail(string message, params object?[]? args)
        {
            // send email logic
            Console.WriteLine(message,args);
        }

        // Recurring Jobs
        [HttpPost]
        [Route("[action]")]
        public IActionResult SubscribeToNewsLetter()
        {
            // RecurrencePattern is up to you, it usually is monthly or weekly. But for the demonstration purposes, I will use every 2 minutes.
            var recurrencePattern = Cron.MinuteInterval(2); // same as "*/2 * * * *"
            var recurrencePatternHumanReadable = "every 2 minutes";
            RecurringJob.AddOrUpdate(() => SendNewsLetter(), recurrencePattern);
            return Ok($"Recurring has been scheduled to fire every {recurrencePatternHumanReadable} to inform the user with latest news.");
        }

        [ApiExplorerSettings(IgnoreApi = true)] // makes swagger to skip exploring this method 
        public async Task SendNewsLetter()
        {
            // send email logic
            Console.WriteLine("Time: {0}. The most up to date news are under your fingers!",DateTime.Now.ToString("t")); // i use short time format, but you can choose to use anything you like, for example short or long; date, date/time etc.
        }

        // Continuation Jobs
        [HttpPost]
        [Route("[action]")]
        public IActionResult UnsubscribeFromNewsLetters()
        {
            // Unsubscribe the user. To exploring easier, i added 30 seconds delay before executing the job.
            var jobId = BackgroundJob.Schedule(() => UnsubscribeUserFromNewsLetters(), TimeSpan.FromSeconds(30));
            // Email to user confirmed unsubscription message using continuation job.
            BackgroundJob.ContinueJobWith(jobId, () => SendUnsubscriptionEmail());
            return Ok($"Job with id = {jobId} has been scheduled for 30 seconds later to unsubscribe the user from news letters.");
        }

        [ApiExplorerSettings(IgnoreApi = true)] // makes swagger to skip exploring this method 
        public async Task SendUnsubscriptionEmail()
        {
            // send email logic
            Console.WriteLine("Email: You have been unsubscribed from our news letters.");
        }
        [ApiExplorerSettings(IgnoreApi = true)] // makes swagger to skip exploring this method 
        public void UnsubscribeUserFromNewsLetters()
        {
            // unsubscribe logic
            Console.WriteLine("Database: User have been unsubscribed from our news letters.");
        }
    }
}