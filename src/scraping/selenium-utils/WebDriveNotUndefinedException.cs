using System;

namespace Selenium.Utils
{
    public class WebDriveNotUndefinedException : Exception
    {
        public WebDriveNotUndefinedException(string message) : base(message)
        {
        }
    }
}