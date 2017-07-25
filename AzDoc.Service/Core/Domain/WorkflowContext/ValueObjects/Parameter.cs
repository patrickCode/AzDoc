using AzDoc.Common.Constants;
using System;
using System.Collections.Generic;

namespace AzDoc.Domain.WorkflowContext.ValueObjects
{
    public class Parameter
    {
        public string Name { get;set;}
        public string Value { get; set; }
        public ParameterType ParameterType { get; set; }

        public string GetActualValue(Dictionary<string, string> stepResults)
        {
            Validate();
            if (ParameterType == ParameterType.StepResult)
            {
                var stepName = Value;
                if (!stepResults.ContainsKey(stepName))
                {
                    throw new Exception("No Step Found");
                }
                return stepResults[stepName];
            }

            return Value;
        }

        public void Validate()
        {

        }
    }
}