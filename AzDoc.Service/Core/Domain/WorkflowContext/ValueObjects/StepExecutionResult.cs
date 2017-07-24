using System;

namespace AzDoc.Domain.WorkflowContext.ValueObjects
{
    public class StepExecutionResult
    {
        public bool IsSuccess { get; set; }
        public string Value { get; set; }
        public DateTime CompletionTime { get; set; }
    }
}