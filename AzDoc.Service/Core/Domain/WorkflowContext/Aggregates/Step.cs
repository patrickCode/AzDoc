using AzDoc.Common.Domain;
using System.Threading.Tasks;
using AzDoc.Domain.WorkflowContext.ValueObjects;

namespace AzDoc.Domain.WorkflowContext.Aggregates
{
    public abstract class Step: Aggregate
    {
        private string _workflowId;
        public string WorkflowId { get => _workflowId; }

        private Step _nextStep;
        public Step NextStep { get => _nextStep; }

        private Step _previousStep;
        public Step PreviousStep { get => _previousStep; }

        private int _order;
        public int Order { get => _order; }

        public abstract StepExecutionResult Execute(StepInputParameter parameter);
        public abstract Task<StepExecutionResult> ExecuteAsync(StepInputParameter parameter);
    }
}