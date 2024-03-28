namespace CFP.Application.Constants
{
    public class ApiExceptionType
    {
        public const string RecordExists = "RecordExists";
        public const string ActivityNotFound = "ActivityNotFound";
        public const string ApplicationNotFound = "ApplicationNotFound";
        public const string ApplicationSubmitted = "ApplicationSubmitted";
        public const string OneFieldMustBeFilled = "OneFieldMustBeFilled";
        public const string CurrentApplicationNotFound = "CurrentApplicationNotFound";
        public const string IncompatibleParameters = "IncompatibleParameters";
        public const string NotAllRequiredFields = "NotAllRequiredFields";
    }
}
