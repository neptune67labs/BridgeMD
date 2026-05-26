# Key Types

High-signal types for navigation. This file intentionally favors architecture and domain signal over exhaustive listings.

| Type | Role | Layer | Score | Category | Why |
| --- | --- | --- | ---: | --- | --- |
| `Microsoft.eShopWeb.Infrastructure.Data.CatalogContext` | DbContext | Infrastructure | 100 | High | role DbContext; patterns DbContext; tech Entity Framework; 8 semantic deps; dangerous zone |
| `Microsoft.eShopWeb.Infrastructure.Identity.AppIdentityDbContext` | DbContext | Infrastructure | 100 | High | role DbContext; patterns DbContext; tech Entity Framework; 1 semantic deps; dangerous zone |
| `Microsoft.eShopWeb.Infrastructure.Identity.AppIdentityDbContextSeed` | DbContext | Infrastructure | 100 | High | role DbContext; patterns DbContext; tech Entity Framework; dangerous zone |
| `Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints.CatalogBrandListEndpoint` | Endpoint | API | 100 | High | role Endpoint; patterns Repository |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CatalogItemGetByIdEndpoint` | Endpoint | API | 100 | High | role Endpoint; patterns Repository; 1 semantic deps |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CatalogItemListPagedEndpoint` | Endpoint | API | 100 | High | role Endpoint; patterns Repository; 1 semantic deps |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemEndpoint` | Endpoint | API | 100 | High | role Endpoint; patterns Repository; 1 semantic deps |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.DeleteCatalogItemEndpoint` | Endpoint | API | 100 | High | role Endpoint; patterns Repository |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.UpdateCatalogItemEndpoint` | Endpoint | API | 100 | High | role Endpoint; patterns Repository; 1 semantic deps |
| `Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints.CatalogTypeListEndpoint` | Endpoint | API | 100 | High | role Endpoint; patterns Repository |
| `Microsoft.eShopWeb.Web.Controllers.ManageController` | Controller | API | 100 | High | role Controller; patterns Controller; tech ASP.NET Controllers; 2 semantic deps |
| `Microsoft.eShopWeb.Web.Controllers.OrderController` | Controller | API | 100 | High | role Controller; patterns Controller; tech ASP.NET Controllers; 1 semantic deps |
| `Microsoft.eShopWeb.Web.Controllers.UserController` | Controller | API | 100 | High | role Controller; patterns Controller; tech ASP.NET Controllers; 1 semantic deps |
| `Microsoft.eShopWeb.Web.Controllers.Api.BaseApiController` | Controller | API | 98 | High | role Controller; patterns Controller; tech ASP.NET Controllers |
| `Microsoft.eShopWeb.PublicApi.AuthEndpoints.AuthenticateEndpoint` | Endpoint | API | 58 | Medium | role Endpoint; 1 semantic deps |
| `Microsoft.eShopWeb.Web.Features.MyOrders.GetMyOrdersHandler` | CQRSHandler | Application | 73 | High | role CQRSHandler; patterns Handler, ViewModel; tech CQRS; 1 semantic deps |
| `Microsoft.eShopWeb.Web.Features.OrderDetails.GetOrderDetailsHandler` | CQRSHandler | Application | 73 | High | role CQRSHandler; patterns Handler, ViewModel; tech CQRS; 1 semantic deps |
| `Microsoft.eShopWeb.Infrastructure.Data.EfRepository<T>` | Repository | Infrastructure | 91 | High | role Repository; patterns Repository; 1 semantic deps |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.IReadRepository<T>` | Repository | Application | 88 | High | role Repository; patterns Repository |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<T>` | Repository | Application | 88 | High | role Repository; patterns Repository |
| `BlazorAdmin.Services.CatalogItemService` | ApplicationService | UI | 100 | High | role ApplicationService; patterns Service; 3 semantic deps |
| `BlazorShared.Interfaces.ICatalogItemService` | ApplicationService | UI | 100 | High | role ApplicationService; patterns Service |
| `Microsoft.eShopWeb.ApplicationCore.Services.BasketService` | ApplicationService | Application | 100 | High | role ApplicationService; patterns Service; 2 semantic deps |
| `Microsoft.eShopWeb.ApplicationCore.Services.OrderService` | ApplicationService | Application | 100 | High | role ApplicationService; patterns Service; 4 semantic deps |
| `Microsoft.eShopWeb.Infrastructure.Identity.IdentityTokenClaimService` | ApplicationService | Infrastructure | 100 | High | role ApplicationService; patterns Service; dangerous zone |
| `BlazorAdmin.Services.HttpService` | ApplicationService | UI | 99 | High | role ApplicationService; patterns Service; 1 semantic deps |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketService` | ApplicationService | Application | 96 | High | role ApplicationService; patterns Service |
| `Microsoft.eShopWeb.Infrastructure.Data.Queries.BasketQueryService` | ApplicationService | Application | 93 | High | role ApplicationService; patterns Service; 1 semantic deps |
| `BlazorAdmin.Services.ToastService` | ApplicationService | UI | 92 | High | role ApplicationService; patterns Service |
| `BlazorAdmin.Services.CatalogLookupDataService<TLookupData, TReponse>` | ApplicationService | UI | 90 | High | role ApplicationService; patterns Service |
| `BlazorAdmin.ServicesConfiguration` | ApplicationService | UI | 90 | High | role ApplicationService; patterns Service |
| `BlazorShared.Interfaces.ICatalogLookupDataService<TLookupData>` | ApplicationService | UI | 90 | High | role ApplicationService; patterns Service |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketQueryService` | ApplicationService | Application | 90 | High | role ApplicationService; patterns Service |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.IOrderService` | ApplicationService | Application | 90 | High | role ApplicationService; patterns Service |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.ITokenClaimsService` | ApplicationService | Application | 90 | High | role ApplicationService; patterns Service |
| `Microsoft.eShopWeb.Web.Configuration.ConfigureCoreServices` | ApplicationService | UI | 90 | High | role ApplicationService; patterns Service |
| `Microsoft.eShopWeb.Web.Configuration.ConfigureWebServices` | ApplicationService | UI | 90 | High | role ApplicationService; patterns Service |
| `Microsoft.eShopWeb.PublicApi.Middleware.ExceptionMiddleware` | Middleware | API | 60 | Medium | role Middleware; patterns Middleware; dangerous zone |
| `Microsoft.eShopWeb.Infrastructure.Data.Config.BasketConfiguration` | Configuration | Infrastructure | 38 | Medium | role Configuration |
| `Microsoft.eShopWeb.Infrastructure.Data.Config.BasketItemConfiguration` | Configuration | Infrastructure | 38 | Medium | role Configuration |
| `Microsoft.eShopWeb.Infrastructure.Data.Config.CatalogBrandConfiguration` | Configuration | Infrastructure | 38 | Medium | role Configuration |
| `Microsoft.eShopWeb.Infrastructure.Data.Config.CatalogItemConfiguration` | Configuration | Infrastructure | 38 | Medium | role Configuration |
| `Microsoft.eShopWeb.Infrastructure.Data.Config.CatalogTypeConfiguration` | Configuration | Infrastructure | 38 | Medium | role Configuration |
| `Microsoft.eShopWeb.Infrastructure.Data.Config.OrderConfiguration` | Configuration | Infrastructure | 38 | Medium | role Configuration |
| `Microsoft.eShopWeb.Infrastructure.Data.Config.OrderItemConfiguration` | Configuration | Infrastructure | 38 | Medium | role Configuration |
| `Microsoft.eShopWeb.ApplicationCore.Specifications.BasketWithItemsSpecification` | Specification | Application | 61 | Medium | role Specification; patterns Specification |
| `Microsoft.eShopWeb.ApplicationCore.Specifications.CatalogFilterPaginatedSpecification` | Specification | Application | 61 | Medium | role Specification; patterns Specification |
| `Microsoft.eShopWeb.ApplicationCore.Specifications.CatalogFilterSpecification` | Specification | Application | 61 | Medium | role Specification; patterns Specification |
| `Microsoft.eShopWeb.ApplicationCore.Specifications.CatalogItemNameSpecification` | Specification | Application | 61 | Medium | role Specification; patterns Specification |
| `Microsoft.eShopWeb.ApplicationCore.Specifications.CatalogItemsSpecification` | Specification | Application | 61 | Medium | role Specification; patterns Specification |
| `Microsoft.eShopWeb.ApplicationCore.Specifications.CustomerOrdersSpecification` | Specification | Application | 61 | Medium | role Specification; patterns Specification |
| `Microsoft.eShopWeb.ApplicationCore.Specifications.CustomerOrdersWithItemsSpecification` | Specification | Application | 61 | Medium | role Specification; patterns Specification |
| `Microsoft.eShopWeb.ApplicationCore.Specifications.OrderWithItemsByIdSpec` | Specification | Application | 61 | Medium | role Specification; patterns Specification |
| `Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem` | AggregateRoot | Domain | 50 | Medium | role AggregateRoot; 2 semantic deps |
| `Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate.PaymentMethod` | Entity | Domain | 45 | Medium | role Entity; dangerous zone |
| `Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate.Basket` | AggregateRoot | Domain | 42 | Medium | role AggregateRoot |
| `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Order` | AggregateRoot | Domain | 41 | Medium | role AggregateRoot; 1 semantic deps |
| `Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate.Buyer` | AggregateRoot | Domain | 36 | Medium | role AggregateRoot |
| `Microsoft.eShopWeb.ApplicationCore.Entities.CatalogBrand` | AggregateRoot | Domain | 36 | Medium | role AggregateRoot |
| `Microsoft.eShopWeb.ApplicationCore.Entities.CatalogType` | AggregateRoot | Domain | 36 | Medium | role AggregateRoot |
| `Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate.BasketItem` | Entity | Domain | 34 | Low | role Entity |
| `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.OrderItem` | Entity | Domain | 33 | Low | role Entity; 1 semantic deps |
| `Microsoft.eShopWeb.ApplicationCore.Entities.BaseEntity` | Entity | Domain | 30 | Low | role Entity |
| `Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem.CatalogItemDetails` | Entity | Domain | 30 | Low | role Entity |
| `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Address` | Entity | Domain | 30 | Low | role Entity |
| `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.CatalogItemOrdered` | Entity | Domain | 30 | Low | role Entity |
| `BlazorAdmin.Services.CachedCatalogItemServiceDecorator` | Decorator | UI | 99 | High | role Decorator; patterns Service; 2 semantic deps |
| `BlazorAdmin.Services.CachedCatalogLookupDataServiceDecorator<TLookupData, TReponse>` | Decorator | UI | 89 | High | role Decorator; patterns Service; 2 semantic deps |
| `Microsoft.eShopWeb.Infrastructure.Logging.LoggerAdapter<T>` | Adapter | Infrastructure | 22 | Low | role Adapter |
| `Microsoft.eShopWeb.PublicApi.MappingProfile` | Mapper | API | 30 | Low | role Mapper |
| `Microsoft.eShopWeb.Web.Services.BasketViewModelService` | ViewModel | UI | 59 | Medium | role ViewModel; patterns Service, ViewModel; 4 semantic deps |
| `Microsoft.eShopWeb.Web.Services.CatalogViewModelService` | ViewModel | UI | 59 | Medium | role ViewModel; patterns Service, ViewModel; 4 semantic deps |
| `Microsoft.eShopWeb.Web.Services.CachedCatalogViewModelService` | ViewModel | UI | 50 | Medium | role ViewModel; patterns Service, ViewModel; 1 semantic deps |
| `Microsoft.eShopWeb.Web.Interfaces.IBasketViewModelService` | ViewModel | UI | 47 | Medium | role ViewModel; patterns Service, ViewModel |
| `Microsoft.eShopWeb.Web.Services.ICatalogViewModelService` | ViewModel | UI | 47 | Medium | role ViewModel; patterns Service, ViewModel |
| `Microsoft.eShopWeb.Web.Services.CatalogItemViewModelService` | ViewModel | UI | 46 | Medium | role ViewModel; patterns Service, ViewModel; 1 semantic deps |
| `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.LoginModel` | Unknown | UI | 43 | Medium | 2 semantic deps; dangerous zone |
| `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.RegisterModel` | Unknown | UI | 43 | Medium | 2 semantic deps; dangerous zone |
| `Microsoft.eShopWeb.Web.Interfaces.ICatalogItemViewModelService` | ViewModel | UI | 43 | Medium | role ViewModel; patterns Service, ViewModel |
| `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.LogoutModel` | Unknown | UI | 37 | Medium | dangerous zone |
| `Microsoft.eShopWeb.Web.Pages.Basket.CheckoutModel` | Unknown | UI | 37 | Medium | 5 semantic deps |
| `BlazorAdmin.Pages.CatalogItemPage.List` | Unknown | UI | 36 | Medium | 7 semantic deps |
| `BlazorShared.Authorization.UserInfo` | Unknown | UI | 36 | Medium | 1 semantic deps; dangerous zone |
| `Microsoft.eShopWeb.Web.Pages.Basket.IndexModel` | Unknown | UI | 36 | Medium | 4 semantic deps |
| `Microsoft.eShopWeb.Web.Areas.Identity.IdentityHostingStartup` | Unknown | UI | 35 | Medium | dangerous zone |
| `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.ConfirmEmailModel` | Unknown | UI | 35 | Medium | dangerous zone |
| `Microsoft.eShopWeb.Web.Configuration.RevokeAuthenticationEvents` | Unknown | UI | 35 | Medium | dangerous zone |
| `BlazorShared.Authorization.ClaimValue` | ValueObject | UI | 33 | Low | role ValueObject; dangerous zone |
| `Microsoft.eShopWeb.PublicApi.AuthEndpoints.ClaimValue` | ValueObject | API | 18 | Low | role ValueObject |
