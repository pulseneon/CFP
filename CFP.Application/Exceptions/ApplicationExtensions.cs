namespace CFP.Application.Exceptions
{
    public static class ApplicationExtensions
    {
        public static IEnumerable<Domain.Entities.Application> submittedAfter(this IEnumerable<Domain.Entities.Application> applications,
            DateTime date)
        {
            return applications.Where(app => app.Submitted && app.Created > date);
        }

        public static IEnumerable<Domain.Entities.Application> unsubmittedOlder(this IEnumerable<Domain.Entities.Application> applications,
            DateTime date)
        {
            return applications.Where(app => !app.Submitted && app.Created < date);
        }
    }
}
