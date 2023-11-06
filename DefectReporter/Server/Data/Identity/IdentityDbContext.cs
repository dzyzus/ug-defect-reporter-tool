namespace DefectReporter.Server.Data.Identity
{
    #region Usings

    using DefectReporter.Shared.Models.Identity;
    using Duende.IdentityServer.EntityFramework.Options;
    using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Options;

    #endregion

    /// <summary>
    /// The identity db context.
    /// </summary>
    public class IdentityDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public IdentityDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}