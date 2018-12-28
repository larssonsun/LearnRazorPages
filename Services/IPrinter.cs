namespace myfirstrazorpages.Services
{
    // this service is registed In Startup.cs
    public interface IPrinter
    {
        string Print();
        void Input(string content);
    }
}