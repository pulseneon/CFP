namespace CFP.Application.Constants
{
    public class ApiExceptionMessage
    {
        public const string RecordExists = "An entry with that name already exists";
        public const string ActivityNotFound = "No such activity was found";
        public const string ApplicationNotFound = "No such application was found";
        public const string ApplicationSubmitted = "The application is submitted";
        public const string OneFieldMustBeFilled = "At least one field must be filled, besides the author";
        public const string CurrentApplicationNotFound = "The user with this Id does not have a draft";
        public const string IncompatibleParameters = "It is not possible to get a selection based on such parameters";
        public const string NotAllRequiredFields = "Not all required fields are filled in";
    }
}
