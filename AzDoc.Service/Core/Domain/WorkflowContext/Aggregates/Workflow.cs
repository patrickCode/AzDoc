using AzDoc.Common.Domain;

namespace AzDoc.Domain.WorkflowContext.Aggregates
{
    public class Workflow : Aggregate
    {
        private Trigger _trigger;
        public Trigger Trigger { get => _trigger; }

        private Step _firstStep;
        public Step FirstStep { get => _firstStep; }

        private string _sessionId;
        public string SessionId { get => _sessionId; }

    }
}