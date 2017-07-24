using AzDoc.Common.Constants;

namespace AzDoc.Domain.WorkflowContext.ValueObjects
{
    public class Parameter
    {
        private Attribute _attribute { get; set; }
        public Attribute Attribute { get
            {
                Validate();
                _attribute.Validate();
                return _attribute;
            }
        }
        public ParameterType ParameterType { get; set; }

        public void Validate()
        {

        }
    }
}