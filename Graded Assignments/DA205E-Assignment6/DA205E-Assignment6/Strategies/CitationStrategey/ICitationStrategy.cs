// Sixten Peterson (AQ9300) 2026-05-26

using DA205E_Assignment6.Models;

namespace DA205E_Assignment6.Strategies.CitationStrategey
{
    public interface ICitationStrategy
    {
        public string Format(Literature literature);
    }
}
