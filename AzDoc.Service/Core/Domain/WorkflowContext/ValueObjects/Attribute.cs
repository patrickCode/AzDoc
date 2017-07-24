using System;

namespace AzDoc.Domain.WorkflowContext.ValueObjects
{
    public class Attribute
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public Type AttributeType { get; set; }
        public void Validate()
        {

        }
    }
}