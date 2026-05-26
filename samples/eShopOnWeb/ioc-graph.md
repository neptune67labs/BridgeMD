# IoC Graph

| Project | Interface | Implementation | Lifetime | Location |
| --- | --- | --- | --- | --- |
| `BlazorAdmin` | `BlazorAdmin.Services.CatalogItemService` | `BlazorAdmin.Services.CatalogItemService` | `AddScoped` | `ServicesConfiguration.cs` |
| `BlazorAdmin` | `BlazorAdmin.Services.CatalogLookupDataService<BlazorShared.Models.CatalogBrand, BlazorShared.Models.CatalogBrandResponse>` | `BlazorAdmin.Services.CatalogLookupDataService<BlazorShared.Models.CatalogBrand, BlazorShared.Models.CatalogBrandResponse>` | `AddScoped` | `ServicesConfiguration.cs` |
| `BlazorAdmin` | `BlazorAdmin.Services.CatalogLookupDataService<BlazorShared.Models.CatalogType, BlazorShared.Models.CatalogTypeResponse>` | `BlazorAdmin.Services.CatalogLookupDataService<BlazorShared.Models.CatalogType, BlazorShared.Models.CatalogTypeResponse>` | `AddScoped` | `ServicesConfiguration.cs` |
| `BlazorAdmin` | `BlazorAdmin.Services.HttpService` | `BlazorAdmin.Services.HttpService` | `AddScoped` | `Program.cs` |
| `BlazorAdmin` | `BlazorAdmin.Services.ToastService` | `BlazorAdmin.Services.ToastService` | `AddScoped` | `Program.cs` |
| `BlazorAdmin` | `BlazorShared.Interfaces.ICatalogItemService` | `BlazorAdmin.Services.CachedCatalogItemServiceDecorator` | `AddScoped` | `ServicesConfiguration.cs` |
| `BlazorAdmin` | `BlazorShared.Interfaces.ICatalogLookupDataService<BlazorShared.Models.CatalogBrand>` | `BlazorAdmin.Services.CachedCatalogLookupDataServiceDecorator<BlazorShared.Models.CatalogBrand, BlazorShared.Models.CatalogBrandResponse>` | `AddScoped` | `ServicesConfiguration.cs` |
| `BlazorAdmin` | `BlazorShared.Interfaces.ICatalogLookupDataService<BlazorShared.Models.CatalogType>` | `BlazorAdmin.Services.CachedCatalogLookupDataServiceDecorator<BlazorShared.Models.CatalogType, BlazorShared.Models.CatalogTypeResponse>` | `AddScoped` | `ServicesConfiguration.cs` |
| `PublicApi` | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IAppLogger<>` | `Microsoft.eShopWeb.Infrastructure.Logging.LoggerAdapter<>` | `AddScoped` | `Program.cs` |
| `PublicApi` | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IReadRepository<>` | `Microsoft.eShopWeb.Infrastructure.Data.EfRepository<>` | `AddScoped` | `Program.cs` |
| `PublicApi` | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<>` | `Microsoft.eShopWeb.Infrastructure.Data.EfRepository<>` | `AddScoped` | `Program.cs` |
| `PublicApi` | `Microsoft.eShopWeb.ApplicationCore.Interfaces.ITokenClaimsService` | `Microsoft.eShopWeb.Infrastructure.Identity.IdentityTokenClaimService` | `AddScoped` | `Program.cs` |
| `PublicApi` | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IUriComposer` | `UriComposer` | `AddSingleton` | `Program.cs` |
| `Web` | `BlazorAdmin.Services.HttpService` | `BlazorAdmin.Services.HttpService` | `AddScoped` | `Program.cs` |
| `Web` | `BlazorAdmin.Services.ToastService` | `BlazorAdmin.Services.ToastService` | `AddScoped` | `Program.cs` |
| `Web` | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IAppLogger<>` | `Microsoft.eShopWeb.Infrastructure.Logging.LoggerAdapter<>` | `AddScoped` | `ConfigureCoreServices.cs` |
| `Web` | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketQueryService` | `Microsoft.eShopWeb.Infrastructure.Data.Queries.BasketQueryService` | `AddScoped` | `ConfigureCoreServices.cs` |
| `Web` | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketService` | `Microsoft.eShopWeb.ApplicationCore.Services.BasketService` | `AddScoped` | `ConfigureCoreServices.cs` |
| `Web` | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IEmailSender` | `Microsoft.eShopWeb.Infrastructure.Services.EmailSender` | `AddTransient` | `ConfigureCoreServices.cs` |
| `Web` | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IOrderService` | `Microsoft.eShopWeb.ApplicationCore.Services.OrderService` | `AddScoped` | `ConfigureCoreServices.cs` |
| `Web` | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IReadRepository<>` | `Microsoft.eShopWeb.Infrastructure.Data.EfRepository<>` | `AddScoped` | `ConfigureCoreServices.cs` |
| `Web` | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<>` | `Microsoft.eShopWeb.Infrastructure.Data.EfRepository<>` | `AddScoped` | `ConfigureCoreServices.cs` |
| `Web` | `Microsoft.eShopWeb.ApplicationCore.Interfaces.ITokenClaimsService` | `Microsoft.eShopWeb.Infrastructure.Identity.IdentityTokenClaimService` | `AddScoped` | `Program.cs` |
| `Web` | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IUriComposer` | `UriComposer` | `AddSingleton` | `ConfigureCoreServices.cs` |
| `Web` | `Microsoft.eShopWeb.Web.Configuration.RevokeAuthenticationEvents` | `Microsoft.eShopWeb.Web.Configuration.RevokeAuthenticationEvents` | `AddScoped` | `ConfigureCookieSettings.cs` |
| `Web` | `Microsoft.eShopWeb.Web.Interfaces.IBasketViewModelService` | `Microsoft.eShopWeb.Web.Services.BasketViewModelService` | `AddScoped` | `ConfigureWebServices.cs` |
| `Web` | `Microsoft.eShopWeb.Web.Interfaces.ICatalogItemViewModelService` | `Microsoft.eShopWeb.Web.Services.CatalogItemViewModelService` | `AddScoped` | `ConfigureWebServices.cs` |
| `Web` | `Microsoft.eShopWeb.Web.Services.CatalogViewModelService` | `Microsoft.eShopWeb.Web.Services.CatalogViewModelService` | `AddScoped` | `ConfigureWebServices.cs` |
| `Web` | `Microsoft.eShopWeb.Web.Services.ICatalogViewModelService` | `Microsoft.eShopWeb.Web.Services.CachedCatalogViewModelService` | `AddScoped` | `ConfigureWebServices.cs` |
