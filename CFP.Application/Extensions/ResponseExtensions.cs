﻿using CFP.Application.Models.Responses;
using CFP.Domain.Entities;

namespace CFP.Application.Extensions
{
    public static class ResponseExtensions
    {
        public static ActivityResponse ToResponse(this Activity response) => new ActivityResponse()
        {
            Activity = response.Name,
            Description = response.Description,
        };

        public static IEnumerable<ActivityResponse> ToResponse(this List<Activity> response) =>
            response.Select(activity => new ActivityResponse
        {
            Activity = activity.Name,
            Description = activity.Description,
        });

        public static ApplicationResponse ToResponse(this Domain.Entities.Application response, string activityName) => new ApplicationResponse()
        {
            Id = response.Id,
            Author = response.Author,
            Activity = activityName,
            Name = response.Name,
            Description = response.Description,
            Outline = response.Outline,
        };

        public static IEnumerable<ApplicationResponse> ToResponse(this List<Domain.Entities.Application> applications, List<Activity> activities)
        {
            return applications.Select(app => new ApplicationResponse
            {
                Id = app.Id,
                Author = app.Author,
                Name = app.Name,
                Activity = activities.FirstOrDefault(x => x.Id == app.Activity)?.Name,
                Description = app.Description,
                Outline = app.Outline,
            });
        }
    }
}
