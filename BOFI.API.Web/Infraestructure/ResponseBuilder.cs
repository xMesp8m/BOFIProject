using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOFI.API.Web.Infraestructure
{
    public class ResponseBuilder
    {
        private readonly ResponseDto _response;
        private string _statusCode;
        private List<string> _errors;
        private int _errorCount;
        private dynamic _requestResponse;

        public ResponseBuilder(string statusCode = "", dynamic response = null)
        {
            _statusCode = statusCode;
            _requestResponse = response;
            _response = new ResponseDto();
            _errors = new List<string>();
        }

        public ResponseBuilder SetStatus(string statusCode)
        {
            _statusCode = statusCode;
            return this;
        }

        public ResponseBuilder SetErrors(List<string> errors)
        {
            _errors = errors;
            _errorCount = _errors.Count;
            return this;
        }

        public ResponseBuilder SetResponse(dynamic response)
        {
            _requestResponse = response;
            return this;
        }

        public ResponseDto Result()
        {

            _response.StatusCode = _statusCode;
            _response.Errors = _errors;
            _response.ErrorCount = _errorCount;
            _response.Response = _requestResponse;
            return _response;
        }

    }
}