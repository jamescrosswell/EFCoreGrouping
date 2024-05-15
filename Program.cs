using EFCoreGrouping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var loggerFactory = new LoggerFactory()
    .AddSentry(options =>
    {
        options.Dsn = "https://eb18e953812b41c3aeb042e666fd3b5c@o447951.ingest.us.sentry.io/5428537";
        options.Debug = true;
        // options.DiagnosticLogger = new ConsoleDiagnosticLogger(SentryLevel.Debug);
        options.MinimumEventLevel = LogLevel.Error;
    });
var logger = loggerFactory.CreateLogger<Program>();

using var db = new BloggingContext();

try
{
    Console.WriteLine("Inserting a new blog");
    var blog = new Blog { BlogId = 9999, Url = "https://blogs.msdn.com/adonet" };
    db.Entry(blog).State = EntityState.Modified;
    var modified = db.SaveChanges();
    Console.WriteLine($"{modified} items saved");
}
catch (Exception e)
{
    logger.LogError(e, "An error occurred while saving the blog");
    Console.WriteLine("An error occurred while saving the blog. It has been logged.");
}