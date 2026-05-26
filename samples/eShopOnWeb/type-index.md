# Type Index

## BlazorAdmin.Services.CatalogItemService

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ApplicationService |
| Layer | UI |
| Relevance | High / 100 |
| Reason | role ApplicationService; patterns Service; 3 semantic deps |
| Namespace | `BlazorAdmin.Services` |
| Project | `BlazorAdmin` |
| Base type | none |
| Interfaces | `BlazorShared.Interfaces.ICatalogItemService` |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<CatalogItem> Create(CreateCatalogItemRequest catalogItem)`
- `Task<string> Delete(int catalogItemId)`
- `Task<CatalogItem> Edit(CatalogItem catalogItem)`
- `Task<CatalogItem> GetById(int id)`
- `Task<List<CatalogItem>> List()`
- `Task<List<CatalogItem>> ListPaged(int pageSize)`

Semantic dependencies:
- `BlazorAdmin.Services.HttpService` (ConstructorInjection)
- `BlazorShared.Interfaces.ICatalogLookupDataService<BlazorShared.Models.CatalogBrand>` (ConstructorInjection)
- `BlazorShared.Interfaces.ICatalogLookupDataService<BlazorShared.Models.CatalogType>` (ConstructorInjection)

## BlazorShared.Interfaces.ICatalogItemService

| Field | Value |
| --- | --- |
| Kind | Interface |
| Role | ApplicationService |
| Layer | UI |
| Relevance | High / 100 |
| Reason | role ApplicationService; patterns Service |
| Namespace | `BlazorShared.Interfaces` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | none |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<CatalogItem> Create(CreateCatalogItemRequest catalogItem)`
- `Task<string> Delete(int id)`
- `Task<CatalogItem> Edit(CatalogItem catalogItem)`
- `Task<CatalogItem> GetById(int id)`
- `Task<List<CatalogItem>> List()`
- `Task<List<CatalogItem>> ListPaged(int pageSize)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Services.BasketService

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ApplicationService |
| Layer | Application |
| Relevance | High / 100 |
| Reason | role ApplicationService; patterns Service; 2 semantic deps |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Services` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketService` |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<Basket> AddItemToBasket(string username, int catalogItemId, decimal price, int quantity)`
- `Task DeleteBasketAsync(int basketId)`
- `Task<Result<Basket>> SetQuantities(int basketId, Dictionary<string, int> quantities)`
- `Task TransferBasketAsync(string anonymousId, string userName)`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IAppLogger<Microsoft.eShopWeb.ApplicationCore.Services.BasketService>` (ConstructorInjection)
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate.Basket>` (ConstructorInjection)

## Microsoft.eShopWeb.ApplicationCore.Services.OrderService

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ApplicationService |
| Layer | Application |
| Relevance | High / 100 |
| Reason | role ApplicationService; patterns Service; 4 semantic deps |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Services` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IOrderService` |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task CreateOrderAsync(int basketId, Address shippingAddress)`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate.Basket>` (ConstructorInjection)
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem>` (ConstructorInjection)
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Order>` (ConstructorInjection)
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IUriComposer` (ConstructorInjection)

## Microsoft.eShopWeb.FunctionalTests.Web.Controllers.AccountControllerSignIn

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Controller |
| Layer | Tests |
| Relevance | High / 100 |
| Reason | role Controller; patterns Controller; tech ASP.NET Controllers; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.FunctionalTests.Web.Controllers` |
| Project | `FunctionalTests` |
| Base type | `IClassFixture<Microsoft.eShopWeb.FunctionalTests.Web.TestApplication>` |
| Interfaces | none |
| Patterns | `Controller` |
| Technologies | `ASP.NET Controllers` |
| Summary | none |

Public methods:
- `void RegexMatchesValidRequestVerificationToken()`
- `Task ReturnsFormWithRequestVerificationToken()`
- `Task ReturnsSignInScreenOnGet()`
- `Task ReturnsSuccessfulSignInOnPostWithValidCredentials()`
- `Task UpdatePhoneNumberProfile()`

Semantic dependencies:
- `Microsoft.eShopWeb.FunctionalTests.Web.TestApplication` (ConstructorInjection)

## Microsoft.eShopWeb.FunctionalTests.Web.Controllers.CatalogControllerIndex

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Controller |
| Layer | Tests |
| Relevance | High / 100 |
| Reason | role Controller; patterns Controller; tech ASP.NET Controllers; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.FunctionalTests.Web.Controllers` |
| Project | `FunctionalTests` |
| Base type | `IClassFixture<Microsoft.eShopWeb.FunctionalTests.Web.TestApplication>` |
| Interfaces | none |
| Patterns | `Controller` |
| Technologies | `ASP.NET Controllers` |
| Summary | none |

Public methods:
- `Task ReturnsHomePageWithProductListing()`

Semantic dependencies:
- `Microsoft.eShopWeb.FunctionalTests.Web.TestApplication` (ConstructorInjection)

## Microsoft.eShopWeb.Infrastructure.Data.CatalogContext

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DbContext |
| Layer | Infrastructure |
| Relevance | High / 100 |
| Reason | role DbContext; patterns DbContext; tech Entity Framework; 8 semantic deps; dangerous zone |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Data` |
| Project | `Infrastructure` |
| Base type | `DbContext` |
| Interfaces | none |
| Patterns | `DbContext` |
| Technologies | `Entity Framework` |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- `DbContextOptions<Microsoft.eShopWeb.Infrastructure.Data.CatalogContext>` (ConstructorInjection)
- `DbSet<Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate.Basket>` (DbSet)
- `DbSet<Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate.BasketItem>` (DbSet)
- `DbSet<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogBrand>` (DbSet)
- `DbSet<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem>` (DbSet)
- `DbSet<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogType>` (DbSet)
- `DbSet<Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Order>` (DbSet)
- `DbSet<Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.OrderItem>` (DbSet)

## Microsoft.eShopWeb.Infrastructure.Identity.AppIdentityDbContext

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DbContext |
| Layer | Infrastructure |
| Relevance | High / 100 |
| Reason | role DbContext; patterns DbContext; tech Entity Framework; 1 semantic deps; dangerous zone |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Identity` |
| Project | `Infrastructure` |
| Base type | `IdentityDbContext<Microsoft.eShopWeb.Infrastructure.Identity.ApplicationUser>` |
| Interfaces | none |
| Patterns | `DbContext` |
| Technologies | `Entity Framework` |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- `DbContextOptions<Microsoft.eShopWeb.Infrastructure.Identity.AppIdentityDbContext>` (ConstructorInjection)

## Microsoft.eShopWeb.Infrastructure.Identity.AppIdentityDbContextSeed

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DbContext |
| Layer | Infrastructure |
| Relevance | High / 100 |
| Reason | role DbContext; patterns DbContext; tech Entity Framework; dangerous zone |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Identity` |
| Project | `Infrastructure` |
| Base type | none |
| Interfaces | none |
| Patterns | `DbContext` |
| Technologies | `Entity Framework` |
| Summary | none |

Public methods:
- `static Task SeedAsync(AppIdentityDbContext identityDbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Infrastructure.Identity.IdentityTokenClaimService

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ApplicationService |
| Layer | Infrastructure |
| Relevance | High / 100 |
| Reason | role ApplicationService; patterns Service; dangerous zone |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Identity` |
| Project | `Infrastructure` |
| Base type | none |
| Interfaces | `Microsoft.eShopWeb.ApplicationCore.Interfaces.ITokenClaimsService` |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<string> GetTokenAsync(string userName)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints.CatalogBrandListEndpoint

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Endpoint |
| Layer | API |
| Relevance | High / 100 |
| Reason | role Endpoint; patterns Repository |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints` |
| Project | `PublicApi` |
| Base type | `IEndpoint<Microsoft.AspNetCore.Http.IResult, Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogBrand>>` |
| Interfaces | none |
| Patterns | `Repository` |
| Technologies | none |
| Summary | List Catalog Brands |

Public methods:
- `void AddRoute(IEndpointRouteBuilder app)`
- `Task<IResult> HandleAsync(IRepository<CatalogBrand> catalogBrandRepository)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CatalogItemGetByIdEndpoint

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Endpoint |
| Layer | API |
| Relevance | High / 100 |
| Reason | role Endpoint; patterns Repository; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints` |
| Project | `PublicApi` |
| Base type | `IEndpoint<Microsoft.AspNetCore.Http.IResult, Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.GetByIdCatalogItemRequest, Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem>>` |
| Interfaces | none |
| Patterns | `Repository` |
| Technologies | none |
| Summary | Get a Catalog Item by Id |

Public methods:
- `void AddRoute(IEndpointRouteBuilder app)`
- `Task<IResult> HandleAsync(GetByIdCatalogItemRequest request, IRepository<CatalogItem> itemRepository)`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IUriComposer` (ConstructorInjection)

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CatalogItemListPagedEndpoint

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Endpoint |
| Layer | API |
| Relevance | High / 100 |
| Reason | role Endpoint; patterns Repository; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints` |
| Project | `PublicApi` |
| Base type | `IEndpoint<Microsoft.AspNetCore.Http.IResult, Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.ListPagedCatalogItemRequest, Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem>>` |
| Interfaces | none |
| Patterns | `Repository` |
| Technologies | none |
| Summary | List Catalog Items (paged) |

Public methods:
- `void AddRoute(IEndpointRouteBuilder app)`
- `Task<IResult> HandleAsync(ListPagedCatalogItemRequest request, IRepository<CatalogItem> itemRepository)`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IUriComposer` (ConstructorInjection)

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemEndpoint

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Endpoint |
| Layer | API |
| Relevance | High / 100 |
| Reason | role Endpoint; patterns Repository; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints` |
| Project | `PublicApi` |
| Base type | `IEndpoint<Microsoft.AspNetCore.Http.IResult, Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemRequest, Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem>>` |
| Interfaces | none |
| Patterns | `Repository` |
| Technologies | none |
| Summary | Creates a new Catalog Item |

Public methods:
- `void AddRoute(IEndpointRouteBuilder app)`
- `Task<IResult> HandleAsync(CreateCatalogItemRequest request, IRepository<CatalogItem> itemRepository)`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IUriComposer` (ConstructorInjection)

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.DeleteCatalogItemEndpoint

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Endpoint |
| Layer | API |
| Relevance | High / 100 |
| Reason | role Endpoint; patterns Repository |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints` |
| Project | `PublicApi` |
| Base type | `IEndpoint<Microsoft.AspNetCore.Http.IResult, Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.DeleteCatalogItemRequest, Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem>>` |
| Interfaces | none |
| Patterns | `Repository` |
| Technologies | none |
| Summary | Deletes a Catalog Item |

Public methods:
- `void AddRoute(IEndpointRouteBuilder app)`
- `Task<IResult> HandleAsync(DeleteCatalogItemRequest request, IRepository<CatalogItem> itemRepository)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.UpdateCatalogItemEndpoint

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Endpoint |
| Layer | API |
| Relevance | High / 100 |
| Reason | role Endpoint; patterns Repository; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints` |
| Project | `PublicApi` |
| Base type | `IEndpoint<Microsoft.AspNetCore.Http.IResult, Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.UpdateCatalogItemRequest, Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem>>` |
| Interfaces | none |
| Patterns | `Repository` |
| Technologies | none |
| Summary | Updates a Catalog Item |

Public methods:
- `void AddRoute(IEndpointRouteBuilder app)`
- `Task<IResult> HandleAsync(UpdateCatalogItemRequest request, IRepository<CatalogItem> itemRepository)`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IUriComposer` (ConstructorInjection)

## Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints.CatalogTypeListEndpoint

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Endpoint |
| Layer | API |
| Relevance | High / 100 |
| Reason | role Endpoint; patterns Repository |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints` |
| Project | `PublicApi` |
| Base type | `IEndpoint<Microsoft.AspNetCore.Http.IResult, Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogType>>` |
| Interfaces | none |
| Patterns | `Repository` |
| Technologies | none |
| Summary | List Catalog Types |

Public methods:
- `void AddRoute(IEndpointRouteBuilder app)`
- `Task<IResult> HandleAsync(IRepository<CatalogType> catalogTypeRepository)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Controllers.ManageController

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Controller |
| Layer | API |
| Relevance | High / 100 |
| Reason | role Controller; patterns Controller; tech ASP.NET Controllers; 2 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.Controllers` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.Controller` |
| Interfaces | none |
| Patterns | `Controller` |
| Technologies | `ASP.NET Controllers` |
| Summary | none |

Public methods:
- `Task<IActionResult> ChangePassword()`
- `Task<IActionResult> ChangePassword(ChangePasswordViewModel model)`
- `Task<IActionResult> Disable2fa()`
- `Task<IActionResult> Disable2faWarning()`
- `Task<IActionResult> EnableAuthenticator()`
- `Task<IActionResult> EnableAuthenticator(EnableAuthenticatorViewModel model)`
- `Task<IActionResult> ExternalLogins()`
- `Task<IActionResult> GenerateRecoveryCodes()`
- `Task<IActionResult> GenerateRecoveryCodesWarning()`
- `Task<IActionResult> LinkLogin(string provider)`
- `Task<IActionResult> LinkLoginCallback()`
- `Task<IActionResult> MyAccount()`
- `Task<IActionResult> MyAccount(IndexViewModel model)`
- `Task<IActionResult> RemoveLogin(RemoveLoginViewModel model)`
- `Task<IActionResult> ResetAuthenticator()`
- `IActionResult ResetAuthenticatorWarning()`
- `Task<IActionResult> SendVerificationEmail(IndexViewModel model)`
- `Task<IActionResult> SetPassword()`
- `Task<IActionResult> SetPassword(SetPasswordViewModel model)`
- `IActionResult ShowRecoveryCodes()`
- `Task<IActionResult> TwoFactorAuthentication()`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IAppLogger<Microsoft.eShopWeb.Web.Controllers.ManageController>` (ConstructorInjection)
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IEmailSender` (ConstructorInjection)

## Microsoft.eShopWeb.Web.Controllers.OrderController

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Controller |
| Layer | API |
| Relevance | High / 100 |
| Reason | role Controller; patterns Controller; tech ASP.NET Controllers; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.Controllers` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.Controller` |
| Interfaces | none |
| Patterns | `Controller` |
| Technologies | `ASP.NET Controllers` |
| Summary | none |

Public methods:
- `Task<IActionResult> Detail(int orderId)`
- `Task<IActionResult> MyOrders()`

Semantic dependencies:
- `IMediator` (ConstructorInjection)

## Microsoft.eShopWeb.Web.Controllers.UserController

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Controller |
| Layer | API |
| Relevance | High / 100 |
| Reason | role Controller; patterns Controller; tech ASP.NET Controllers; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.Controllers` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.ControllerBase` |
| Interfaces | none |
| Patterns | `Controller` |
| Technologies | `ASP.NET Controllers` |
| Summary | none |

Public methods:
- `Task<IActionResult> GetCurrentUser()`
- `Task<IActionResult> Logout()`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.ITokenClaimsService` (ConstructorInjection)

## BlazorAdmin.Services.CachedCatalogItemServiceDecorator

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Decorator |
| Layer | UI |
| Relevance | High / 99 |
| Reason | role Decorator; patterns Service; 2 semantic deps |
| Namespace | `BlazorAdmin.Services` |
| Project | `BlazorAdmin` |
| Base type | none |
| Interfaces | `BlazorShared.Interfaces.ICatalogItemService` |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<CatalogItem> Create(CreateCatalogItemRequest catalogItem)`
- `Task<string> Delete(int id)`
- `Task<CatalogItem> Edit(CatalogItem catalogItem)`
- `Task<CatalogItem> GetById(int id)`
- `Task<List<CatalogItem>> List()`
- `Task<List<CatalogItem>> ListPaged(int pageSize)`

Semantic dependencies:
- `BlazorAdmin.Services.CatalogItemService` (ConstructorInjection)
- `ILocalStorageService` (ConstructorInjection)

## BlazorAdmin.Services.HttpService

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ApplicationService |
| Layer | UI |
| Relevance | High / 99 |
| Reason | role ApplicationService; patterns Service; 1 semantic deps |
| Namespace | `BlazorAdmin.Services` |
| Project | `BlazorAdmin` |
| Base type | none |
| Interfaces | none |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<T> HttpDelete(string uri, int id)`
- `Task<T> HttpGet(string uri)`
- `Task<T> HttpPost(string uri, object dataToSend)`
- `Task<T> HttpPut(string uri, object dataToSend)`

Semantic dependencies:
- `BlazorAdmin.Services.ToastService` (ConstructorInjection)

## Microsoft.eShopWeb.Web.Controllers.Api.BaseApiController

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Controller |
| Layer | API |
| Relevance | High / 98 |
| Reason | role Controller; patterns Controller; tech ASP.NET Controllers |
| Namespace | `Microsoft.eShopWeb.Web.Controllers.Api` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.ControllerBase` |
| Interfaces | none |
| Patterns | `Controller` |
| Technologies | `ASP.NET Controllers` |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketService

| Field | Value |
| --- | --- |
| Kind | Interface |
| Role | ApplicationService |
| Layer | Application |
| Relevance | High / 96 |
| Reason | role ApplicationService; patterns Service |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Interfaces` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | none |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<Basket> AddItemToBasket(string username, int catalogItemId, decimal price, int quantity)`
- `Task DeleteBasketAsync(int basketId)`
- `Task<Result<Basket>> SetQuantities(int basketId, Dictionary<string, int> quantities)`
- `Task TransferBasketAsync(string anonymousId, string userName)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Infrastructure.Data.Queries.BasketQueryService

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ApplicationService |
| Layer | Application |
| Relevance | High / 93 |
| Reason | role ApplicationService; patterns Service; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Data.Queries` |
| Project | `Infrastructure` |
| Base type | none |
| Interfaces | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketQueryService` |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<int> CountTotalBasketItems(string username)`

Semantic dependencies:
- `Microsoft.eShopWeb.Infrastructure.Data.CatalogContext` (ConstructorInjection)

## BlazorAdmin.Services.ToastService

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ApplicationService |
| Layer | UI |
| Relevance | High / 92 |
| Reason | role ApplicationService; patterns Service |
| Namespace | `BlazorAdmin.Services` |
| Project | `BlazorAdmin` |
| Base type | none |
| Interfaces | `System.IDisposable` |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `void Dispose()`
- `void ShowToast(string message, ToastLevel level)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Infrastructure.Data.EfRepository<T>

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Repository |
| Layer | Infrastructure |
| Relevance | High / 91 |
| Reason | role Repository; patterns Repository; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Data` |
| Project | `Infrastructure` |
| Base type | `RepositoryBase<T>` |
| Interfaces | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IReadRepository<T>`, `Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<T>` |
| Patterns | `Repository` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- `Microsoft.eShopWeb.Infrastructure.Data.CatalogContext` (ConstructorInjection)

## BlazorAdmin.Services.CatalogLookupDataService<TLookupData, TReponse>

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ApplicationService |
| Layer | UI |
| Relevance | High / 90 |
| Reason | role ApplicationService; patterns Service |
| Namespace | `BlazorAdmin.Services` |
| Project | `BlazorAdmin` |
| Base type | none |
| Interfaces | `BlazorShared.Interfaces.ICatalogLookupDataService<TLookupData>` |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<List<TLookupData>> List()`

Semantic dependencies:
- none

## BlazorAdmin.ServicesConfiguration

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ApplicationService |
| Layer | UI |
| Relevance | High / 90 |
| Reason | role ApplicationService; patterns Service |
| Namespace | `BlazorAdmin` |
| Project | `BlazorAdmin` |
| Base type | none |
| Interfaces | none |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `static IServiceCollection AddBlazorServices(IServiceCollection services)`

Semantic dependencies:
- none

## BlazorShared.Interfaces.ICatalogLookupDataService<TLookupData>

| Field | Value |
| --- | --- |
| Kind | Interface |
| Role | ApplicationService |
| Layer | UI |
| Relevance | High / 90 |
| Reason | role ApplicationService; patterns Service |
| Namespace | `BlazorShared.Interfaces` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | none |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<List<TLookupData>> List()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketQueryService

| Field | Value |
| --- | --- |
| Kind | Interface |
| Role | ApplicationService |
| Layer | Application |
| Relevance | High / 90 |
| Reason | role ApplicationService; patterns Service |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Interfaces` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | none |
| Patterns | `Service` |
| Technologies | none |
| Summary | Specific query used to fetch count without running in memory |

Public methods:
- `Task<int> CountTotalBasketItems(string username)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Interfaces.IOrderService

| Field | Value |
| --- | --- |
| Kind | Interface |
| Role | ApplicationService |
| Layer | Application |
| Relevance | High / 90 |
| Reason | role ApplicationService; patterns Service |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Interfaces` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | none |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task CreateOrderAsync(int basketId, Address shippingAddress)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Interfaces.ITokenClaimsService

| Field | Value |
| --- | --- |
| Kind | Interface |
| Role | ApplicationService |
| Layer | Application |
| Relevance | High / 90 |
| Reason | role ApplicationService; patterns Service |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Interfaces` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | none |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<string> GetTokenAsync(string userName)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Configuration.ConfigureCoreServices

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ApplicationService |
| Layer | UI |
| Relevance | High / 90 |
| Reason | role ApplicationService; patterns Service |
| Namespace | `Microsoft.eShopWeb.Web.Configuration` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `static IServiceCollection AddCoreServices(IServiceCollection services, IConfiguration configuration)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Configuration.ConfigureWebServices

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ApplicationService |
| Layer | UI |
| Relevance | High / 90 |
| Reason | role ApplicationService; patterns Service |
| Namespace | `Microsoft.eShopWeb.Web.Configuration` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `static IServiceCollection AddWebServices(IServiceCollection services, IConfiguration configuration)`

Semantic dependencies:
- none

## BlazorAdmin.Services.CachedCatalogLookupDataServiceDecorator<TLookupData, TReponse>

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Decorator |
| Layer | UI |
| Relevance | High / 89 |
| Reason | role Decorator; patterns Service; 2 semantic deps |
| Namespace | `BlazorAdmin.Services` |
| Project | `BlazorAdmin` |
| Base type | none |
| Interfaces | `BlazorShared.Interfaces.ICatalogLookupDataService<TLookupData>` |
| Patterns | `Service` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<List<TLookupData>> List()`

Semantic dependencies:
- `BlazorAdmin.Services.CatalogLookupDataService<TLookupData, TReponse>` (ConstructorInjection)
- `ILocalStorageService` (ConstructorInjection)

## Microsoft.eShopWeb.ApplicationCore.Interfaces.IReadRepository<T>

| Field | Value |
| --- | --- |
| Kind | Interface |
| Role | Repository |
| Layer | Application |
| Relevance | High / 88 |
| Reason | role Repository; patterns Repository |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Interfaces` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | `IReadRepositoryBase<T>` |
| Patterns | `Repository` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<T>

| Field | Value |
| --- | --- |
| Kind | Interface |
| Role | Repository |
| Layer | Application |
| Relevance | High / 88 |
| Reason | role Repository; patterns Repository |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Interfaces` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | `IRepositoryBase<T>` |
| Patterns | `Repository` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Features.MyOrders.GetMyOrdersHandler

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | CQRSHandler |
| Layer | Application |
| Relevance | High / 73 |
| Reason | role CQRSHandler; patterns Handler, ViewModel; tech CQRS; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.Features.MyOrders` |
| Project | `Web` |
| Base type | `IRequestHandler<Microsoft.eShopWeb.Web.Features.MyOrders.GetMyOrders, System.Collections.Generic.IEnumerable<Microsoft.eShopWeb.Web.ViewModels.OrderViewModel>>` |
| Interfaces | none |
| Patterns | `Handler`, `ViewModel` |
| Technologies | `CQRS` |
| Summary | none |

Public methods:
- `Task<IEnumerable<OrderViewModel>> Handle(GetMyOrders request, CancellationToken cancellationToken)`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IReadRepository<Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Order>` (ConstructorInjection)

## Microsoft.eShopWeb.Web.Features.OrderDetails.GetOrderDetailsHandler

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | CQRSHandler |
| Layer | Application |
| Relevance | High / 73 |
| Reason | role CQRSHandler; patterns Handler, ViewModel; tech CQRS; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.Features.OrderDetails` |
| Project | `Web` |
| Base type | `IRequestHandler<Microsoft.eShopWeb.Web.Features.OrderDetails.GetOrderDetails, Microsoft.eShopWeb.Web.ViewModels.OrderDetailViewModel>` |
| Interfaces | none |
| Patterns | `Handler`, `ViewModel` |
| Technologies | `CQRS` |
| Summary | none |

Public methods:
- `Task<OrderDetailViewModel?> Handle(GetOrderDetails request, CancellationToken cancellationToken)`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IReadRepository<Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Order>` (ConstructorInjection)

## Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications.CustomerOrdersWithItemsSpecification

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Specification |
| Layer | Tests |
| Relevance | High / 70 |
| Reason | role Specification; patterns Specification; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | `Specification` |
| Technologies | none |
| Summary | none |

Public methods:
- `List<Order> GetTestCollection()`
- `void ReturnsAllOrderWithAllOrderedItem()`
- `void ReturnsOrderWithOrderedItem()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications.CatalogFilterPaginatedSpecification

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Specification |
| Layer | Tests |
| Relevance | High / 65 |
| Reason | role Specification; patterns Specification |
| Namespace | `Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | `Specification` |
| Technologies | none |
| Summary | none |

Public methods:
- `void Returns2CatalogItemsWithSameBrandAndTypeId()`
- `void ReturnsAllCatalogItems()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications.CatalogFilterSpecification

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Specification |
| Layer | Tests |
| Relevance | High / 65 |
| Reason | role Specification; patterns Specification |
| Namespace | `Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | `Specification` |
| Technologies | none |
| Summary | none |

Public methods:
- `List<CatalogItem> GetTestItemCollection()`
- `void MatchesExpectedNumberOfItems(int? brandId, int? typeId, int expectedCount)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications.CatalogItemsSpecification

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Specification |
| Layer | Tests |
| Relevance | High / 65 |
| Reason | role Specification; patterns Specification |
| Namespace | `Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | `Specification` |
| Technologies | none |
| Summary | none |

Public methods:
- `void MatchesAllCatalogItems()`
- `void MatchesSpecificCatalogItem()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Specifications.BasketWithItemsSpecification

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Specification |
| Layer | Application |
| Relevance | Medium / 61 |
| Reason | role Specification; patterns Specification |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Specifications` |
| Project | `ApplicationCore` |
| Base type | `Specification<Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate.Basket>` |
| Interfaces | none |
| Patterns | `Specification` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Specifications.CatalogFilterPaginatedSpecification

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Specification |
| Layer | Application |
| Relevance | Medium / 61 |
| Reason | role Specification; patterns Specification |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Specifications` |
| Project | `ApplicationCore` |
| Base type | `Specification<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem>` |
| Interfaces | none |
| Patterns | `Specification` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Specifications.CatalogFilterSpecification

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Specification |
| Layer | Application |
| Relevance | Medium / 61 |
| Reason | role Specification; patterns Specification |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Specifications` |
| Project | `ApplicationCore` |
| Base type | `Specification<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem>` |
| Interfaces | none |
| Patterns | `Specification` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Specifications.CatalogItemNameSpecification

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Specification |
| Layer | Application |
| Relevance | Medium / 61 |
| Reason | role Specification; patterns Specification |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Specifications` |
| Project | `ApplicationCore` |
| Base type | `Specification<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem>` |
| Interfaces | none |
| Patterns | `Specification` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Specifications.CatalogItemsSpecification

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Specification |
| Layer | Application |
| Relevance | Medium / 61 |
| Reason | role Specification; patterns Specification |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Specifications` |
| Project | `ApplicationCore` |
| Base type | `Specification<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem>` |
| Interfaces | none |
| Patterns | `Specification` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Specifications.CustomerOrdersSpecification

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Specification |
| Layer | Application |
| Relevance | Medium / 61 |
| Reason | role Specification; patterns Specification |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Specifications` |
| Project | `ApplicationCore` |
| Base type | `Specification<Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Order>` |
| Interfaces | none |
| Patterns | `Specification` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Specifications.CustomerOrdersWithItemsSpecification

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Specification |
| Layer | Application |
| Relevance | Medium / 61 |
| Reason | role Specification; patterns Specification |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Specifications` |
| Project | `ApplicationCore` |
| Base type | `Specification<Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Order>` |
| Interfaces | none |
| Patterns | `Specification` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Specifications.OrderWithItemsByIdSpec

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Specification |
| Layer | Application |
| Relevance | Medium / 61 |
| Reason | role Specification; patterns Specification |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Specifications` |
| Project | `ApplicationCore` |
| Base type | `Specification<Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Order>` |
| Interfaces | none |
| Patterns | `Specification` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.Middleware.ExceptionMiddleware

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Middleware |
| Layer | API |
| Relevance | Medium / 60 |
| Reason | role Middleware; patterns Middleware; dangerous zone |
| Namespace | `Microsoft.eShopWeb.PublicApi.Middleware` |
| Project | `PublicApi` |
| Base type | none |
| Interfaces | none |
| Patterns | `Middleware` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task InvokeAsync(HttpContext httpContext)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Services.BasketViewModelService

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Medium / 59 |
| Reason | role ViewModel; patterns Service, ViewModel; 4 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.Services` |
| Project | `Web` |
| Base type | none |
| Interfaces | `Microsoft.eShopWeb.Web.Interfaces.IBasketViewModelService` |
| Patterns | `Service`, `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<int> CountTotalBasketItems(string username)`
- `Task<BasketViewModel> GetOrCreateBasketForUser(string userName)`
- `Task<BasketViewModel> Map(Basket basket)`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketQueryService` (ConstructorInjection)
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate.Basket>` (ConstructorInjection)
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem>` (ConstructorInjection)
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IUriComposer` (ConstructorInjection)

## Microsoft.eShopWeb.Web.Services.CatalogViewModelService

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Medium / 59 |
| Reason | role ViewModel; patterns Service, ViewModel; 4 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.Services` |
| Project | `Web` |
| Base type | none |
| Interfaces | `Microsoft.eShopWeb.Web.Services.ICatalogViewModelService` |
| Patterns | `Service`, `ViewModel` |
| Technologies | none |
| Summary | This is a UI-specific service so belongs in UI project. It does not contain any business logic and works with UI-specific types (view models and SelectListItem types). |

Public methods:
- `Task<IEnumerable<SelectListItem>> GetBrands()`
- `Task<CatalogIndexViewModel> GetCatalogItems(int pageIndex, int itemsPage, int? brandId, int? typeId)`
- `Task<IEnumerable<SelectListItem>> GetTypes()`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogBrand>` (ConstructorInjection)
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem>` (ConstructorInjection)
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogType>` (ConstructorInjection)
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IUriComposer` (ConstructorInjection)

## PublicApiIntegrationTests.CatalogItemEndpoints.CatalogItemListPagedEndpoint

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Endpoint |
| Layer | Tests |
| Relevance | Medium / 59 |
| Reason | role Endpoint |
| Namespace | `PublicApiIntegrationTests.CatalogItemEndpoints` |
| Project | `PublicApiIntegrationTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task ReturnsCorrectCatalogItemsGivenPageIndex1()`
- `Task ReturnsFirst10CatalogItems()`
- `Task SuccessFullMutipleParallelCall(string endpointName)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.AuthEndpoints.AuthenticateEndpoint

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Endpoint |
| Layer | API |
| Relevance | Medium / 58 |
| Reason | role Endpoint; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.PublicApi.AuthEndpoints` |
| Project | `PublicApi` |
| Base type | `EndpointBaseAsync.WithRequest<Microsoft.eShopWeb.PublicApi.AuthEndpoints.AuthenticateRequest>.WithActionResult<Microsoft.eShopWeb.PublicApi.AuthEndpoints.AuthenticateResponse>` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | Authenticates a user |

Public methods:
- `Task<ActionResult<AuthenticateResponse>> HandleAsync(AuthenticateRequest request, CancellationToken cancellationToken)`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.ITokenClaimsService` (ConstructorInjection)

## PublicApiIntegrationTests.AuthEndpoints.AuthenticateEndpoint

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Endpoint |
| Layer | Tests |
| Relevance | Medium / 55 |
| Reason | role Endpoint |
| Namespace | `PublicApiIntegrationTests.AuthEndpoints` |
| Project | `PublicApiIntegrationTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task ReturnsExpectedResultGivenCredentials(string testUsername, string testPassword, bool expectedResult)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.IntegrationTests.Repositories.BasketRepositoryTests.SetQuantities

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Repository |
| Layer | Tests |
| Relevance | Medium / 54 |
| Reason | role Repository; 3 semantic deps |
| Namespace | `Microsoft.eShopWeb.IntegrationTests.Repositories.BasketRepositoryTests` |
| Project | `IntegrationTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task RemoveEmptyQuantities()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.IntegrationTests.Repositories.OrderRepositoryTests.GetById

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Repository |
| Layer | Tests |
| Relevance | Medium / 54 |
| Reason | role Repository; 3 semantic deps |
| Namespace | `Microsoft.eShopWeb.IntegrationTests.Repositories.OrderRepositoryTests` |
| Project | `IntegrationTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task GetsExistingOrder()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.IntegrationTests.Repositories.OrderRepositoryTests.GetByIdWithItemsAsync

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Repository |
| Layer | Tests |
| Relevance | Medium / 54 |
| Reason | role Repository; 3 semantic deps |
| Namespace | `Microsoft.eShopWeb.IntegrationTests.Repositories.OrderRepositoryTests` |
| Project | `IntegrationTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task GetOrderAndItemsByOrderIdWhenMultipleOrdersPresent()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.FunctionalTests.PublicApi.TestApiApplication

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Endpoint |
| Layer | Tests |
| Relevance | Medium / 53 |
| Reason | role Endpoint |
| Namespace | `Microsoft.eShopWeb.FunctionalTests.PublicApi` |
| Project | `FunctionalTests` |
| Base type | `WebApplicationFactory<Microsoft.eShopWeb.PublicApi.AuthEndpoints.AuthenticateEndpoint>` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | AggregateRoot |
| Layer | Domain |
| Relevance | Medium / 50 |
| Reason | role AggregateRoot; 2 semantic deps |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Entities` |
| Project | `ApplicationCore` |
| Base type | `Microsoft.eShopWeb.ApplicationCore.Entities.BaseEntity` |
| Interfaces | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IAggregateRoot` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void UpdateBrand(int catalogBrandId)`
- `void UpdateDetails(CatalogItemDetails details)`
- `void UpdatePictureUri(string pictureName)`
- `void UpdateType(int catalogTypeId)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Services.CachedCatalogViewModelService

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Medium / 50 |
| Reason | role ViewModel; patterns Service, ViewModel; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.Services` |
| Project | `Web` |
| Base type | none |
| Interfaces | `Microsoft.eShopWeb.Web.Services.ICatalogViewModelService` |
| Patterns | `Service`, `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<IEnumerable<SelectListItem>> GetBrands()`
- `Task<CatalogIndexViewModel> GetCatalogItems(int pageIndex, int itemsPage, int? brandId, int? typeId)`
- `Task<IEnumerable<SelectListItem>> GetTypes()`

Semantic dependencies:
- `Microsoft.eShopWeb.Web.Services.CatalogViewModelService` (ConstructorInjection)

## Microsoft.eShopWeb.Web.Interfaces.IBasketViewModelService

| Field | Value |
| --- | --- |
| Kind | Interface |
| Role | ViewModel |
| Layer | UI |
| Relevance | Medium / 47 |
| Reason | role ViewModel; patterns Service, ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.Interfaces` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `Service`, `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<int> CountTotalBasketItems(string username)`
- `Task<BasketViewModel> GetOrCreateBasketForUser(string userName)`
- `Task<BasketViewModel> Map(Basket basket)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Services.ICatalogViewModelService

| Field | Value |
| --- | --- |
| Kind | Interface |
| Role | ViewModel |
| Layer | UI |
| Relevance | Medium / 47 |
| Reason | role ViewModel; patterns Service, ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.Services` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `Service`, `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<IEnumerable<SelectListItem>> GetBrands()`
- `Task<CatalogIndexViewModel> GetCatalogItems(int pageIndex, int itemsPage, int? brandId, int? typeId)`
- `Task<IEnumerable<SelectListItem>> GetTypes()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications.BasketWithItems

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Specification |
| Layer | Tests |
| Relevance | Medium / 46 |
| Reason | role Specification |
| Namespace | `Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `List<Basket> GetTestBasketCollection()`
- `void MatchesBasketWithGivenBasketId()`
- `void MatchesBasketWithGivenBuyerId()`
- `void MatchesNoBasketsIfBasketIdNotPresent()`
- `void MatchesNoBasketsIfBuyerIdNotPresent()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Services.CatalogItemViewModelService

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Medium / 46 |
| Reason | role ViewModel; patterns Service, ViewModel; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.Services` |
| Project | `Web` |
| Base type | none |
| Interfaces | `Microsoft.eShopWeb.Web.Interfaces.ICatalogItemViewModelService` |
| Patterns | `Service`, `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task UpdateCatalogItem(CatalogItemViewModel viewModel)`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem>` (ConstructorInjection)

## Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate.PaymentMethod

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Entity |
| Layer | Domain |
| Relevance | Medium / 45 |
| Reason | role Entity; dangerous zone |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate` |
| Project | `ApplicationCore` |
| Base type | `Microsoft.eShopWeb.ApplicationCore.Entities.BaseEntity` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.LoginModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Medium / 43 |
| Reason | 2 semantic deps; dangerous zone |
| Namespace | `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.RazorPages.PageModel` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task OnGetAsync(string? returnUrl)`
- `Task<IActionResult> OnPostAsync(string? returnUrl)`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketService` (ConstructorInjection)

## Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.RegisterModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Medium / 43 |
| Reason | 2 semantic deps; dangerous zone |
| Namespace | `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.RazorPages.PageModel` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void OnGet(string? returnUrl)`
- `Task<IActionResult> OnPostAsync(string? returnUrl)`

Semantic dependencies:
- `Microsoft.AspNetCore.Identity.UI.Services.IEmailSender` (ConstructorInjection)

## Microsoft.eShopWeb.Web.Interfaces.ICatalogItemViewModelService

| Field | Value |
| --- | --- |
| Kind | Interface |
| Role | ViewModel |
| Layer | UI |
| Relevance | Medium / 43 |
| Reason | role ViewModel; patterns Service, ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.Interfaces` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `Service`, `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- `Task UpdateCatalogItem(CatalogItemViewModel viewModel)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate.Basket

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | AggregateRoot |
| Layer | Domain |
| Relevance | Medium / 42 |
| Reason | role AggregateRoot |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate` |
| Project | `ApplicationCore` |
| Base type | `Microsoft.eShopWeb.ApplicationCore.Entities.BaseEntity` |
| Interfaces | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IAggregateRoot` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void AddItem(int catalogItemId, decimal unitPrice, int quantity)`
- `void RemoveEmptyItems()`
- `void SetNewBuyerId(string buyerId)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.BasketTests.BasketAddItem

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Entity |
| Layer | Tests |
| Relevance | Medium / 42 |
| Reason | role Entity |
| Namespace | `Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.BasketTests` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void AddsBasketItemIfNotPresent()`
- `void CantAddItemWithNegativeQuantity()`
- `void CantModifyQuantityToNegativeNumber()`
- `void DefaultsToQuantityOfOne()`
- `void IncrementsQuantityOfItemIfPresent()`
- `void KeepsOriginalUnitPriceIfMoreItemsAdded()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Order

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | AggregateRoot |
| Layer | Domain |
| Relevance | Medium / 41 |
| Reason | role AggregateRoot; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate` |
| Project | `ApplicationCore` |
| Base type | `Microsoft.eShopWeb.ApplicationCore.Entities.BaseEntity` |
| Interfaces | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IAggregateRoot` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `decimal Total()`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Address` (ConstructorInjection)

## Microsoft.eShopWeb.FunctionalTests.Web.TestApplication

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | Tests |
| Relevance | Medium / 41 |
| Reason | role ViewModel; patterns Service, ViewModel |
| Namespace | `Microsoft.eShopWeb.FunctionalTests.Web` |
| Project | `FunctionalTests` |
| Base type | `WebApplicationFactory<Microsoft.eShopWeb.Web.Interfaces.IBasketViewModelService>` |
| Interfaces | none |
| Patterns | `Service`, `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Infrastructure.Data.Config.BasketConfiguration

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Configuration |
| Layer | Infrastructure |
| Relevance | Medium / 38 |
| Reason | role Configuration |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Data.Config` |
| Project | `Infrastructure` |
| Base type | `IEntityTypeConfiguration<Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate.Basket>` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void Configure(EntityTypeBuilder<Basket> builder)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Infrastructure.Data.Config.BasketItemConfiguration

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Configuration |
| Layer | Infrastructure |
| Relevance | Medium / 38 |
| Reason | role Configuration |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Data.Config` |
| Project | `Infrastructure` |
| Base type | `IEntityTypeConfiguration<Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate.BasketItem>` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void Configure(EntityTypeBuilder<BasketItem> builder)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Infrastructure.Data.Config.CatalogBrandConfiguration

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Configuration |
| Layer | Infrastructure |
| Relevance | Medium / 38 |
| Reason | role Configuration |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Data.Config` |
| Project | `Infrastructure` |
| Base type | `IEntityTypeConfiguration<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogBrand>` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void Configure(EntityTypeBuilder<CatalogBrand> builder)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Infrastructure.Data.Config.CatalogItemConfiguration

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Configuration |
| Layer | Infrastructure |
| Relevance | Medium / 38 |
| Reason | role Configuration |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Data.Config` |
| Project | `Infrastructure` |
| Base type | `IEntityTypeConfiguration<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem>` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void Configure(EntityTypeBuilder<CatalogItem> builder)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Infrastructure.Data.Config.CatalogTypeConfiguration

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Configuration |
| Layer | Infrastructure |
| Relevance | Medium / 38 |
| Reason | role Configuration |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Data.Config` |
| Project | `Infrastructure` |
| Base type | `IEntityTypeConfiguration<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogType>` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void Configure(EntityTypeBuilder<CatalogType> builder)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Infrastructure.Data.Config.OrderConfiguration

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Configuration |
| Layer | Infrastructure |
| Relevance | Medium / 38 |
| Reason | role Configuration |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Data.Config` |
| Project | `Infrastructure` |
| Base type | `IEntityTypeConfiguration<Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Order>` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void Configure(EntityTypeBuilder<Order> builder)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Infrastructure.Data.Config.OrderItemConfiguration

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Configuration |
| Layer | Infrastructure |
| Relevance | Medium / 38 |
| Reason | role Configuration |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Data.Config` |
| Project | `Infrastructure` |
| Base type | `IEntityTypeConfiguration<Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.OrderItem>` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void Configure(EntityTypeBuilder<OrderItem> builder)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.LogoutModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Medium / 37 |
| Reason | dangerous zone |
| Namespace | `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.RazorPages.PageModel` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void OnGet()`
- `Task<IActionResult> OnPost(string? returnUrl)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Pages.Basket.CheckoutModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Medium / 37 |
| Reason | 5 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.Pages.Basket` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.RazorPages.PageModel` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task OnGet()`
- `Task<IActionResult> OnPost(IEnumerable<BasketItemViewModel> items)`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IAppLogger<Microsoft.eShopWeb.Web.Pages.Basket.CheckoutModel>` (ConstructorInjection)
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketService` (ConstructorInjection)
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IOrderService` (ConstructorInjection)
- `Microsoft.eShopWeb.Web.Interfaces.IBasketViewModelService` (ConstructorInjection)

## BlazorAdmin.Pages.CatalogItemPage.List

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Medium / 36 |
| Reason | 7 semantic deps |
| Namespace | `BlazorAdmin.Pages.CatalogItemPage` |
| Project | `BlazorAdmin` |
| Base type | `BlazorAdmin.Helpers.BlazorComponent` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorShared.Authorization.UserInfo

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Medium / 36 |
| Reason | 1 semantic deps; dangerous zone |
| Namespace | `BlazorShared.Authorization` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate.Buyer

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | AggregateRoot |
| Layer | Domain |
| Relevance | Medium / 36 |
| Reason | role AggregateRoot |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate` |
| Project | `ApplicationCore` |
| Base type | `Microsoft.eShopWeb.ApplicationCore.Entities.BaseEntity` |
| Interfaces | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IAggregateRoot` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Entities.CatalogBrand

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | AggregateRoot |
| Layer | Domain |
| Relevance | Medium / 36 |
| Reason | role AggregateRoot |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Entities` |
| Project | `ApplicationCore` |
| Base type | `Microsoft.eShopWeb.ApplicationCore.Entities.BaseEntity` |
| Interfaces | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IAggregateRoot` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Entities.CatalogType

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | AggregateRoot |
| Layer | Domain |
| Relevance | Medium / 36 |
| Reason | role AggregateRoot |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Entities` |
| Project | `ApplicationCore` |
| Base type | `Microsoft.eShopWeb.ApplicationCore.Entities.BaseEntity` |
| Interfaces | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IAggregateRoot` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.OrderTests.OrderTotal

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Entity |
| Layer | Tests |
| Relevance | Medium / 36 |
| Reason | role Entity |
| Namespace | `Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.OrderTests` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void IsCorrectGiven1Item()`
- `void IsCorrectGiven3Items()`
- `void IsZeroForNewOrder()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Pages.Basket.IndexModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Medium / 36 |
| Reason | 4 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.Pages.Basket` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.RazorPages.PageModel` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task OnGet()`
- `Task<IActionResult> OnPost(CatalogItemViewModel productDetails)`
- `Task OnPostUpdate(IEnumerable<BasketItemViewModel> items)`

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketService` (ConstructorInjection)
- `Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem>` (ConstructorInjection)
- `Microsoft.eShopWeb.Web.Interfaces.IBasketViewModelService` (ConstructorInjection)

## Microsoft.eShopWeb.UnitTests.ApplicationCore.Services.BasketServiceTests.TransferBasket

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Medium / 35 |
| Reason | 3 semantic deps |
| Namespace | `Microsoft.eShopWeb.UnitTests.ApplicationCore.Services.BasketServiceTests` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task CreatesNewUserBasketIfNotExists()`
- `Task InvokesBasketRepositoryFirstOrDefaultAsyncOnceIfAnonymousBasketNotExists()`
- `Task RemovesAnonymousBasketAfterUpdatingUserBasket()`
- `Task TransferAnonymousBasketItemsWhilePreservingExistingUserBasketItems()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Areas.Identity.IdentityHostingStartup

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Medium / 35 |
| Reason | dangerous zone |
| Namespace | `Microsoft.eShopWeb.Web.Areas.Identity` |
| Project | `Web` |
| Base type | none |
| Interfaces | `Microsoft.AspNetCore.Hosting.IHostingStartup` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void Configure(IWebHostBuilder builder)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.ConfirmEmailModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Medium / 35 |
| Reason | dangerous zone |
| Namespace | `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.RazorPages.PageModel` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<IActionResult> OnGetAsync(string userId, string code)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Configuration.RevokeAuthenticationEvents

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Medium / 35 |
| Reason | dangerous zone |
| Namespace | `Microsoft.eShopWeb.Web.Configuration` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task ValidatePrincipal(CookieValidatePrincipalContext context)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate.BasketItem

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Entity |
| Layer | Domain |
| Relevance | Low / 34 |
| Reason | role Entity |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate` |
| Project | `ApplicationCore` |
| Base type | `Microsoft.eShopWeb.ApplicationCore.Entities.BaseEntity` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void AddQuantity(int quantity)`
- `void SetQuantity(int quantity)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.BasketTests.BasketTotalItems

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Entity |
| Layer | Tests |
| Relevance | Low / 34 |
| Reason | role Entity |
| Namespace | `Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.BasketTests` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void ReturnsTotalQuantityWithMultipleItems()`
- `void ReturnsTotalQuantityWithOneItem()`

Semantic dependencies:
- none

## BlazorShared.Authorization.ClaimValue

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ValueObject |
| Layer | UI |
| Relevance | Low / 33 |
| Reason | role ValueObject; dangerous zone |
| Namespace | `BlazorShared.Authorization` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorShared.Authorization.Constants

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 33 |
| Reason | dangerous zone |
| Namespace | `BlazorShared.Authorization` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorShared.Authorization.Constants.Roles

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 33 |
| Reason | dangerous zone |
| Namespace | `BlazorShared.Authorization` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Constants.AuthorizationConstants

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Application |
| Relevance | Low / 33 |
| Reason | dangerous zone |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Constants` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.OrderItem

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Entity |
| Layer | Domain |
| Relevance | Low / 33 |
| Reason | role Entity; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate` |
| Project | `ApplicationCore` |
| Base type | `Microsoft.eShopWeb.ApplicationCore.Entities.BaseEntity` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.CatalogItemOrdered` (ConstructorInjection)

## Microsoft.eShopWeb.Infrastructure.Identity.ApplicationUser

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Infrastructure |
| Relevance | Low / 33 |
| Reason | dangerous zone |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Identity` |
| Project | `Infrastructure` |
| Base type | `IdentityUser` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Infrastructure.Identity.UserNotFoundException

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Infrastructure |
| Relevance | Low / 33 |
| Reason | dangerous zone |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Identity` |
| Project | `Infrastructure` |
| Base type | `System.Exception` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.LoginModel.InputModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 33 |
| Reason | dangerous zone |
| Namespace | `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.RegisterModel.InputModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 33 |
| Reason | dangerous zone |
| Namespace | `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.BasketTests.BasketRemoveEmptyItems

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Entity |
| Layer | Tests |
| Relevance | Low / 32 |
| Reason | role Entity |
| Namespace | `Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.BasketTests` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void RemovesEmptyBasketItems()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.Builders.OrderBuilder

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 32 |
| Reason | 2 semantic deps |
| Namespace | `Microsoft.eShopWeb.UnitTests.Builders` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Order Build()`
- `Order WithDefaultValues()`
- `Order WithItems(List<OrderItem> items)`
- `Order WithNoItems()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Entities.BaseEntity

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Entity |
| Layer | Domain |
| Relevance | Low / 30 |
| Reason | role Entity |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Entities` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem.CatalogItemDetails

| Field | Value |
| --- | --- |
| Kind | Record |
| Role | Entity |
| Layer | Domain |
| Relevance | Low / 30 |
| Reason | role Entity |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Entities` |
| Project | `ApplicationCore` |
| Base type | `System.ValueType` |
| Interfaces | `System.IEquatable<Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem.CatalogItemDetails>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Address

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Entity |
| Layer | Domain |
| Relevance | Low / 30 |
| Reason | role Entity |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.CatalogItemOrdered

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Entity |
| Layer | Domain |
| Relevance | Low / 30 |
| Reason | role Entity |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.MappingProfile

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Mapper |
| Layer | API |
| Relevance | Low / 30 |
| Reason | role Mapper |
| Namespace | `Microsoft.eShopWeb.PublicApi` |
| Project | `PublicApi` |
| Base type | `Profile` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Views.Manage.ManageNavPages

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 30 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.Web.Views.Manage` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `static void AddActivePage(ViewDataDictionary viewData, string activePage)`
- `static string ChangePasswordNavClass(ViewContext viewContext)`
- `static string ExternalLoginsNavClass(ViewContext viewContext)`
- `static string IndexNavClass(ViewContext viewContext)`
- `static string PageNavClass(ViewContext viewContext, string page)`
- `static string TwoFactorAuthenticationNavClass(ViewContext viewContext)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.ApplicationCore.Services.BasketServiceTests.AddItemToBasket

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 28 |
| Reason | 2 semantic deps |
| Namespace | `Microsoft.eShopWeb.UnitTests.ApplicationCore.Services.BasketServiceTests` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task InvokesBasketRepositoryGetBySpecAsyncOnce()`
- `Task InvokesBasketRepositoryUpdateAsyncOnce()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Pages.Admin.EditCatalogItemModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 28 |
| Reason | 2 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.Pages.Admin` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.RazorPages.PageModel` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void OnGet(CatalogItemViewModel catalogModel)`
- `Task<IActionResult> OnPostAsync()`

Semantic dependencies:
- `Microsoft.eShopWeb.Web.Interfaces.ICatalogItemViewModelService` (ConstructorInjection)

## Microsoft.eShopWeb.ApplicationCore.Exceptions.EmptyBasketOnCheckoutException

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Application |
| Relevance | Low / 27 |
| Reason | 3 semantic deps |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Exceptions` |
| Project | `ApplicationCore` |
| Base type | `System.Exception` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- `System.Exception` (ConstructorInjection)
- `System.Runtime.Serialization.SerializationInfo` (ConstructorInjection)
- `System.Runtime.Serialization.StreamingContext` (ConstructorInjection)

## Microsoft.eShopWeb.UnitTests.ApplicationCore.Services.BasketServiceTests.TransferBasket.Results<T>

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 27 |
| Reason | 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.UnitTests.ApplicationCore.Services.BasketServiceTests` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `T Next()`
- `Results<T> Then(T value)`
- `Results<T> Then(Func<T> value)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.Builders.BasketBuilder

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 27 |
| Reason | 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.UnitTests.Builders` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Basket Build()`
- `Basket WithNoItems()`
- `Basket WithOneBasketItem()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.ApplicationCore.Services.BasketServiceTests.DeleteBasket

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 26 |
| Reason | 2 semantic deps |
| Namespace | `Microsoft.eShopWeb.UnitTests.ApplicationCore.Services.BasketServiceTests` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task ShouldInvokeBasketRepositoryDeleteAsyncOnce()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Pages.IndexModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 26 |
| Reason | 2 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.Pages` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.RazorPages.PageModel` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task OnGet(CatalogIndexViewModel catalogModel, int? pageId)`

Semantic dependencies:
- `Microsoft.eShopWeb.Web.Services.ICatalogViewModelService` (ConstructorInjection)

## BlazorAdmin.JavaScript.Cookies

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 25 |
| Reason | 1 semantic deps |
| Namespace | `BlazorAdmin.JavaScript` |
| Project | `BlazorAdmin` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task DeleteCookie(string name)`
- `Task<string> GetCookie(string name)`

Semantic dependencies:
- `IJSRuntime` (ConstructorInjection)

## BlazorAdmin.JavaScript.Css

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 25 |
| Reason | 1 semantic deps |
| Namespace | `BlazorAdmin.JavaScript` |
| Project | `BlazorAdmin` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<string> HideBodyOverflow()`
- `Task ShowBodyOverflow()`

Semantic dependencies:
- `IJSRuntime` (ConstructorInjection)

## Microsoft.eShopWeb.FunctionalTests.Web.Pages.Basket.IndexTest

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 25 |
| Reason | 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.FunctionalTests.Web.Pages.Basket` |
| Project | `FunctionalTests` |
| Base type | `IClassFixture<Microsoft.eShopWeb.FunctionalTests.Web.TestApplication>` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task OnPostUpdateTo0EmptyBasket()`
- `Task OnPostUpdateTo50Successfully()`

Semantic dependencies:
- `Microsoft.eShopWeb.FunctionalTests.Web.TestApplication` (ConstructorInjection)

## Microsoft.eShopWeb.JsonExtensions

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Application |
| Relevance | Low / 25 |
| Reason | 1 semantic deps |
| Namespace | `Microsoft.eShopWeb` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `static T? FromJson(string json)`
- `static string ToJson(T obj)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.Builders.AddressBuilder

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 25 |
| Reason | 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.UnitTests.Builders` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Address Build()`
- `Address WithDefaultValues()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Extensions.CacheHelpers

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 24 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.Web.Extensions` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `static string GenerateBrandsCacheKey()`
- `static string GenerateCatalogItemCacheKey(int pageIndex, int itemsPage, int? brandId, int? typeId)`
- `static string GenerateTypesCacheKey()`

Semantic dependencies:
- none

## BlazorAdmin.CustomAuthStateProvider

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 23 |
| Reason | 1 semantic deps |
| Namespace | `BlazorAdmin` |
| Project | `BlazorAdmin` |
| Base type | `AuthenticationStateProvider` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<AuthenticationState> GetAuthenticationStateAsync()`

Semantic dependencies:
- none

## BlazorAdmin.Helpers.BlazorComponent

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 23 |
| Reason | 1 semantic deps |
| Namespace | `BlazorAdmin.Helpers` |
| Project | `BlazorAdmin` |
| Base type | `ComponentBase` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void CallRequestRefresh()`

Semantic dependencies:
- none

## BlazorAdmin.Helpers.BlazorLayoutComponent

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 23 |
| Reason | 1 semantic deps |
| Namespace | `BlazorAdmin.Helpers` |
| Project | `BlazorAdmin` |
| Base type | `LayoutComponentBase` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void CallRequestRefresh()`

Semantic dependencies:
- none

## BlazorAdmin.Helpers.ToastComponent

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 23 |
| Reason | 1 semantic deps |
| Namespace | `BlazorAdmin.Helpers` |
| Project | `BlazorAdmin` |
| Base type | `ComponentBase` |
| Interfaces | `System.IDisposable` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void Dispose()`

Semantic dependencies:
- none

## BlazorAdmin.JavaScript.Route

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 23 |
| Reason | 1 semantic deps |
| Namespace | `BlazorAdmin.JavaScript` |
| Project | `BlazorAdmin` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task RouteOutside(string path)`

Semantic dependencies:
- `IJSRuntime` (ConstructorInjection)

## Microsoft.eShopWeb.ApplicationCore.Services.UriComposer

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Application |
| Relevance | Low / 23 |
| Reason | 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Services` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IUriComposer` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `string ComposePicUri(string uriTemplate)`

Semantic dependencies:
- `Microsoft.eShopWeb.CatalogSettings` (ConstructorInjection)

## Microsoft.eShopWeb.FunctionalTests.Web.Controllers.OrderIndexOnGet

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 23 |
| Reason | 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.FunctionalTests.Web.Controllers` |
| Project | `FunctionalTests` |
| Base type | `IClassFixture<Microsoft.eShopWeb.FunctionalTests.Web.TestApplication>` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task ReturnsRedirectGivenAnonymousUser()`

Semantic dependencies:
- `Microsoft.eShopWeb.FunctionalTests.Web.TestApplication` (ConstructorInjection)

## Microsoft.eShopWeb.FunctionalTests.Web.Pages.Basket.BasketPageCheckout

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 23 |
| Reason | 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.FunctionalTests.Web.Pages.Basket` |
| Project | `FunctionalTests` |
| Base type | `IClassFixture<Microsoft.eShopWeb.FunctionalTests.Web.TestApplication>` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task RedirectsToLoginIfNotAuthenticated()`

Semantic dependencies:
- `Microsoft.eShopWeb.FunctionalTests.Web.TestApplication` (ConstructorInjection)

## Microsoft.eShopWeb.FunctionalTests.Web.Pages.Basket.CheckoutTest

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 23 |
| Reason | 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.FunctionalTests.Web.Pages.Basket` |
| Project | `FunctionalTests` |
| Base type | `IClassFixture<Microsoft.eShopWeb.FunctionalTests.Web.TestApplication>` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task SucessfullyPay()`

Semantic dependencies:
- `Microsoft.eShopWeb.FunctionalTests.Web.TestApplication` (ConstructorInjection)

## Microsoft.eShopWeb.FunctionalTests.WebRazorPages.HomePageOnGet

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 23 |
| Reason | 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.FunctionalTests.WebRazorPages` |
| Project | `FunctionalTests` |
| Base type | `IClassFixture<Microsoft.eShopWeb.FunctionalTests.Web.TestApplication>` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task ReturnsHomePageWithProductListing()`

Semantic dependencies:
- `Microsoft.eShopWeb.FunctionalTests.Web.TestApplication` (ConstructorInjection)

## Microsoft.eShopWeb.UnitTests.MediatorHandlers.OrdersTests.GetMyOrders

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 23 |
| Reason | 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.UnitTests.MediatorHandlers.OrdersTests` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task NotReturnNullIfOrdersArePresIent()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.MediatorHandlers.OrdersTests.GetOrderDetails

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 23 |
| Reason | 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.UnitTests.MediatorHandlers.OrdersTests` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task NotBeNullIfOrderExists()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.HealthChecks.ApiHealthCheck

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | API |
| Relevance | Low / 23 |
| Reason | 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.HealthChecks` |
| Project | `Web` |
| Base type | none |
| Interfaces | `Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Pages.Shared.Components.BasketComponent.Basket

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 23 |
| Reason | 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.Pages.Shared.Components.BasketComponent` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.ViewComponent` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<IViewComponentResult> InvokeAsync()`

Semantic dependencies:
- `Microsoft.eShopWeb.Web.Interfaces.IBasketViewModelService` (ConstructorInjection)

## PublicApiIntegrationTests.ProgramTest

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 23 |
| Reason | 1 semantic deps |
| Namespace | `PublicApiIntegrationTests` |
| Project | `PublicApiIntegrationTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `static void AssemblyInitialize(TestContext _)`

Semantic dependencies:
- none

## BlazorShared.Models.CatalogItem

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 22 |
| Reason | low architectural signal |
| Namespace | `BlazorShared.Models` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `static Task<string> DataToBase64(IFileListEntry fileItem)`
- `static string IsValidImage(string pictureName, string pictureBase64)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Interfaces.IAppLogger<T>

| Field | Value |
| --- | --- |
| Kind | Interface |
| Role | Unknown |
| Layer | Application |
| Relevance | Low / 22 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Interfaces` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | This type eliminates the need to depend directly on the ASP.NET Core logging types. |

Public methods:
- `void LogInformation(string message, object[] args)`
- `void LogWarning(string message, object[] args)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.FunctionalTests.Web.Api.ApiTokenHelper

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 22 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.FunctionalTests.Web.Api` |
| Project | `FunctionalTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `static string GetAdminUserToken()`
- `static string GetNormalUserToken()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.FunctionalTests.Web.WebPageHelpers

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 22 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.FunctionalTests.Web` |
| Project | `FunctionalTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `static string GetId(string input)`
- `static string GetRequestVerificationToken(string input)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Infrastructure.Logging.LoggerAdapter<T>

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Adapter |
| Layer | Infrastructure |
| Relevance | Low / 22 |
| Reason | role Adapter |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Logging` |
| Project | `Infrastructure` |
| Base type | none |
| Interfaces | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IAppLogger<T>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void LogInformation(string message, object[] args)`
- `void LogWarning(string message, object[] args)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.ApplicationCore.Extensions.JsonExtensions

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 22 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.UnitTests.ApplicationCore.Extensions` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void CorrectlyDeserializesJson(string json, int expectedId, string expectedName)`
- `void CorrectlySerializesAndDeserializesObject()`

Semantic dependencies:
- none

## PublicApiIntegrationTests.ApiTokenHelper

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 22 |
| Reason | low architectural signal |
| Namespace | `PublicApiIntegrationTests` |
| Project | `PublicApiIntegrationTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `static string GetAdminUserToken()`
- `static string GetNormalUserToken()`

Semantic dependencies:
- none

## PublicApiIntegrationTests.AuthEndpoints.CreateCatalogItemEndpointTest

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 22 |
| Reason | low architectural signal |
| Namespace | `PublicApiIntegrationTests.AuthEndpoints` |
| Project | `PublicApiIntegrationTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task ReturnsNotAuthorizedGivenNormalUserToken()`
- `Task ReturnsSuccessGivenValidNewItemAndAdminUserToken()`

Semantic dependencies:
- none

## PublicApiIntegrationTests.CatalogItemEndpoints.CatalogItemGetByIdEndpointTest

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 22 |
| Reason | low architectural signal |
| Namespace | `PublicApiIntegrationTests.CatalogItemEndpoints` |
| Project | `PublicApiIntegrationTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task ReturnsItemGivenValidId()`
- `Task ReturnsNotFoundGivenInvalidId()`

Semantic dependencies:
- none

## PublicApiIntegrationTests.CatalogItemEndpoints.DeleteCatalogItemEndpointTest

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 22 |
| Reason | low architectural signal |
| Namespace | `PublicApiIntegrationTests.CatalogItemEndpoints` |
| Project | `PublicApiIntegrationTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task ReturnsNotFoundGivenInvalidIdAndAdminUserToken()`
- `Task ReturnsSuccessGivenValidIdAndAdminUserToken()`

Semantic dependencies:
- none

## BlazorShared.Models.EditCatalogItemResult

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 21 |
| Reason | 1 semantic deps |
| Namespace | `BlazorShared.Models` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.AuthEndpoints.UserInfo

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | API |
| Relevance | Low / 21 |
| Reason | 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.PublicApi.AuthEndpoints` |
| Project | `PublicApi` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Features.MyOrders.GetMyOrders

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | Application |
| Relevance | Low / 21 |
| Reason | role ViewModel; patterns ViewModel; tech CQRS |
| Namespace | `Microsoft.eShopWeb.Web.Features.MyOrders` |
| Project | `Web` |
| Base type | `IRequest<System.Collections.Generic.IEnumerable<Microsoft.eShopWeb.Web.ViewModels.OrderViewModel>>` |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | `CQRS` |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Features.OrderDetails.GetOrderDetails

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | Application |
| Relevance | Low / 21 |
| Reason | role ViewModel; patterns ViewModel; tech CQRS |
| Namespace | `Microsoft.eShopWeb.Web.Features.OrderDetails` |
| Project | `Web` |
| Base type | `IRequest<Microsoft.eShopWeb.Web.ViewModels.OrderDetailViewModel>` |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | `CQRS` |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Ardalis.GuardClauses.BasketGuards

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Application |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Ardalis.GuardClauses` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `static void EmptyBasketOnCheckout(IGuardClause guardClause, IReadOnlyCollection<BasketItem> basketItems)`

Semantic dependencies:
- none

## BlazorShared.Models.ErrorDetails

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `BlazorShared.Models` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `string ToString()`

Semantic dependencies:
- none

## Microsoft.AspNetCore.Mvc.UrlHelperExtensions

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.AspNetCore.Mvc` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `static string? EmailConfirmationLink(IUrlHelper urlHelper, string userId, string code, string scheme)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Interfaces.IEmailSender

| Field | Value |
| --- | --- |
| Kind | Interface |
| Role | Unknown |
| Layer | Application |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Interfaces` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task SendEmailAsync(string email, string subject, string message)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Interfaces.IUriComposer

| Field | Value |
| --- | --- |
| Kind | Interface |
| Role | Unknown |
| Layer | Application |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Interfaces` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `string ComposePicUri(string uriTemplate)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Infrastructure.Data.CatalogContextSeed

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Infrastructure |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Data` |
| Project | `Infrastructure` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `static Task SeedAsync(CatalogContext catalogContext, ILogger logger, int retry)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Infrastructure.Dependencies

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Infrastructure |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.Infrastructure` |
| Project | `Infrastructure` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `static void ConfigureServices(IConfiguration configuration, IServiceCollection services)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Infrastructure.Services.EmailSender

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Infrastructure |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Services` |
| Project | `Infrastructure` |
| Base type | none |
| Interfaces | `Microsoft.eShopWeb.ApplicationCore.Interfaces.IEmailSender` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task SendEmailAsync(string email, string subject, string message)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.BaseMessage

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | API |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.PublicApi` |
| Project | `PublicApi` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | Base class used by API requests |

Public methods:
- `Guid CorrelationId()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CustomSchemaFilters

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | API |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.PublicApi` |
| Project | `PublicApi` |
| Base type | `ISchemaFilter` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void Apply(OpenApiSchema schema, SchemaFilterContext context)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.ImageValidators

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | API |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.PublicApi` |
| Project | `PublicApi` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `static bool IsValidImage(byte[] postedFile, string fileName)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.ApplicationCore.Extensions.TestChild

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.UnitTests.ApplicationCore.Extensions` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | `System.IEquatable<Microsoft.eShopWeb.UnitTests.ApplicationCore.Extensions.TestChild>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `bool Equals(TestChild other)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.ApplicationCore.Extensions.TestParent

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.UnitTests.ApplicationCore.Extensions` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | `System.IEquatable<Microsoft.eShopWeb.UnitTests.ApplicationCore.Extensions.TestParent>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `bool Equals(TestParent other)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.Web.Extensions.CacheHelpersTests.GenerateBrandsCacheKey

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.UnitTests.Web.Extensions.CacheHelpersTests` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void ReturnsBrandsCacheKey()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.Web.Extensions.CacheHelpersTests.GenerateCatalogItemCacheKey

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.UnitTests.Web.Extensions.CacheHelpersTests` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void ReturnsCatalogItemCacheKey()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.UnitTests.Web.Extensions.CacheHelpersTests.GenerateTypesCacheKey

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Tests |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.UnitTests.Web.Extensions.CacheHelpersTests` |
| Project | `UnitTests` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void ReturnsTypesCacheKey()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Configuration.ConfigureCookieSettings

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.Web.Configuration` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `static IServiceCollection AddCookieSettings(IServiceCollection services)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.HealthChecks.HomePageHealthCheck

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.Web.HealthChecks` |
| Project | `Web` |
| Base type | none |
| Interfaces | `Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Pages.Basket.SuccessModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.Web.Pages.Basket` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.RazorPages.PageModel` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void OnGet()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Pages.ErrorModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.Web.Pages` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.RazorPages.PageModel` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void OnGet()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Pages.PrivacyModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.Web.Pages` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.RazorPages.PageModel` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void OnGet()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Services.EmailSenderExtensions

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.Web.Services` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `static Task SendEmailConfirmationAsync(IEmailSender emailSender, string email, string link)`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.SlugifyParameterTransformer

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 20 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.Web` |
| Project | `Web` |
| Base type | none |
| Interfaces | `Microsoft.AspNetCore.Routing.IOutboundParameterTransformer` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `string? TransformOutbound(object? value)`

Semantic dependencies:
- none

## BlazorAdmin.Helpers.RefreshBroadcast

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 18 |
| Reason | 2 semantic deps |
| Namespace | `BlazorAdmin.Helpers` |
| Project | `BlazorAdmin` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- `void CallRequestRefresh()`

Semantic dependencies:
- none

## BlazorAdmin.JavaScript.JSInteropConstants

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BlazorAdmin.JavaScript` |
| Project | `BlazorAdmin` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorAdmin.Services.CacheEntry<T>

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BlazorAdmin.Services` |
| Project | `BlazorAdmin` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorAdmin.Shared.CustomInputSelect<TValue>

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BlazorAdmin.Shared` |
| Project | `BlazorAdmin` |
| Base type | `InputSelect<TValue>` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | This is needed until 5.0 ships with native support https://www.pragimtech.com/blog/blazor/inputselect-does-not-support-system.int32/ |

Public methods:
- none

Semantic dependencies:
- none

## BlazorShared.Attributes.EndpointAttribute

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BlazorShared.Attributes` |
| Project | `BlazorShared` |
| Base type | `System.Attribute` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorShared.BaseUrlConfiguration

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BlazorShared` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorShared.Models.CatalogBrand

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BlazorShared.Models` |
| Project | `BlazorShared` |
| Base type | `BlazorShared.Models.LookupData` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorShared.Models.CatalogType

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BlazorShared.Models` |
| Project | `BlazorShared` |
| Base type | `BlazorShared.Models.LookupData` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorShared.Models.LookupData

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `BlazorShared.Models` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Exceptions.BasketNotFoundException

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Application |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Exceptions` |
| Project | `ApplicationCore` |
| Base type | `System.Exception` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Exceptions.DuplicateException

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Application |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Exceptions` |
| Project | `ApplicationCore` |
| Base type | `System.Exception` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.ApplicationCore.Interfaces.IAggregateRoot

| Field | Value |
| --- | --- |
| Kind | Interface |
| Role | Unknown |
| Layer | Application |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.ApplicationCore.Interfaces` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.CatalogSettings

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Application |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb` |
| Project | `ApplicationCore` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Infrastructure.Data.FileItem

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | Infrastructure |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.Infrastructure.Data` |
| Project | `Infrastructure` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.AuthEndpoints.ClaimValue

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ValueObject |
| Layer | API |
| Relevance | Low / 18 |
| Reason | role ValueObject |
| Namespace | `Microsoft.eShopWeb.PublicApi.AuthEndpoints` |
| Project | `PublicApi` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Constants

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.Web` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Pages.Admin.IndexModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `Microsoft.eShopWeb.Web.Pages.Admin` |
| Project | `Web` |
| Base type | `Microsoft.AspNetCore.Mvc.RazorPages.PageModel` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Program

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | Unknown |
| Layer | API |
| Relevance | Low / 18 |
| Reason | low architectural signal |
| Namespace | `` |
| Project | `PublicApi` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.Manage.TwoFactorAuthenticationViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 11 |
| Reason | role ViewModel; patterns ViewModel; dangerous zone |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels.Manage` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorShared.Models.CreateCatalogItemResponse

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | UI |
| Relevance | Low / 9 |
| Reason | role DTO; 1 semantic deps |
| Namespace | `BlazorShared.Models` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemResponse

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 9 |
| Reason | role DTO; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints` |
| Project | `PublicApi` |
| Base type | `Microsoft.eShopWeb.PublicApi.BaseResponse` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.GetByIdCatalogItemResponse

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 9 |
| Reason | role DTO; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints` |
| Project | `PublicApi` |
| Base type | `Microsoft.eShopWeb.PublicApi.BaseResponse` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.UpdateCatalogItemResponse

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 9 |
| Reason | role DTO; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints` |
| Project | `PublicApi` |
| Base type | `Microsoft.eShopWeb.PublicApi.BaseResponse` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorShared.Interfaces.ILookupDataResponse<TLookupData>

| Field | Value |
| --- | --- |
| Kind | Interface |
| Role | DTO |
| Layer | UI |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `BlazorShared.Interfaces` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorShared.Models.CatalogBrandResponse

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | UI |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `BlazorShared.Models` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | `BlazorShared.Interfaces.ILookupDataResponse<BlazorShared.Models.CatalogBrand>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorShared.Models.CatalogTypeResponse

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | UI |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `BlazorShared.Models` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | `BlazorShared.Interfaces.ILookupDataResponse<BlazorShared.Models.CatalogType>` |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorShared.Models.CreateCatalogItemRequest

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | UI |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `BlazorShared.Models` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorShared.Models.DeleteCatalogItemResponse

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | UI |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `BlazorShared.Models` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorShared.Models.PagedCatalogItemResponse

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | UI |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `BlazorShared.Models` |
| Project | `BlazorShared` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.AuthEndpoints.AuthenticateRequest

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `Microsoft.eShopWeb.PublicApi.AuthEndpoints` |
| Project | `PublicApi` |
| Base type | `Microsoft.eShopWeb.PublicApi.BaseRequest` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.AuthEndpoints.AuthenticateResponse

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `Microsoft.eShopWeb.PublicApi.AuthEndpoints` |
| Project | `PublicApi` |
| Base type | `Microsoft.eShopWeb.PublicApi.BaseResponse` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.BaseRequest

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `Microsoft.eShopWeb.PublicApi` |
| Project | `PublicApi` |
| Base type | `Microsoft.eShopWeb.PublicApi.BaseMessage` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | Base class used by API requests |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.BaseResponse

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `Microsoft.eShopWeb.PublicApi` |
| Project | `PublicApi` |
| Base type | `Microsoft.eShopWeb.PublicApi.BaseMessage` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | Base class used by API responses |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints.ListCatalogBrandsResponse

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints` |
| Project | `PublicApi` |
| Base type | `Microsoft.eShopWeb.PublicApi.BaseResponse` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemRequest

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints` |
| Project | `PublicApi` |
| Base type | `Microsoft.eShopWeb.PublicApi.BaseRequest` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.DeleteCatalogItemRequest

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints` |
| Project | `PublicApi` |
| Base type | `Microsoft.eShopWeb.PublicApi.BaseRequest` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.DeleteCatalogItemResponse

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints` |
| Project | `PublicApi` |
| Base type | `Microsoft.eShopWeb.PublicApi.BaseResponse` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.GetByIdCatalogItemRequest

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints` |
| Project | `PublicApi` |
| Base type | `Microsoft.eShopWeb.PublicApi.BaseRequest` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.ListPagedCatalogItemRequest

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints` |
| Project | `PublicApi` |
| Base type | `Microsoft.eShopWeb.PublicApi.BaseRequest` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.ListPagedCatalogItemResponse

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints` |
| Project | `PublicApi` |
| Base type | `Microsoft.eShopWeb.PublicApi.BaseResponse` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.UpdateCatalogItemRequest

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints` |
| Project | `PublicApi` |
| Base type | `Microsoft.eShopWeb.PublicApi.BaseRequest` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints.ListCatalogTypesResponse

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 6 |
| Reason | role DTO |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints` |
| Project | `PublicApi` |
| Base type | `Microsoft.eShopWeb.PublicApi.BaseResponse` |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## BlazorAdmin.Services.ToastLevel

| Field | Value |
| --- | --- |
| Kind | Enum |
| Role | Unknown |
| Layer | UI |
| Relevance | Low / 3 |
| Reason | low architectural signal |
| Namespace | `BlazorAdmin.Services` |
| Project | `BlazorAdmin` |
| Base type | none |
| Interfaces | none |
| Patterns | none |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints.CatalogBrandDto

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 0 |
| Reason | role DTO; patterns Dto |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints` |
| Project | `PublicApi` |
| Base type | none |
| Interfaces | none |
| Patterns | `Dto` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CatalogItemDto

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 0 |
| Reason | role DTO; patterns Dto |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints` |
| Project | `PublicApi` |
| Base type | none |
| Interfaces | none |
| Patterns | `Dto` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints.CatalogTypeDto

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | DTO |
| Layer | API |
| Relevance | Low / 0 |
| Reason | role DTO; patterns Dto |
| Namespace | `Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints` |
| Project | `PublicApi` |
| Base type | none |
| Interfaces | none |
| Patterns | `Dto` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Pages.Basket.BasketItemViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.Pages.Basket` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.Pages.Basket.BasketViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.Pages.Basket` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- `decimal Total()`

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.Account.LoginViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels.Account` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.Account.LoginWith2faViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels.Account` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.Account.RegisterViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels.Account` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.Account.ResetPasswordViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels.Account` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.BasketComponentViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.CatalogIndexViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.CatalogItemViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.File.FileViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels.File` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.Manage.ChangePasswordViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels.Manage` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.Manage.EnableAuthenticatorViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels.Manage` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.Manage.ExternalLoginsViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels.Manage` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.Manage.IndexViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels.Manage` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.Manage.RemoveLoginViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels.Manage` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.Manage.SetPasswordViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels.Manage` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.Manage.ShowRecoveryCodesViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels.Manage` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.OrderDetailViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels` |
| Project | `Web` |
| Base type | `Microsoft.eShopWeb.Web.ViewModels.OrderViewModel` |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.OrderItemViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.OrderViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel; 1 semantic deps |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

## Microsoft.eShopWeb.Web.ViewModels.PaginationInfoViewModel

| Field | Value |
| --- | --- |
| Kind | Class |
| Role | ViewModel |
| Layer | UI |
| Relevance | Low / 0 |
| Reason | role ViewModel; patterns ViewModel |
| Namespace | `Microsoft.eShopWeb.Web.ViewModels` |
| Project | `Web` |
| Base type | none |
| Interfaces | none |
| Patterns | `ViewModel` |
| Technologies | none |
| Summary | none |

Public methods:
- none

Semantic dependencies:
- none

