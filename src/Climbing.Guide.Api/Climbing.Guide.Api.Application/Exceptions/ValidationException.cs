using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Climbing.Guide.Api.Application.Exceptions {
   public class ValidationException : Exception {

      public IDictionary<string, string[]> Failures { get; } = new Dictionary<string, string[]>();

      public ValidationException() : base() {
      }

      public ValidationException(IEnumerable<ValidationFailure> failures) : base() {
         var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

         foreach (var propertyName in propertyNames) {
            var propertyFailures = failures
                .Where(e => e.PropertyName == propertyName)
                .Select(e => e.ErrorMessage)
                .ToArray();

            Failures.Add(propertyName, propertyFailures);
         }
      }

      public ValidationException(string message) : base(message) {
      }

      public ValidationException(string message, Exception innerException) : base(message, innerException) {
      }
   }
}
