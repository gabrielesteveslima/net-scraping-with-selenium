namespace SibSample.Infrastructure.Database
{
    using Humanizer;
    using SibSample.Domain.Users;

    public static class DatabaseNames
    {
        #region Database Schemas

        internal const string ApplicationSchema = "SIB";

        #endregion

        #region Database tables

        internal static readonly string TblUser = nameof(User).Humanize(LetterCasing.AllCaps);

        #endregion
    }
}