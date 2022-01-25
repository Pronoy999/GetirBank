namespace GetirBank.Exception
{
    public static class ErrorCodes
    {
        public const string FirstNameMissing = "missing_first_name";
        public const string LastNameMissing = "missing_last_name";
        public const string EmailMissing = "missing_email";
        public const string PasswordMissing = "missing_password";

        public const string AccountTypeMissing = "missing_account_type";
        public const string AccountBalanceMissing = "missing_account_balance";
        public const string AccountIdMissing = "missing_account_id";
        public const string TransactionTypeMissing = "missing_transaction_type";
        public const string StartDateMissing = "start_date_missing";
        public const string EndDateMissing = "end_date_missing";
    }
}