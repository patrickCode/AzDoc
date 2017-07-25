using AzDoc.Common.Domain;
using System.Threading.Tasks;
using AzDoc.Common.Constants;
using AzDoc.Domain.WorkflowContext.ValueObjects;

namespace AzDoc.Domain.WorkflowContext.Aggregates
{
    public abstract class Step: Aggregate
    {
        protected string _workflowId;
        public string WorkflowId { get => _workflowId; }

        protected string _title;
        public string Title { get => _title; }

        protected Step _nextStep;
        public Step NextStep { get => _nextStep; }

        protected Step _previousStep;
        public Step PreviousStep { get => _previousStep; }

        protected int _order;
        public int Order { get => _order; }

        protected StepType _stepType;
        public StepType StepType { get => _stepType; }

        public abstract StepExecutionResult Execute(StepInputParameter parameter);
        public abstract Task<StepExecutionResult> ExecuteAsync(StepInputParameter parameter);
    }
}