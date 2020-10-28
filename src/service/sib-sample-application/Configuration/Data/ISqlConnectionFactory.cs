namespace SibSample.Application.Configuration.Data
{
    using System.Data;

    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}