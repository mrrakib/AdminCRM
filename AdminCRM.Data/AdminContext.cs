using AdminCRM.Model.Models.Account;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using AdminCRM.Model.Models.CompanyDetails;
using AdminCRM.Model.Models.Sections;

namespace AdminCRM.Data
{
    public class AdminContext : IdentityDbContext<ApplicationUser>
    {
        public AdminContext() : base("Admin_Context")
        {

        }

        #region all tables
        public DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanySocialProfile> CompanySocialProfile { get; set; }
        public virtual DbSet<AboutSection> AboutSections { get; set; }
        public virtual DbSet<ExperienceSection> ExperienceSections { get; set; }
        public virtual DbSet<WorkProcessSection> WorkProcessSections { get; set; }
        public virtual DbSet<OurServiceMain> OurServiceMain { get; set; }
        public virtual DbSet<ServiceSingle> ServiceSingles { get; set; }
        public virtual DbSet<FeatureMain> FeatureMains { get; set; }
        public virtual DbSet<FeatureSingle> FeatureSingles { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamMember> TeamMembers { get; set; }

        #endregion



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationRole>().HasKey<string>(r => r.Id).ToTable("Roles");
            modelBuilder.Entity<ApplicationUser>().HasMany<ApplicationUserRole>((ApplicationUser u) => u.UserRoles);
            modelBuilder.Entity<ApplicationUserRole>().HasKey(r => new { UserId = r.UserId, RoleId = r.RoleId }).ToTable("UserRoles");
        }

        public bool Seed(AdminContext context)
        {
            bool success = false;
            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            if (!roleManager.RoleExists("Super Admin"))
            {
                success = this.CreateRole(roleManager, "Super Admin", "Rapid Sale Autority");
            }
            if (!success == true) return false;
            if (!roleManager.RoleExists("Admin"))
            {
                success = this.CreateRole(roleManager, "Admin", "Edit existing records");
            }
                
            if (!success == true) return false;

            if (!roleManager.RoleExists("User"))
            {
                success = this.CreateRole(roleManager, "User", "Restricted to business domain activity");
            }
            if (!success) return false;
            

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser();
            var passwordHasher = new PasswordHasher();

            user.UserName = "Admin";
            user.FullName = "Philip";

            
            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                IdentityResult result = userManager.Create(user, "Philip@123");
            }

            //success = this.AddUserToRole(userManager, user.Id, "Admin");
            //if (!success) return false;

            success = this.AddUserToRole(userManager, user.Id, "Super Admin");
            if (!success) return false;

            //success = this.AddUserToRole(userManager, user.Id, "User");
            //if (!success) return false;

            return true;
        }

        public bool CreateRole(ApplicationRoleManager _roleManager, string name, string description = "")
        {
            var idResult = _roleManager.Create<ApplicationRole, string>(new ApplicationRole(name, description));
            return idResult.Succeeded;
        }

        public bool AddUserToRole(ApplicationUserManager _userManager, string userId, string roleName)
        {
            var idResult = _userManager.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }

        //public class DropCreateAlwaysInitializer : DropCreateDatabaseAlways<EasyContext>
        //{
        //    protected override void Seed(EasyContext context)
        //    {
        //        context.Seed(context);

        //        base.Seed(context);
        //    }
        //}
    }
    
}
