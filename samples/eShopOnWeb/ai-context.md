# AI Context

## Inferred Architecture

- `CQRS`
- `Clean Architecture`
- `IoC / DI`
- `Layered Architecture`
- `MVC/API`
- `MediatR`
- `Repository pattern`

## Detected Layers

- `API`: 40 types; projects `PublicApi`, `Web`
- `Application`: 33 types; projects `ApplicationCore`, `Infrastructure`, `Web`
- `Domain`: 13 types; projects `ApplicationCore`
- `Infrastructure`: 25 types; projects `Infrastructure`
- `Tests`: 45 types; projects `FunctionalTests`, `IntegrationTests`, `PublicApiIntegrationTests`, `UnitTests`
- `UI`: 97 types; projects `BlazorAdmin`, `BlazorShared`, `Web`

## Detected Conventions

- Services terminate in `Service` (27).
- Repositories terminate in `Repository` (10).
- DTOs terminate in `Dto` (3).
- View models terminate in `ViewModel` (34).
- ASP.NET controllers terminate in `Controller` (6).
- Specifications terminate in `Specification` (12).
- Handlers terminate in `Handler` (2).
- Async methods use `Async` suffix (31).

## Risk Areas

- `Microsoft.eShopWeb.Infrastructure.Data.CatalogContext`: `DbContext`, `Entity Framework`
- `Microsoft.eShopWeb.Infrastructure.Identity.AppIdentityDbContext`: `DbContext`, `Entity Framework`
- `Microsoft.eShopWeb.Infrastructure.Identity.AppIdentityDbContextSeed`: `DbContext`, `Entity Framework`
- `Microsoft.eShopWeb.Infrastructure.Identity.IdentityTokenClaimService`: `Service`
- `Microsoft.eShopWeb.Infrastructure.Identity.Migrations.AppIdentityDbContextModelSnapshot`: `DbContext`, `Entity Framework`
- `Microsoft.eShopWeb.PublicApi.Middleware.ExceptionMiddleware`: `Middleware`
- `Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate.PaymentMethod`: none
- `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.LoginModel`: none
- `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.RegisterModel`: none
- `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.LogoutModel`: none
- `BlazorShared.Authorization.UserInfo`: none
- `Microsoft.eShopWeb.Web.Areas.Identity.IdentityHostingStartup`: none
- `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.ConfirmEmailModel`: none
- `Microsoft.eShopWeb.Web.Configuration.RevokeAuthenticationEvents`: none
- `BlazorShared.Authorization.ClaimValue`: none
- `BlazorShared.Authorization.Constants`: none
- `BlazorShared.Authorization.Constants.Roles`: none
- `Microsoft.eShopWeb.ApplicationCore.Constants.AuthorizationConstants`: none
- `Microsoft.eShopWeb.Infrastructure.Identity.ApplicationUser`: none
- `Microsoft.eShopWeb.Infrastructure.Identity.UserNotFoundException`: none

## Detected Frameworks And Technologies

- `ASP.NET Controllers`
- `ASP.NET Core`
- `AutoMapper`
- `Blazor`
- `CQRS`
- `Entity Framework`
- `Entity Framework Core`
- `MediatR`
- `Unity IoC`

## Priority Types For AI

| Type | Role | Score | Layer | Why |
| --- | --- | ---: | --- | --- |
| `BlazorAdmin.Services.CatalogItemService` | ApplicationService | 100 | UI | role ApplicationService; patterns Service; 3 semantic deps |
| `BlazorShared.Interfaces.ICatalogItemService` | ApplicationService | 100 | UI | role ApplicationService; patterns Service |
| `Microsoft.eShopWeb.ApplicationCore.Services.BasketService` | ApplicationService | 100 | Application | role ApplicationService; patterns Service; 2 semantic deps |
| `Microsoft.eShopWeb.ApplicationCore.Services.OrderService` | ApplicationService | 100 | Application | role ApplicationService; patterns Service; 4 semantic deps |
| `Microsoft.eShopWeb.FunctionalTests.Web.Controllers.AccountControllerSignIn` | Controller | 100 | Tests | role Controller; patterns Controller; tech ASP.NET Controllers; 1 semantic deps |
| `Microsoft.eShopWeb.FunctionalTests.Web.Controllers.CatalogControllerIndex` | Controller | 100 | Tests | role Controller; patterns Controller; tech ASP.NET Controllers; 1 semantic deps |
| `Microsoft.eShopWeb.Infrastructure.Data.CatalogContext` | DbContext | 100 | Infrastructure | role DbContext; patterns DbContext; tech Entity Framework; 8 semantic deps; dangerous zone |
| `Microsoft.eShopWeb.Infrastructure.Identity.AppIdentityDbContext` | DbContext | 100 | Infrastructure | role DbContext; patterns DbContext; tech Entity Framework; 1 semantic deps; dangerous zone |
| `Microsoft.eShopWeb.Infrastructure.Identity.AppIdentityDbContextSeed` | DbContext | 100 | Infrastructure | role DbContext; patterns DbContext; tech Entity Framework; dangerous zone |
| `Microsoft.eShopWeb.Infrastructure.Identity.IdentityTokenClaimService` | ApplicationService | 100 | Infrastructure | role ApplicationService; patterns Service; dangerous zone |
| `Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints.CatalogBrandListEndpoint` | Endpoint | 100 | API | role Endpoint; patterns Repository |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CatalogItemGetByIdEndpoint` | Endpoint | 100 | API | role Endpoint; patterns Repository; 1 semantic deps |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CatalogItemListPagedEndpoint` | Endpoint | 100 | API | role Endpoint; patterns Repository; 1 semantic deps |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemEndpoint` | Endpoint | 100 | API | role Endpoint; patterns Repository; 1 semantic deps |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.DeleteCatalogItemEndpoint` | Endpoint | 100 | API | role Endpoint; patterns Repository |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.UpdateCatalogItemEndpoint` | Endpoint | 100 | API | role Endpoint; patterns Repository; 1 semantic deps |
| `Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints.CatalogTypeListEndpoint` | Endpoint | 100 | API | role Endpoint; patterns Repository |
| `Microsoft.eShopWeb.Web.Controllers.ManageController` | Controller | 100 | API | role Controller; patterns Controller; tech ASP.NET Controllers; 2 semantic deps |
| `Microsoft.eShopWeb.Web.Controllers.OrderController` | Controller | 100 | API | role Controller; patterns Controller; tech ASP.NET Controllers; 1 semantic deps |
| `Microsoft.eShopWeb.Web.Controllers.UserController` | Controller | 100 | API | role Controller; patterns Controller; tech ASP.NET Controllers; 1 semantic deps |
| `BlazorAdmin.Services.CachedCatalogItemServiceDecorator` | Decorator | 99 | UI | role Decorator; patterns Service; 2 semantic deps |
| `BlazorAdmin.Services.HttpService` | ApplicationService | 99 | UI | role ApplicationService; patterns Service; 1 semantic deps |
| `Microsoft.eShopWeb.Web.Controllers.Api.BaseApiController` | Controller | 98 | API | role Controller; patterns Controller; tech ASP.NET Controllers |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketService` | ApplicationService | 96 | Application | role ApplicationService; patterns Service |
| `Microsoft.eShopWeb.Infrastructure.Data.Queries.BasketQueryService` | ApplicationService | 93 | Application | role ApplicationService; patterns Service; 1 semantic deps |
| `BlazorAdmin.Services.ToastService` | ApplicationService | 92 | UI | role ApplicationService; patterns Service |
| `Microsoft.eShopWeb.Infrastructure.Data.EfRepository<T>` | Repository | 91 | Infrastructure | role Repository; patterns Repository; 1 semantic deps |
| `BlazorAdmin.Services.CatalogLookupDataService<TLookupData, TReponse>` | ApplicationService | 90 | UI | role ApplicationService; patterns Service |
| `BlazorAdmin.ServicesConfiguration` | ApplicationService | 90 | UI | role ApplicationService; patterns Service |
| `BlazorShared.Interfaces.ICatalogLookupDataService<TLookupData>` | ApplicationService | 90 | UI | role ApplicationService; patterns Service |
