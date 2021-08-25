namespace SharedKernel.Application.PipeLineBehaviors.TimewatchBehavior.Configurations
{
    public class TimewatchConfiguration
    {
        public TimewatchConfiguration(bool allowUse, int maxForQueries, int maxForCommands, int maxForOthers)
        {
            AllowUse = allowUse;
            MaxMilliSecondsForQueries = maxForQueries;
            MaxMilliSecondsForCommands = maxForCommands;
            MaxMilliSecondsForOthers = maxForOthers;
        }

        public bool AllowUse { get; private set; }

        public int MaxMilliSecondsForQueries { get; private set; }

        public int MaxMilliSecondsForCommands { get; private set; }

        public int MaxMilliSecondsForOthers { get; private set; }
    }
}
