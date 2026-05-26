# Hotspots

## Highest Risk Areas

| Type | Risk | Score | Fan-in | Fan-out | Size | Reasons |
| --- | --- | ---: | ---: | ---: | ---: | --- |
| `Microsoft.eShopWeb.Infrastructure.Data.CatalogContext` | HIGH | 85 | 6 | 8 | 19 | `fan-in 6`, `high fan-out 8`, `dangerous zone`, `critical role DbContext`, `central technology boundary` |
| `Microsoft.eShopWeb.Infrastructure.Identity.AppIdentityDbContext` | MEDIUM | 45 | 1 | 1 | 15 | `dangerous zone`, `critical role DbContext`, `central technology boundary` |
| `Microsoft.eShopWeb.Infrastructure.Identity.AppIdentityDbContextSeed` | MEDIUM | 45 | 0 | 0 | 25 | `dangerous zone`, `critical role DbContext`, `central technology boundary` |
| `Microsoft.eShopWeb.Infrastructure.Identity.Migrations.AppIdentityDbContextModelSnapshot` | MEDIUM | 57 | 0 | 0 | 260 | `260 LOC`, `dangerous zone`, `critical role DbContext`, `central technology boundary` |
| `Microsoft.eShopWeb.Infrastructure.Data.Migrations.CatalogContextModelSnapshot` | LOW | 32 | 0 | 0 | 300 | `300 LOC`, `dangerous zone` |
| `Microsoft.eShopWeb.Infrastructure.Data.Migrations.InitialModel` | LOW | 32 | 0 | 0 | 201 | `201 LOC`, `dangerous zone` |
| `Microsoft.eShopWeb.Infrastructure.Identity.Migrations.InitialIdentityModel` | LOW | 32 | 0 | 0 | 213 | `213 LOC`, `dangerous zone` |
| `Microsoft.eShopWeb.PublicApi.Middleware.ExceptionMiddleware` | LOW | 35 | 0 | 0 | 45 | `dangerous zone`, `critical role Middleware` |
| `Microsoft.eShopWeb.Web.Controllers.ManageController` | MEDIUM | 60 | 1 | 2 | 536 | `21 public methods`, `536 LOC`, `critical role Controller` |

## Legacy Signals

| Type | Project | Signals |
| --- | --- | --- |
| none | none | none |

## Dangerous Zones

| Type | Project | Layer | Signals |
| --- | --- | --- | --- |
| `Microsoft.eShopWeb.Infrastructure.Data.CatalogContext` | `Infrastructure` | Infrastructure | `DbContext`, `Entity Framework` |
| `Microsoft.eShopWeb.Infrastructure.Identity.AppIdentityDbContext` | `Infrastructure` | Infrastructure | `DbContext`, `Entity Framework` |
| `Microsoft.eShopWeb.Infrastructure.Identity.AppIdentityDbContextSeed` | `Infrastructure` | Infrastructure | `DbContext`, `Entity Framework` |
| `Microsoft.eShopWeb.Infrastructure.Identity.IdentityTokenClaimService` | `Infrastructure` | Infrastructure | `Service` |
| `Microsoft.eShopWeb.Infrastructure.Identity.Migrations.AppIdentityDbContextModelSnapshot` | `Infrastructure` | Infrastructure | `DbContext`, `Entity Framework`, `Migration` |
| `Microsoft.eShopWeb.PublicApi.Middleware.ExceptionMiddleware` | `PublicApi` | API | `Middleware` |
| `Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate.PaymentMethod` | `ApplicationCore` | Domain | none |
| `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.LoginModel` | `Web` | UI | none |
| `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.RegisterModel` | `Web` | UI | none |
| `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.LogoutModel` | `Web` | UI | none |
| `BlazorShared.Authorization.UserInfo` | `BlazorShared` | UI | none |
| `Microsoft.eShopWeb.Web.Areas.Identity.IdentityHostingStartup` | `Web` | UI | none |
| `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.ConfirmEmailModel` | `Web` | UI | none |
| `Microsoft.eShopWeb.Web.Configuration.RevokeAuthenticationEvents` | `Web` | UI | none |
| `BlazorShared.Authorization.ClaimValue` | `BlazorShared` | UI | none |
| `BlazorShared.Authorization.Constants` | `BlazorShared` | UI | none |
| `BlazorShared.Authorization.Constants.Roles` | `BlazorShared` | UI | none |
| `Microsoft.eShopWeb.ApplicationCore.Constants.AuthorizationConstants` | `ApplicationCore` | Application | none |
| `Microsoft.eShopWeb.Infrastructure.Identity.ApplicationUser` | `Infrastructure` | Infrastructure | none |
| `Microsoft.eShopWeb.Infrastructure.Identity.UserNotFoundException` | `Infrastructure` | Infrastructure | none |
| `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.LoginModel.InputModel` | `Web` | UI | none |
| `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.RegisterModel.InputModel` | `Web` | UI | none |
| `Microsoft.eShopWeb.Web.ViewModels.Manage.TwoFactorAuthenticationViewModel` | `Web` | UI | `ViewModel` |
| `Microsoft.eShopWeb.Infrastructure.Data.Migrations.CatalogContextModelSnapshot` | `Infrastructure` | Infrastructure | `Migration` |
| `Microsoft.eShopWeb.Infrastructure.Data.Migrations.FixBuyerId` | `Infrastructure` | Infrastructure | `Migration` |
| `Microsoft.eShopWeb.Infrastructure.Data.Migrations.FixShipToAddress` | `Infrastructure` | Infrastructure | `Migration` |
| `Microsoft.eShopWeb.Infrastructure.Data.Migrations.InitialModel` | `Infrastructure` | Infrastructure | `Migration` |
| `Microsoft.eShopWeb.Infrastructure.Identity.Migrations.InitialIdentityModel` | `Infrastructure` | Infrastructure | `Migration` |
