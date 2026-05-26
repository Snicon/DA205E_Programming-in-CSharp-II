using DA205E_Assignment6.Strategies.CitationStrategey;

namespace DA205E_Assignment6.Managers
{
    public class LiteratureManager
    {
        private ICitationStrategy citationStrategy;

        public LiteratureManager()
        {
            citationStrategy = new HarvardStrategy(); // Setting Harvard as a default because its popular, though I guess that goes for a lot of these
        }

        public ICitationStrategy CitationStrategy
        {
            get => citationStrategy;
            set
            {
                if (value != null)
                    citationStrategy = value;
            }
        }
    }
}
