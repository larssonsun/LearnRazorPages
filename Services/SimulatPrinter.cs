using System;

namespace myfirstrazorpages.Services
{
    // this service is registed In Startup.cs
    public class SimulatePrinter : IPrinter
    {
        private string _Content;
        public void Input(string content) =>
            _Content = $"content in SimulatePrinter is :\"{content}\".";

        public string Print() =>
            $"{_Content}(printdate:{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")})";
    }
}