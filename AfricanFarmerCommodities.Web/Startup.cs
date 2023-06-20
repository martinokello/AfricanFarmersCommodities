using AfricanFarmerCommodities.DataAccess;
using AfricanFarmersCommodities.Domain;
using AfricanFarmerCommodities.UnitOfWork.Concretes;
using AfricanFarmerCommodities.UnitOfWork.Interfaces;
using AfricanFarmerCommodities.Web.Data;
using AfricanFarmerCommodities.Web.Models;
using AfricanFarmerCommodities.Web.ViewModels;
using AfricanFarmersCommodities.AppConfigurations;
using AfricanFarmersCommodities.Services;
using AfricanFarmersCommodities.Services.EmailServices.Concretes;
using AfricanFarmersCommodities.Services.EmailServices.Interfaces;
using AfricanFarmersCommodities.Services.RepositoryServices.Concretes;
using AutoMapper;
using BLG.Business;
using BLG.Business.Concretes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PaymentGateway;
using PaypalFacility;
using SimbaToursEastAfrica.Services.RepositoryServices.Abstracts;
using SimbaToursEastAfrica.Services.RepositoryServices.Concretes;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using ZNetCS.AspNetCore.Authentication.Basic;
using AfricanFarmersCommodities.Web.IdentityServices;
using AfricanFarmerCommodities.Domain;
using AfricanFarmerCommodities.Web.IdentityServices;
using AesCryptoSystemExtra.AESCryptoSystem.ExternalCryptoUnit;
using ExcelAccessDataEngine.Concretes;
using SimbaToursEastAfrica.Caching.Interfaces;
using SimbaToursEastAfrica.Caching.Concretes;

namespace AfricanFarmersCommodities.Web
{
    public class RoleInitializationMiddleware
    {
        public async Task Invoke(HttpContext context)
        {
            var rolesInitializer = context.RequestServices.GetService<InitializeDatabaseRoles>();
            await rolesInitializer.CreateRolesAsync();
        }
    }
    public class InitializeDatabaseRoles
    {
        private readonly IServiceProvider _serviceProvider;
        public InitializeDatabaseRoles(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task CreateRolesAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                UserService _userService = scope.ServiceProvider.GetService<IUserService>() as UserService;
                RoleService _roleService = scope.ServiceProvider.GetService<IRoleService>() as RoleService;
                var dbContext = scope.ServiceProvider.GetService<AfricanFarmerCommoditiesDBContext>();

                //var tableName = dbContext.Model.GetEntityTypes().First().GetTableName();
                // dbContext.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {tableName} ON");
                var serviceEndPoint = scope.ServiceProvider.GetService<ServicesEndPoint.GeneralSevices.ServicesEndPoint>();
                var vehCategories =  await serviceEndPoint.GetAllVehicleCategories();
                if (!vehCategories.Any())
                {
                    string[] cats = {"car", "Taxi", "Bus", "Minibus", "PickupTruck", "Truck", "Tram", "Train","Air", "Ship"};

                    foreach(string catg in cats)
                    {
                        await serviceEndPoint.PostCreateVehicleCategory(new VehicleCategory { DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Description = $"{catg} - Vehicle Type", VehicleCategoryName = catg });
                    }
                }
                
                var adminRole = new Role();
                adminRole.RoleName = "Administrator";
                UserInteractionResults result = UserInteractionResults.Failed;

                if (await _roleService.FindByNameAsync(adminRole.RoleName) == null)
                {
                     result = await _roleService.CreateAsync(adminRole);
                }
                if (await _roleService.FindByNameAsync("StandardUser") == null)
                {
                    var standardUser = new Role();
                    standardUser.RoleName = "StandardUser";
                    result = await _roleService.CreateAsync(standardUser);
                }
                if (await _roleService.FindByNameAsync("Guest")== null)
                {
                    var roleGuest = new Role();
                    roleGuest.RoleName = "Guest";
                    result = await _roleService.CreateAsync(roleGuest);
                }
                if (await _roleService.FindByNameAsync("Farmer") == null)
                {
                    var farmer = new Role();
                    farmer.RoleName = "Farmer";
                    result = await _roleService.CreateAsync(farmer);
                }
                if (await _roleService.FindByNameAsync("Wholesaler") == null)
                {
                    var wholesaler = new Role();
                    wholesaler.RoleName = "Wholesaler";
                    result = await _roleService.CreateAsync(wholesaler);
                }
                if (await _roleService.FindByNameAsync("Driver") == null)
                {
                    var driver = new Role();
                    driver.RoleName = "Driver";
                    result = await _roleService.CreateAsync(driver);
                }
                if (await _roleService.FindByNameAsync("Retailer") == null)
                {
                    var retailer = new Role();
                    retailer.RoleName = "Retailer";
                    result = await _roleService.CreateAsync(retailer);
                }
                if (await _roleService.FindByNameAsync("Government") == null)
                {
                    var roleGuest = new Role();
                    roleGuest.RoleName = "Government";
                    result = await _roleService.CreateAsync(roleGuest);
                }
                var defaultAddress = new Address { AddressLine1 = "MartinLayooInc Software Ltd.", AddressLine2 = "Unit 3, 2 St. Johns Terrace", Country = "United Kingdom", PostCode = "W10", PhoneNumber = "07809773365", Town = "London", DateCreated = DateTime.Now, DateUpdated = DateTime.Now };
                await serviceEndPoint.CreateAddress(defaultAddress);
                var locationDefault = new Location { LocationName = "MartinLayooInc HQ", AddressId = defaultAddress.AddressId, DateCreated = DateTime.Now, DateUpdated = DateTime.Now };
                await serviceEndPoint.CreateLocation(locationDefault);
                var companyDefault = new Company { CompanyName = "MartinLayooInc Software", CompanyPhoneNUmber = "07809773365", DateCreated = DateTime.Now, DateUpdated = DateTime.Now, LocationId = locationDefault.LocationId};
                await serviceEndPoint.CreateCompany(companyDefault);
                
                var user = new User();
                user.Username = "administrator@martinlayooinc.com";
                user.Email = "administrator@martinlayooinc.com";
                user.MobileNumber = "07809773365";
                user.FirstName = "Administrator";
                user.LastName = "Administrator";
                user.IsActive = true;
                user.IsLockedOut = false;
                user.CompanyId = companyDefault.CompanyId;

                string userPWD = "d3lt4X!505";

                var userChecked = await _userService.FindByEmailAsync(user.Email);
                if (userChecked == null)
                {
                    UserInteractionResults chkUser = await _userService.CreateAsync(user, userPWD);
                }
                var userRoles = _roleService.GetAllUserRolesAsString(user.Username);
                if (!userRoles.Any() || !userRoles.Where(r => r.ToLower().Equals(adminRole.RoleName.ToLower())).Any())
                {
                    await _userService.AddToRoleAsync(user, adminRole.RoleName);
                }
            }
        }

    }
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static async Task ValidateAsync(CookieValidatePrincipalContext context)
        {
            context = context ?? throw new ArgumentNullException(nameof(context));

            String username = context.Principal.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Email)?.Value;

            if (username == null)
            {
                context.RejectPrincipal();
                await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return;
            }

            AfricanFarmerCommoditiesDBContext dbContext = context.HttpContext.RequestServices.GetRequiredService<AfricanFarmerCommoditiesDBContext>();
            User user = await dbContext.Users.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(username.ToLower()));

            if (user == null)
            {
                context.RejectPrincipal();
                await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return;
            }
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddAuthentication(options => { options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme; })
                .AddCookie("Cookies", config =>
            {
                config.Cookie.SameSite = SameSiteMode.Lax;
                config.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                config.LoginPath = "/Account/Login";
                config.Cookie.Name = "LoginCookieAuth";
                config.Cookie.HttpOnly = false;
                config.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                config.Cookie.IsEssential = true;
                config.SlidingExpiration = true;
                //config.Events.OnValidatePrincipal = ValidateAsync;
            });
            services.AddAuthorization(config =>
            {
               /* config.AddPolicy("IsAdministrator", options => options.RequireClaim(ClaimTypes.Role, "Administrator")); ;
                config.AddPolicy("IsGuest", options => options.RequireClaim(ClaimTypes.Role, "Guest", "Administrator"));
                config.AddPolicy("IsRetailer", options => options.RequireClaim(ClaimTypes.Role, "Retailer", "Administrator"));
                config.AddPolicy("IsStandardUser", options => options.RequireClaim(ClaimTypes.Role, "StandardUser", "Administrator"));
                config.AddPolicy("IsWholesaler", options => options.RequireClaim(ClaimTypes.Role, "Wholesaler", "Administrator"));
                config.AddPolicy("IsFarmer", options => options.RequireClaim(ClaimTypes.Role, "Farmer", "Administrator"));
                config.AddPolicy("IsGovernment", options => options.RequireClaim(ClaimTypes.Role, "Government", "Administrator"));
                config.AddPolicy("IsDriver", options => options.RequireClaim(ClaimTypes.Role, "Driver", "Administrator")); */  
            });
            services.AddMvc().AddNewtonsoftJson(options =>
            {
                options.UseCamelCasing(true);
            });

            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = true).
                AddNewtonsoftJson(options => options.UseCamelCasing(true))
                .AddXmlDataContractSerializerFormatters();
            services.AddDistributedMemoryCache();

            var connectionString = Configuration.GetConnectionString("AfricanFarmersConnection");

            services.AddDbContext<AfricanFarmerCommoditiesDBContext>(options =>
            {
                options.UseSqlServer(connectionString, b =>
                {
                    b.MigrationsAssembly("AfricanFarmerCommodities.Web");
                    b.EnableRetryOnFailure();
                });
            });

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(15);
                options.Cookie.HttpOnly = true;
            });
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            var mapperConfiguration = new MapperConfiguration((conf) =>
            {
                conf.CreateMap<CommodityViewModel, Commodity>();
                conf.CreateMap<CommodityViewModel, Commodity>().ReverseMap();

                conf.CreateMap<CommodityCategoryViewModel, CommodityCategory>();
                conf.CreateMap<CommodityCategoryViewModel, CommodityCategory>().ReverseMap();

                conf.CreateMap<CompanyViewModel, Company>();
                conf.CreateMap<CompanyViewModel, Company>().ReverseMap();

                conf.CreateMap<LocationViewModel, Location>();
                conf.CreateMap<LocationViewModel, Location>().ReverseMap();

                conf.CreateMap<CommodityUnitViewModel, CommodityUnit>();
                conf.CreateMap<CommodityUnitViewModel, CommodityUnit>().ReverseMap();

                conf.CreateMap<FarmerViewModel, Farmer>();
                conf.CreateMap<FarmerViewModel, Farmer>().ReverseMap();

                conf.CreateMap<FarmerInsertViewModel, Farmer>();
                conf.CreateMap<FarmerInsertViewModel, Farmer>().ReverseMap();

                conf.CreateMap<AddressViewModel, Address>();
                conf.CreateMap<AddressViewModel, Address>().ReverseMap();

                conf.CreateMap<DriverViewModel, Driver>();
                conf.CreateMap<DriverViewModel, Driver>().ReverseMap();

                conf.CreateMap<VehicleViewModel, Vehicle>();
                conf.CreateMap<VehicleViewModel, Vehicle>().ReverseMap();

                conf.CreateMap<VehicleInsertViewModel, Vehicle>();
                conf.CreateMap<VehicleInsertViewModel, Vehicle>().ReverseMap();

                conf.CreateMap<VehicleCapacityViewModel, VehicleCapacity>();
                conf.CreateMap<VehicleCapacityViewModel, VehicleCapacity>().ReverseMap();

                conf.CreateMap<VehicleCategoryViewModel, VehicleCategory>();
                conf.CreateMap<VehicleCategoryViewModel, VehicleCategory>().ReverseMap();

                conf.CreateMap<IntermediateScheduleViewModel, IntermediateSchedule>();
                conf.CreateMap<IntermediateScheduleViewModel, IntermediateSchedule>().ReverseMap();

                conf.CreateMap<FoodHubViewModel, FoodHub>();
                conf.CreateMap<FoodHubViewModel, FoodHub>().ReverseMap();

                conf.CreateMap<FoodHubStorageViewModel, FoodHubStorage>();
                conf.CreateMap<FoodHubStorageViewModel, FoodHubStorage>().ReverseMap();

                conf.CreateMap<DriverViewModel, Driver>();
                conf.CreateMap<DriverViewModel, Driver>().ReverseMap();

                conf.CreateMap<TransportPricingViewModel, TransportPricing>();
                conf.CreateMap<TransportPricingViewModel, TransportPricing>().ReverseMap();

                conf.CreateMap<TransportScheduleViewModel, TransportSchedule>();
                conf.CreateMap<TransportScheduleViewModel, TransportSchedule>().ReverseMap();

                conf.CreateMap<ActiveEnrouteCommodityMonitorViewModel, ActiveEnrouteCommodityMonitor>();
                conf.CreateMap<ActiveEnrouteCommodityMonitorViewModel, ActiveEnrouteCommodityMonitor>().ReverseMap();
                
                conf.CreateMap<FoodHubStorageViewModel, FoodHubStorage>();
                conf.CreateMap<FoodHubStorageViewModel, FoodHubStorage>().ReverseMap();

                conf.CreateMap<TransportLogViewModel, TransportLog>();
                conf.CreateMap<TransportLogViewModel, TransportLog>().ReverseMap(); 


                conf.CreateMap<TransportLogViewModel, TransportLog>();
                conf.CreateMap<TransportLogViewModel, TransportLog>().ReverseMap();

                conf.CreateMap<DriverSchedulesNoteViewModle, DriverSchedulesNote>();
                conf.CreateMap<DriverSchedulesNoteViewModle, DriverSchedulesNote>().ReverseMap();

                conf.CreateMap<InvoiceViewModel, AfricanFarmersCommodities.Domain.Invoice>();
                conf.CreateMap<InvoiceViewModel, AfricanFarmersCommodities.Domain.Invoice > ().ReverseMap();
            });

            var httpClient = new BGLHttpClient();
            httpClient.HttpRequestClient = new HttpClient();

            var masterkeyDirPath = $"{Directory.GetCurrentDirectory()}\\Master";
            var paypalSettings = Configuration.GetSection("ApplicationConstants");
            services.AddScoped<PayPalHandler>(pHandle => new PayPalHandler(paypalSettings.GetSection("PaypalBaseUrl").Value,
              paypalSettings.GetSection("BusinessEmail").Value, paypalSettings.GetSection("SuccessUrl").Value, paypalSettings.GetSection("CancelUrl").Value,
              paypalSettings.GetSection("NotifyUrl").Value, ""));
            services.AddScoped<ExcelEngine>();
            services.AddScoped<PaymentsManager>();
            services.AddScoped<Mapper>(map => new Mapper(mapperConfiguration));
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<AesExternalProcedures>(s => new AesExternalProcedures(masterkeyDirPath));
            services.AddScoped<AppSettingsConfigurations>();
            services.AddScoped<DbContext, AfricanFarmerCommoditiesDBContext>();
            services.AddScoped<IMailService, EmailService>(smtp=> new EmailService(Configuration));
            services.AddScoped<AfricanFarmerCommoditiesUnitOfWork>();
            services.AddTransient<BLGLocationWeatherRequests>(weatherReq => new BLGLocationWeatherRequests(httpClient, new AppSettingsConfigurations(Configuration).GetConfigSetting("OpenWeatherMapAPIKey")));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<AbstractRepository<Address>, AddressRepository>();
            services.AddScoped<AbstractRepository<Driver>, DriverRepository>();
            services.AddScoped<AbstractRepository<AfricanFarmersCommodities.Domain.Invoice>, InvoiceRepository>();
            services.AddScoped<AbstractRepository<Item>, ItemRepository>();
            services.AddScoped<AbstractRepository<Location>, LocationRepository>();
            services.AddScoped<AbstractRepository<Vehicle>, VehicleRepository>();
            services.AddScoped<AbstractRepository<IntermediateSchedule>, IntermediateScheduleRepository>();
            services.AddScoped<AbstractRepository<DealsPricing>, DealsPricingRepository>();
            services.AddScoped<AbstractRepository<TransportPricing>, TransportPricingRepository>();
            services.AddScoped<AbstractRepository<Role>, RolesRepository>();
            services.AddScoped<AbstractRepository<User>, UserRepository>();
            services.AddScoped<AbstractRepository<UserRole>, UserInRolesRepository>();
            services.AddScoped<AbstractRepository<VehicleCapacity>, VehicleCapacityRepository>();
            services.AddScoped<AbstractRepository<VehicleCategory>, VehicleCategoryRepository>();
            services.AddScoped<AbstractRepository<FoodHubStorage>, FoodHubStorageRepository>();
            services.AddScoped<AbstractRepository<FoodHub>, FoodHubRepository>();
            services.AddScoped<AbstractRepository<Farmer>, FarmerRepository>();
            services.AddScoped<AbstractRepository<CommodityUnit>, CommodityUnitRepository>();
            services.AddScoped<AbstractRepository<Commodity>, CommodityRepository>();
            services.AddScoped<AbstractRepository<CommodityCategory>, CommodityCategoryRepository>();
            services.AddScoped<AbstractRepository<ActiveEnrouteCommodityMonitor>, ActiveEnrouteCommodityMonitorRepository>();
            services.AddScoped<AbstractRepository<TransportSchedule>, TransportScheduleRepository>();
            services.AddScoped<AbstractRepository<Company>, CompanyRepository>();
            services.AddScoped<AbstractRepository<DriverSchedulesNote>, DriverSchedulesNotesRepository>();
            services.AddScoped<AbstractRepository<TransportLog>, TransportLogRepository>();
            services.AddSingleton<ICaching, SimbaToursEastAfricaCahing>(); 
            services.AddScoped<ServicesEndPoint.GeneralSevices.ServicesEndPoint, ServicesEndPoint.GeneralSevices.ServicesEndPoint>();
            services.AddScoped<InitializeDatabaseRoles>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UsePathBase("/africanfarmerscommodities");

            //app.UseSession();

            app.Use((context, next) =>
            {
                context.Request.PathBase = "/africanfarmerscommodities";
                return next();
            });


            app.Use((context, next) =>
            {
                context.Request.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Request.Headers.Add("Access-Control-Allow-Methods", "GET , PUT , POST , DELETE");
                context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, x-requested-with");
                return next(); // Important
            });
            //Initialize Roles:
            var initRoles = new RoleInitializationMiddleware();
            app.Use((context, next) =>
            {
                initRoles.Invoke(context).ConfigureAwait(true).GetAwaiter().GetResult();
                return next();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }
            app.UseRouting();
            app.UseCors("CorsPolicy"); 

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501
                var path = Path.Combine(Directory.GetCurrentDirectory(), "ClientApp");
                spa.Options.SourcePath = path;

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
