# Hangfire
Hangfire is a popular open-source library used in .NET applications for background job processing. It provides a simple way to execute tasks asynchronously outside of the main application flow. Hangfire allows you to schedule, enqueue, and run background jobs in a reliable and scalable manner.

### Assumptions
- You have basic understanding of how .Net Web API works
- And familiar with API Documentation with Swagger

### Why Background Processing
Background Process is a process that runs behind the scenes without user intervention. Background processing is used to offload time-consuming or resource-intensive tasks from the main application thread or request processing pipeline. Here are a few reasons why background processing is beneficial:
- Improved Responsiveness
- Enhanced Scalability
- Long-Running or Asynchronous Operations
- Reduced Latency
- Improved Fault Tolerance
- Enhanced User Experience

Here are some examples of background processes commonly used in applications:
- Sending Emails
- Generating Reports
- File Uploading and Processing
- Data Synchronization
- Cache Refreshing
- Indexing and Search Operations
- Data Cleanup and Maintenance

These are just a few examples, and the possibilities for background processes are nearly endless. Essentially, any task that doesn't require immediate user interaction and can be executed asynchronously can be a candidate for background processing.

## How Hangfire Helps with Background Processing
Hangfire is specifically designed to simplify and streamline background processing in .NET applications. It provides several key features and benefits that make it a popular choice for implementing background processing tasks:
- **`Easy Integration`:** Hangfire can be easily integrated into existing .NET applications using NuGet packages.
- **`Simple Job Enqueuing`:** Hangfire provides a straightforward way to enqueue background jobs.
- **`Persistent Storage`:** Hangfire uses persistent storage (e.g., a database) to store information about scheduled and enqueued jobs. This ensures that jobs are not lost even if the application restarts or crashes.
- **`Job Scheduling`:** Hangfire offers advanced scheduling capabilities, allowing you to specify when jobs should be executed. 
- **`Distributed Processing`:** Hangfire supports distributed processing, enabling you to scale your background processing across multiple servers or instances.
- **`Dashboard and Monitoring`:** Hangfire provides a built-in dashboard that allows you to monitor the status of background jobs, view statistics, and manage recurring tasks.
- **`Retry and Error Handling`:** Hangfire handles job failures gracefully by providing built-in mechanisms for retrying failed jobs.
- **`Job Continuations`:** Hangfire supports job continuations, which allow you to define a chain of dependent jobs. Job continuations help build complex workflows and dependencies between background tasks.
- **`Integration with Dependency Injection`:** Hangfire can be easily integrated with popular dependency injection frameworks like ASP.NET Core's built-in DI container. This allows you to inject dependencies into your background job classes, making it easier to access required services and resources.

Overall, Hangfire simplifies the implementation of background processing in .NET applications by providing a reliable and feature-rich framework. It handles the complexities of job scheduling, persistence, distributed processing, error handling, and monitoring, allowing developers to focus on writing the actual background tasks and improving the overall performance and responsiveness of their applications.

## Background Jobs/Tasks
In the context of background processing, there are several types of tasks or jobs that can be executed asynchronously. Here are some common types:
- **`Simple Fire-and-Forget Jobs`:** These are tasks that are enqueued and executed once without any further interaction. For example, sending a notification email, processing a file upload, or triggering an external API call.
- **`Delayed Jobs`:** Delayed jobs are tasks that are enqueued to be executed after a certain delay or at a specific time. For instance, sending a reminder email to a user 24 hours after registration or executing a scheduled maintenance task at a specific time of the day.
- **`Recurring Jobs`:** Recurring jobs are tasks that are automatically executed on a periodic basis. You can configure the frequency and interval for these jobs, such as running a cleanup task every week or generating a report every month.
- **`Continuation Jobs`:** Continuation jobs allow you to define a chain of dependent tasks. A continuation job runs only after the successful completion of a preceding job. This enables the creation of sequential workflows or dependent task execution.

These are just a few examples of the different types of background jobs/tasks that can be processed asynchronously.

# Code
## Setting up Development Environment
1. We will start with creating a .Net Web API project, for the name of the project we chose **HangFire_WebAPI** but you can use anything you prefer. For the framework you can choose any version of .Net, in this instance we choose .Net version 8. (Additionally you can clear the weather controller with weather model to start with a blank project with only swagger configured)

![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/fcf89ece-6dfb-419e-81ba-f55b48ec2b5e)

2. Then we will install Hangfire to our project using NuGet Package Manager. For that you can simply right click the project -> Manage NuGet Packages -> Browse -> Search for HangFire and install. If you follow along this tutorial you will most likely have an error at runtime that goes like "Please add a NuGet package reference to either 'Microsoft.Data.SqlClient' or 'System.Data.SqlClient' in your application project. Hangfire.SqlServer supports both providers but let the consumer decide which one should be used." For that you can simply search for "Microsoft.Data.SqlClient" in NuGet Package Manager, install it and you are done.

![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/1a388469-2bc3-4a7c-b724-01dcc9bdd03a)

3. Now we need to configure hangfire to run with our project. First of we need a database connection to store persistent data for Hangfire (you can seperate background processing database with your business database or use a single database for both). Create a database (tables will be automatically created so dont worry about it), get the connection string and add it to your `appsetting.json` file:
```json
"ConnectionStrings": {
    "DefaultConnection": "Business Database Connection String",
    "HangFireConnection": "Hangfire Database Connection String"
  }
```
Then we can open up `Program.cs` file and add this two lines before `var app = builder.build()`:
```cs
builder.Services.AddHangfire(options =>
{
    options.UseSqlServerStorage(builder.Configuration.GetConnectionString("HangfireConnection"));
});
builder.Services.AddHangfireServer();
```
And add this line after `var app = builder.build()` to enable built-in dashboard:
```cs
app.UseHangfireDashboard();
```
4. Lastly we will create a HangfireController inside Controllers folder to explore Hangfire
```cs
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
    }
}
```
5. Additionaly to check if you are on the correct path, run the application we created so far and you should see something like these on the `/swagger` and `/hangfire` paths

https://localhost:{PORT}/swagger/index.html
 ![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/d63cd99a-4da0-4b62-98a6-deb427ba3600)
 
 https://localhost:{PORT}/hangfire
 ![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/0702f1ab-cf88-4216-b357-4a97937b10f8)

## Exploring Hangfire
Now that we set-up our project. We are ready to explore Hangfire.
### 1. Fire-and-Forget Jobs
A fire-and-forget job is a type of background task or job that is enqueued for execution and does not require any further interaction or monitoring. Once the job is enqueued, the application continues its execution without waiting for the job to complete or checking its status. For example sending a welcome email to a first time user of an app. Now lets create an api endpoint and a helper method that will do exactly that:
```cs
[HttpPost]
[Route("[action]")]
public IActionResult Welcome()
{
    var jobId = BackgroundJob.Enqueue(() => SendWelcomeEmail("Welcome to our app"));
    return Ok($"Job with id = {jobId} has been fired to welcome the user.");
}

[ApiExplorerSettings(IgnoreApi = true)] // if we dont add this line swagger throws an error, this makes swagger to skip exploring this method
public void SendWelcomeEmail(string message)
{
    // send email logic
    Console.WriteLine(message);
}
```
Notice that the `BackgroundJob` class comes from namespace `Hangfire` and we use `Enqueue` to create a fire-and-forget job.
To test, first we use swagger ui to call the endpoint, then check hangfire dashboard:
![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/067c0915-3bdd-4faf-9265-97ea3faf03a6)
![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/dd33eba7-0955-4f7f-87e6-e8d3465d244d)
![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/865e5bd2-6a96-4381-b5e1-c55053dd69d7)
and check the console for output

![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/f46824a3-e1c4-4e8f-b034-99a7986ecb43)

### 2. Delayed Jobs
A delayed job is a type of background task or job that is enqueued for execution but is scheduled to start after a specified delay or at a specific time in the future. It allows you to defer the execution of a task, providing control over when it should be processed. For example a discount reminder email for the user after some time in an e-commerce app. For the simplicity's sake, we will use shorter delays usually in seconds or minutes, feel free to explore other options like hours, days or months. Now lets create an api endpoint and a helper method that will do exactly that:
```cs
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
```
Again, we use swagger ui to call the endpoint, then check hangfire dashboard:
![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/7c44b590-fc20-4820-a902-2eecf7e40460)
![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/8b49db8f-a7de-41a5-999a-197d547de575)
![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/f4eb1deb-59d3-4374-938c-3d59b4aec6ab)

### 3. Recurring Jobs
Recurring jobs are a type of background task or job that is automatically executed on a periodic basis. They allow you to schedule a task to run repeatedly at specified intervals, such as every minute, hour, day, week, or any other desired frequency. For example sending news letters to users at specific intervals. Now lets create an api endpoint and a helper method that will do exactly that:
```cs
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
```
Notice how we used `RecurringJob` from `Hangfire` instead of `BackgroundJob`.
Once again, we use swagger ui to call the endpoint, then check hangfire dashboard (notice how the same job executed after 2 minutes of first execution):
![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/4c17aee9-3dac-40fd-94ae-6346713bbd5f)
![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/b2c6f98a-babc-4be0-891f-d356d4731dec)
![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/983555ba-db70-4427-95cf-267fd83bcf3a)
![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/8b0861bf-eb03-4e06-aa7a-73e077072120)
![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/9a6f85ec-985a-40d9-9089-2661c5fe04f9)

### 4. Continuation Jobs
Continuation jobs, also known as dependent jobs, allow you to define a chain of tasks where one job is executed only after the successful completion of a preceding job. They enable you to create sequential workflows or execute tasks based on the output or completion status of previous jobs. For example when a user wants to unsubscribe from news letters, we can first unsubsribe user from news letter at the bussiness level then send an email that confirms that indeed the user is unsubsribed. Now lets create an api endpoint and a helper method that will do exactly that:
```cs
[HttpPost]
[Route("[action]")]
public IActionResult UnsubscribeFromNewsLetters()
{
    // Unsubscribe the user. To exploring easier, we added 30 seconds delay before executing the job.
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
```
And for the last time, we use swagger ui to call the endpoint, then check hangfire dashboard (notice how second job waited first job to finish):
![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/6ffc767d-f17d-4963-99b1-a7ce386cbe6c)
![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/dc7c9a62-e376-48d6-877b-b2bdfcd8429e)
![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/c2615bf4-bde7-4a8c-bc30-7adb74dbc1e9)
![image](https://github.com/HordeBies/TurkcellBootcamp/assets/73644073/07227e86-8f07-4658-8144-07cac03f32da)

