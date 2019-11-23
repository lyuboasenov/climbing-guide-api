using Climbing.Guide.Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Climbing.Guide.Api.Application.Interfaces {
   public interface IStaticContext {
      IEnumerable<GradeSystem> GradeSystems { get; }
      IEnumerable<Grade> GetGrades(GradeSystemType gradeSystemType);
   }
}
