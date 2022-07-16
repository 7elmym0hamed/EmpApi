namespace EmpApi.Persistence.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region CTOR
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        #endregion

        #region DbSet
        public virtual DbSet<PersonModel> Persons { get; set; }
        public virtual DbSet<AddressModel> Address { get; set; }


        #endregion

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=EmpApi_DB;Trusted_Connection=True;");
            }
        }
        #endregion
    }
}
