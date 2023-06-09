using SneakersShop.Application.Logging;
using System;
using System.Text;

namespace SneakersShop.API.ErrorLogging
{
    public class ConsoleErrorLogger : IErrorLogger
    {
        public void Log(AppError error)
        {
            var errorDate = DateTime.UtcNow;
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Error code: " + error.ErrorId.ToString());
            builder.AppendLine("User: " + error.Username != null ? error.Username : "/");
            builder.AppendLine("Error time:" + errorDate.ToLongDateString());
            builder.AppendLine("Ex message:" + error.Exception.Message);
            builder.AppendLine("Ex stack trace:");
            builder.AppendLine(error.Exception.StackTrace);

            Console.WriteLine(builder.ToString());
        }
    }
}

