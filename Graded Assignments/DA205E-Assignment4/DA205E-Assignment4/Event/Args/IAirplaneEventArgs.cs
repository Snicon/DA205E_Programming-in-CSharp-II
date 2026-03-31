// Sixten Peterson (AQ9300) 2026-03-31
namespace DA205E_Assignment4.EventArgsClasses
{
    // A very basic interface outlining the properties the implementing classes should include.
    public interface IAirplaneEventArgs
    {
        public string Name { get; }
        public string Destination { get; }
        public DateTime Timestamp { get; }
        public string Message { get; }
    }
}
