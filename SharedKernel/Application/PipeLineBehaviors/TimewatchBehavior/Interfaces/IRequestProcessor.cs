namespace SharedKernel.Application.PipeLineBehaviors.TimewatchBehavior.Interfaces
{
    public interface IRequestProcessor<TRequest>
    {
        void Process();
    }
}
