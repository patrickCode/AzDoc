using System;
using System.Net.Http;
using Newtonsoft.Json;
using AzDoc.Common.Constants;
using System.Threading.Tasks;
using System.Collections.Generic;
using AzDoc.Domain.WorkflowContext.ValueObjects;

namespace AzDoc.Domain.WorkflowContext.Aggregates.Steps
{
    public class HttpStep : Step
    {
        private Uri _endpoint;
        private HttpMethod _method;
        private string _body;
        private Dictionary<string, string> _headers;
        private string _aadClientId;
        private string _aadClientSecret;
        private string _aadResourceId;

        public HttpStep()
        {
            _stepType = StepType.Http;
        }

        public override StepExecutionResult Execute(StepInputParameter parameter)
        {
            return ExecuteAsync(parameter).Result;
        }

        public override async Task<StepExecutionResult> ExecuteAsync(StepInputParameter stepParameter)
        {
            try
            {
                Initialize(stepParameter);
                var response = await ExecuteHttpAsync();
                var content = await response.Content.ReadAsStringAsync();

                return new StepExecutionResult
                {
                    CompletionTime = DateTime.UtcNow,
                    IsSuccess = response.IsSuccessStatusCode,
                    Value = content
                };
            }
            catch (Exception error)
            {
                return new StepExecutionResult
                {
                    CompletionTime = DateTime.UtcNow,
                    IsSuccess = false,
                    Value = error.ToString()
                };
            }
        }

        private void Initialize(StepInputParameter stepParameter)
        {
            var parameters = stepParameter.ParametersDictionary;
            _endpoint = new Uri(parameters["Endpoint"].GetActualValue(stepParameter.StepResults));
            _method = new HttpMethod(parameters["Method"].GetActualValue(stepParameter.StepResults));

            if (parameters.TryGetValue("Body", out Parameter BodyParameter))
                _body = BodyParameter.GetActualValue(stepParameter.StepResults);

            if (parameters.TryGetValue("Header", out Parameter HeaderParameter))
                _headers = JsonConvert.DeserializeObject<Dictionary<string, string>>(HeaderParameter.GetActualValue(stepParameter.StepResults));

            if (parameters.TryGetValue("AadClientId", out Parameter AadClientParameter))
                _aadClientId = AadClientParameter.GetActualValue(stepParameter.StepResults);

            if (parameters.TryGetValue("AadClientSecret", out Parameter AddClientSecret))
                _aadClientSecret = AddClientSecret.GetActualValue(stepParameter.StepResults);

            if (parameters.TryGetValue("AadResourceId", out Parameter AddResourceId))
                _aadResourceId = AddResourceId.GetActualValue(stepParameter.StepResults);
        }

        private async Task<HttpResponseMessage> ExecuteHttpAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = _endpoint;
                if (_headers != null)
                {
                    foreach (var header in _headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                
                if (_method == HttpMethod.Get)
                    return await client.GetAsync(_endpoint);

                if (_method == HttpMethod.Post)
                    return await client.PostAsync(_endpoint, new StringContent(_body));

                if (_method == HttpMethod.Put)
                    return await client.PutAsync(_endpoint, new StringContent(_body));

                if (_method == HttpMethod.Delete)
                    return await client.DeleteAsync(_endpoint);

                throw new Exception("HTTP Method not supported");
            }
        }
    }
}