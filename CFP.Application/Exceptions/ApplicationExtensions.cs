namespace CFP.Application.Exceptions
{
    public static class ApplicationExtensions
    {
        public static List<Domain.Entities.Application> submittedAfter(this IEnumerable<Domain.Entities.Application> applications,
            DateTime date)
        {
            return applications.Where(app => app.Submitted && app.Created > date).ToList();
        }
        
        public static List<Domain.Entities.Application> unsubmittedOlder(this IEnumerable<Domain.Entities.Application> applications,
            DateTime date)
        {
            return applications.Where(app => !app.Submitted && app.Created > date).ToList();
        }
    }
}
