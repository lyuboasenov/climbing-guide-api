using System.Collections.Generic;
using System.Threading.Tasks;
using Climbing.Guide.Api.Services.Resources;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Climbing.Guide.Api.Services {
   public class GradesService : Grades.GradesBase {
      private static readonly GradeSystem[] _gradeSystems = new GradeSystem[] {
         new GradeSystem() {
            Type = GradeSystemType.French,
            RouteType = RouteType.Sport,
            Name = "French"
         },
         new GradeSystem() {
            Type = GradeSystemType.Uiaa,
            RouteType = RouteType.Sport,
            Name = "UIAA"
         },
         new GradeSystem() {
            Type = GradeSystemType.Yosemite,
            RouteType = RouteType.Sport,
            Name = "Yosemite"
         },
         new GradeSystem() {
            Type = GradeSystemType.Font,
            RouteType = RouteType.Boulder,
            Name = "Font Bouldering"
         },
         new GradeSystem() {
            Type = GradeSystemType.V,
            RouteType = RouteType.Boulder,
            Name = "V Grade"
         },
         new GradeSystem() {
            Type = GradeSystemType.B,
            RouteType = RouteType.Boulder,
            Name = "Peak Bouldering"
         },
         new GradeSystem() {
            Type = GradeSystemType.French,
            RouteType = RouteType.Trad,
            Name = "French"
         },
         new GradeSystem() {
            Type = GradeSystemType.Uiaa,
            RouteType = RouteType.Trad,
            Name = "UIAA"
         },
         new GradeSystem() {
            Type = GradeSystemType.Yosemite,
            RouteType = RouteType.Trad,
            Name = "Yosemite"
         },
      };
      private static readonly IDictionary<GradeSystemType, IEnumerable<Grade>> _grades =
         new Dictionary<GradeSystemType, IEnumerable<Grade>>() {
            { GradeSystemType.French, new [] {
               new Grade() { Value = 20, Name = "3a", Type = GradeSystemType.French },
               new Grade() { Value = 25, Name = "3a+", Type = GradeSystemType.French },
               new Grade() { Value = 30, Name = "3b", Type = GradeSystemType.French },
               new Grade() { Value = 35, Name = "3b+", Type = GradeSystemType.French },
               new Grade() { Value = 40, Name = "3c", Type = GradeSystemType.French },
               new Grade() { Value = 45, Name = "3c+", Type = GradeSystemType.French },
               new Grade() { Value = 50, Name = "4a", Type = GradeSystemType.French },
               new Grade() { Value = 55, Name = "4a+", Type = GradeSystemType.French },
               new Grade() { Value = 60, Name = "4b", Type = GradeSystemType.French },
               new Grade() { Value = 65, Name = "4b+", Type = GradeSystemType.French },
               new Grade() { Value = 70, Name = "4c", Type = GradeSystemType.French },
               new Grade() { Value = 75, Name = "4c+", Type = GradeSystemType.French },
               new Grade() { Value = 80, Name = "5a", Type = GradeSystemType.French },
               new Grade() { Value = 85, Name = "5a+", Type = GradeSystemType.French },
               new Grade() { Value = 90, Name = "5b", Type = GradeSystemType.French },
               new Grade() { Value = 95, Name = "5b+", Type = GradeSystemType.French },
               new Grade() { Value = 100, Name = "5c", Type = GradeSystemType.French },
               new Grade() { Value = 105, Name = "5c+", Type = GradeSystemType.French },
               new Grade() { Value = 110, Name = "6a", Type = GradeSystemType.French },
               new Grade() { Value = 115, Name = "6a+", Type = GradeSystemType.French },
               new Grade() { Value = 120, Name = "6b", Type = GradeSystemType.French },
               new Grade() { Value = 125, Name = "6b+", Type = GradeSystemType.French },
               new Grade() { Value = 130, Name = "6c", Type = GradeSystemType.French },
               new Grade() { Value = 135, Name = "6c+", Type = GradeSystemType.French },
               new Grade() { Value = 140, Name = "7a", Type = GradeSystemType.French },
               new Grade() { Value = 145, Name = "7a+", Type = GradeSystemType.French },
               new Grade() { Value = 150, Name = "7b", Type = GradeSystemType.French },
               new Grade() { Value = 155, Name = "7b+", Type = GradeSystemType.French },
               new Grade() { Value = 160, Name = "7c", Type = GradeSystemType.French },
               new Grade() { Value = 165, Name = "7c+", Type = GradeSystemType.French },
               new Grade() { Value = 170, Name = "8a", Type = GradeSystemType.French },
               new Grade() { Value = 175, Name = "8a+", Type = GradeSystemType.French },
               new Grade() { Value = 180, Name = "8b", Type = GradeSystemType.French },
               new Grade() { Value = 185, Name = "8b+", Type = GradeSystemType.French },
               new Grade() { Value = 190, Name = "8c", Type = GradeSystemType.French },
               new Grade() { Value = 192, Name = "8c/+", Type = GradeSystemType.French },
               new Grade() { Value = 195, Name = "8c+", Type = GradeSystemType.French },
               new Grade() { Value = 197, Name = "8c+/9a", Type = GradeSystemType.French },
               new Grade() { Value = 200, Name = "9a", Type = GradeSystemType.French },
               new Grade() { Value = 205, Name = "9a+", Type = GradeSystemType.French },
               new Grade() { Value = 210, Name = "9b", Type = GradeSystemType.French },
               new Grade() { Value = 215, Name = "9b+", Type = GradeSystemType.French },
               new Grade() { Value = 220, Name = "9c", Type = GradeSystemType.French },
               new Grade() { Value = 225, Name = "9c+", Type = GradeSystemType.French },
            } },
            { GradeSystemType.Uiaa, new [] {
               new Grade() { Value = 20, Name = "3-", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 30, Name = "3", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 40, Name = "3+", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 50, Name = "4-", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 60, Name = "4", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 70, Name = "4+", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 80, Name = "5-", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 85, Name = "5", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 90, Name = "5+", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 95, Name = "5+/6-", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 100, Name = "6-", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 105, Name = "6", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 110, Name = "6+", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 115, Name = "6+/7-", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 117, Name = "7-", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 120, Name = "7", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 125, Name = "7+", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 130, Name = "7+/8-", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 135, Name = "8-", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 140, Name = "8", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 145, Name = "8+", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 150, Name = "8+/9-", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 155, Name = "9-", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 160, Name = "9", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 165, Name = "9+", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 170, Name = "9+/10-", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 175, Name = "10-", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 180, Name = "10", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 185, Name = "10+", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 190, Name = "11-", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 195, Name = "11-/11", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 200, Name = "11", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 205, Name = "11+", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 210, Name = "12-", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 215, Name = "12", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 220, Name = "12+", Type = GradeSystemType.Uiaa },
               new Grade() { Value = 225, Name = "12+/13-", Type = GradeSystemType.Uiaa },
            } },
            { GradeSystemType.Yosemite, new [] {
               new Grade() { Value = 20, Name = "5.2", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 30, Name = "5.3", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 40, Name = "5.4", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 50, Name = "5.5", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 60, Name = "5.6", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 80, Name = "5.7", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 90, Name = "5.8", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 100, Name = "5.9", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 110, Name = "5.10a", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 115, Name = "5.10b", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 117, Name = "5.10c", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 120, Name = "5.10d", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 125, Name = "5.11a", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 130, Name = "5.11b", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 135, Name = "5.11c", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 140, Name = "5.11d", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 145, Name = "5.12a", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 150, Name = "5.12b", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 155, Name = "5.12c", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 160, Name = "5.12d", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 165, Name = "5.13a", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 170, Name = "5.13b", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 175, Name = "5.13c", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 180, Name = "5.13d", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 185, Name = "5.14a", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 190, Name = "5.14b", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 195, Name = "5.14c", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 200, Name = "5.14d", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 205, Name = "5.15a", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 210, Name = "5.15b", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 215, Name = "5.15c", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 220, Name = "5.15d", Type = GradeSystemType.Yosemite },
               new Grade() { Value = 225, Name = "5.16a", Type = GradeSystemType.Yosemite },
            } },
            { GradeSystemType.Font, new [] {
               new Grade() { Value = 20, Name = "3", Type = GradeSystemType.Font },
               new Grade() { Value = 25, Name = "4-", Type = GradeSystemType.Font },
               new Grade() { Value = 30, Name = "4", Type = GradeSystemType.Font },
               new Grade() { Value = 35, Name = "4+", Type = GradeSystemType.Font },
               new Grade() { Value = 40, Name = "5-", Type = GradeSystemType.Font },
               new Grade() { Value = 45, Name = "5", Type = GradeSystemType.Font },
               new Grade() { Value = 50, Name = "5+", Type = GradeSystemType.Font },
               new Grade() { Value = 55, Name = "6A", Type = GradeSystemType.Font },
               new Grade() { Value = 60, Name = "6A+", Type = GradeSystemType.Font },
               new Grade() { Value = 65, Name = "6B", Type = GradeSystemType.Font },
               new Grade() { Value = 70, Name = "6B+", Type = GradeSystemType.Font },
               new Grade() { Value = 75, Name = "6C", Type = GradeSystemType.Font },
               new Grade() { Value = 80, Name = "6C+", Type = GradeSystemType.Font },
               new Grade() { Value = 85, Name = "7A", Type = GradeSystemType.Font },
               new Grade() { Value = 90, Name = "7A+", Type = GradeSystemType.Font },
               new Grade() { Value = 95, Name = "7B", Type = GradeSystemType.Font },
               new Grade() { Value = 100, Name = "7B+", Type = GradeSystemType.Font },
               new Grade() { Value = 105, Name = "7C", Type = GradeSystemType.Font },
               new Grade() { Value = 110, Name = "7C+", Type = GradeSystemType.Font },
               new Grade() { Value = 115, Name = "8A", Type = GradeSystemType.Font },
               new Grade() { Value = 120, Name = "8A+", Type = GradeSystemType.Font },
               new Grade() { Value = 125, Name = "8B", Type = GradeSystemType.Font },
               new Grade() { Value = 130, Name = "8B+", Type = GradeSystemType.Font },
               new Grade() { Value = 135, Name = "8C", Type = GradeSystemType.Font },
               new Grade() { Value = 140, Name = "8C+", Type = GradeSystemType.Font },
               new Grade() { Value = 145, Name = "9A", Type = GradeSystemType.Font },
            } },
            { GradeSystemType.V, new [] {
               new Grade() { Value = 20, Name = "VB", Type = GradeSystemType.V },
               new Grade() { Value = 25, Name = "V0-", Type = GradeSystemType.V },
               new Grade() { Value = 35, Name = "V0", Type = GradeSystemType.V },
               new Grade() { Value = 45, Name = "V0+", Type = GradeSystemType.V },
               new Grade() { Value = 52, Name = "V1", Type = GradeSystemType.V },
               new Grade() { Value = 55, Name = "V2", Type = GradeSystemType.V },
               new Grade() { Value = 60, Name = "V3", Type = GradeSystemType.V },
               new Grade() { Value = 65, Name = "V3+", Type = GradeSystemType.V },
               new Grade() { Value = 70, Name = "V4", Type = GradeSystemType.V },
               new Grade() { Value = 75, Name = "V4+", Type = GradeSystemType.V },
               new Grade() { Value = 80, Name = "V5", Type = GradeSystemType.V },
               new Grade() { Value = 85, Name = "V6", Type = GradeSystemType.V },
               new Grade() { Value = 90, Name = "V7", Type = GradeSystemType.V },
               new Grade() { Value = 100, Name = "V8", Type = GradeSystemType.V },
               new Grade() { Value = 105, Name = "V9", Type = GradeSystemType.V },
               new Grade() { Value = 110, Name = "V10", Type = GradeSystemType.V },
               new Grade() { Value = 115, Name = "V11", Type = GradeSystemType.V },
               new Grade() { Value = 120, Name = "V12", Type = GradeSystemType.V },
               new Grade() { Value = 125, Name = "V13", Type = GradeSystemType.V },
               new Grade() { Value = 130, Name = "V14", Type = GradeSystemType.V },
               new Grade() { Value = 135, Name = "V15", Type = GradeSystemType.V },
               new Grade() { Value = 140, Name = "V16", Type = GradeSystemType.V },
               new Grade() { Value = 145, Name = "V17", Type = GradeSystemType.V },
            } },
            { GradeSystemType.B, new [] {
               new Grade() { Value = 20, Name = "B0", Type = GradeSystemType.B },
               new Grade() { Value = 35, Name = "B1", Type = GradeSystemType.B },
               new Grade() { Value = 45, Name = "B2", Type = GradeSystemType.B },
               new Grade() { Value = 52, Name = "B3", Type = GradeSystemType.B },
               new Grade() { Value = 55, Name = "B4", Type = GradeSystemType.B },
               new Grade() { Value = 65, Name = "B5", Type = GradeSystemType.B },
               new Grade() { Value = 80, Name = "B6", Type = GradeSystemType.B },
               new Grade() { Value = 85, Name = "B7", Type = GradeSystemType.B },
               new Grade() { Value = 90, Name = "B8", Type = GradeSystemType.B },
               new Grade() { Value = 100, Name = "B9", Type = GradeSystemType.B },
               new Grade() { Value = 105, Name = "B10", Type = GradeSystemType.B },
               new Grade() { Value = 110, Name = "B11", Type = GradeSystemType.B },
               new Grade() { Value = 115, Name = "B12", Type = GradeSystemType.B },
               new Grade() { Value = 120, Name = "B13", Type = GradeSystemType.B },
               new Grade() { Value = 130, Name = "B14", Type = GradeSystemType.B },
               new Grade() { Value = 135, Name = "B15", Type = GradeSystemType.B },
               new Grade() { Value = 140, Name = "B16", Type = GradeSystemType.B },
               new Grade() { Value = 145, Name = "B17", Type = GradeSystemType.B },
            } }
         };

      private readonly ILogger<GradesService> _logger;
      public GradesService(ILogger<GradesService> logger) {
         _logger = logger;
      }

      public override Task<GradeSystemsReply> GetGradeSystems(Empty request, ServerCallContext context) {
         _logger.LogInformation("GetGradeSystems");

         var result = new GradeSystemsReply();
         result.GradeSystems.AddRange(_gradeSystems);

         return Task.FromResult(result);
      }

      public override Task<GradesReply> GetGrades(GradesRequest request, ServerCallContext context) {
         _logger.LogInformation($"GetGrades({request.Type})");

         Task<GradesReply> result = null;
         if (_grades.ContainsKey(request.Type)) {
            var grades = new GradesReply();
            grades.Grades.AddRange(_grades[request.Type]);
            result = Task.FromResult(grades);
         } else {
            result = Task.FromException<GradesReply>(
               new System.Exception(
                  string.Format(
                     Strings.Services_GradesService_GetGrades_GradeSystemType_Not_Supported,
                     request.Type)));
         }

         return result;
      }
   }
}
