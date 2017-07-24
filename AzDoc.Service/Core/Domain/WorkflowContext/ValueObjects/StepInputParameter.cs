using System;
using System.Linq;
using System.Collections.Generic;

namespace AzDoc.Domain.WorkflowContext.ValueObjects
{
    public class StepInputParameter
    {
        public IEnumerable<Parameter> Parameters { get; set; }
        public Guid SessionGuid { get; set; }

        public Dictionary<string, Parameter> ParametersDictionary
        {
            get => Parameters.ToDictionary(parameter => parameter.Attribute.Name);
        }
    }
}