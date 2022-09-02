﻿using MediatR;

namespace Lingvo.Application.Common
{
    public class ValidationError: INotification
    {
        protected ValidationError() { }

        private ValidationError(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public ValidationError(string code, string message, string propertyName) : this(code, message)
        {
            PropertyName = propertyName;
        }

        public string Code { get; init; } = null!;
        public string Message { get; init; } = null!;
        public string? PropertyName { get; init; }
    }
}
