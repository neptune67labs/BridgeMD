# Business Domains

| Signal | Value |
| --- | --- |
| Primary language | `Catalog`, `Basket`, `Order`, `Identity`, `Brand`, `Account`, `Manage`, `Login`, `User`, `Password`, `Area`, `Authentication` |
| Bounded contexts | `Catalog`, `Order`, `Basket`, `Admin`, `Buyer`, `Identity`, `User` |
| Core entities | `CatalogItem`, `Basket`, `Order`, `CatalogBrand`, `CatalogType`, `Buyer`, `Address`, `CatalogItemOrdered`, `BasketItem`, `OrderItem`, `PaymentMethod`, `CatalogItemDetails` |

## Core Business Entities

| Entity | Role | Context | Used By | Responsibility Signal |
| --- | --- | --- | --- | --- |
| `Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem` | AggregateRoot | `Catalog` | `OrderService`, `EditCatalogItemResult`, `CreateCatalogItemResponse`, `CatalogContext`, `BasketViewModelService`, `CatalogViewModelService` | aggregate boundary |
| `Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate.Basket` | AggregateRoot | `Basket` | `BasketService`, `OrderService`, `CatalogContext`, `TransferBasket`, `AddItemToBasket`, `BasketBuilder` | aggregate boundary |
| `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Order` | AggregateRoot | `Order` | `OrderService`, `CatalogContext`, `OrderBuilder`, `GetMyOrders`, `GetOrderDetails`, `GetMyOrdersHandler` | aggregate boundary |
| `Microsoft.eShopWeb.ApplicationCore.Entities.CatalogBrand` | AggregateRoot | `Catalog` | `CatalogItem`, `CatalogContext`, `CatalogViewModelService` | aggregate boundary |
| `Microsoft.eShopWeb.ApplicationCore.Entities.CatalogType` | AggregateRoot | `Catalog` | `CatalogItem`, `CatalogContext`, `CatalogViewModelService` | aggregate boundary |
| `Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate.Buyer` | AggregateRoot | `Buyer` | none | aggregate boundary |
| `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Address` | Entity | `Order` | `Order`, `CustomerOrdersWithItemsSpecification`, `AddressBuilder`, `OrderViewModel` | business state |
| `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.CatalogItemOrdered` | Entity | `Catalog` | `OrderItem`, `OrderBuilder` | business state |
| `Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate.BasketItem` | Entity | `Basket` | `CatalogContext` | business state |
| `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.OrderItem` | Entity | `Order` | `CatalogContext` | business state |
| `Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate.PaymentMethod` | Entity | `Buyer` | none | business state |
| `Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem.CatalogItemDetails` | Entity | `Catalog` | none | business state |

## Bounded Contexts

| Context | Contains | Services | Entry Points | Dependencies |
| --- | --- | --- | --- | --- |
| `Catalog` | `CatalogItem`, `CatalogBrand`, `CatalogType`, `CatalogItemDetails`, `CatalogItemOrdered` | `CatalogItemService`, `ICatalogItemService`, `CatalogLookupDataService`, `ICatalogLookupDataService` | `CatalogBrandListEndpoint`, `CatalogItemGetByIdEndpoint`, `CatalogItemListPagedEndpoint`, `CreateCatalogItemEndpoint`, `DeleteCatalogItemEndpoint`, `UpdateCatalogItemEndpoint`, `CatalogTypeListEndpoint` | `Admin`, `Basket`, `Composer`, `Order`, `Pagination` |
| `Order` | `Order`, `OrderItem`, `Address` | `OrderService`, `IOrderService` | `OrderController`, `GetMyOrdersHandler`, `GetOrderDetailsHandler` | `Catalog`, `Composer` |
| `Basket` | `Basket`, `BasketItem` | `BasketService`, `IBasketService`, `BasketQueryService`, `IBasketQueryService` | none | `Catalog`, `Composer`, `Logger`, `Order` |
| `Admin` | none | `HttpService`, `ToastService`, `ServicesConfiguration` | none | none |
| `Buyer` | `PaymentMethod`, `Buyer` | none | none | none |
| `Identity` | none | `IdentityTokenClaimService` | none | `Basket`, `Sender` |
| `User` | none | none | `UserController` | `Identity` |

## Use Cases

| Use Case | Entry | Flow | Entities |
| --- | --- | --- | --- |
| `Catalog Item Service` | `BlazorAdmin.Services.CatalogItemService` | ApplicationService:CatalogItemService -> ApplicationService:HttpService -> ApplicationService:ToastService -> Decorator:CachedCatalogLookupDataServiceDecorator -> ApplicationService:CatalogLookupDataService | none |
| `Basket Service` | `Microsoft.eShopWeb.ApplicationCore.Services.BasketService` | ApplicationService:BasketService -> Repository:EfRepository -> DbContext:CatalogContext -> AggregateRoot:CatalogItem -> AggregateRoot:CatalogBrand -> AggregateRoot:CatalogType -> AggregateRoot:Basket -> AggregateRoot:Order -> Entity:Address -> Adapter:LoggerAdapter | `Basket`, `BasketItem`, `CatalogBrand`, `CatalogItem`, `CatalogType`, `Order` |
| `Order Service` | `Microsoft.eShopWeb.ApplicationCore.Services.OrderService` | ApplicationService:OrderService -> Repository:EfRepository -> DbContext:CatalogContext -> AggregateRoot:CatalogItem -> AggregateRoot:CatalogBrand -> AggregateRoot:CatalogType -> AggregateRoot:Basket -> AggregateRoot:Order -> Entity:Address | `Basket`, `BasketItem`, `CatalogBrand`, `CatalogItem`, `CatalogType`, `Order` |
| `Catalog Brand List Endpoint` | `Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints.CatalogBrandListEndpoint` | Endpoint:CatalogBrandListEndpoint | none |
| `Catalog Item Get By Id Endpoint` | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CatalogItemGetByIdEndpoint` | Endpoint:CatalogItemGetByIdEndpoint | none |
| `Catalog Item List Paged Endpoint` | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CatalogItemListPagedEndpoint` | Endpoint:CatalogItemListPagedEndpoint | none |
| `Create Catalog Item Endpoint` | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemEndpoint` | Endpoint:CreateCatalogItemEndpoint | none |
| `Delete Catalog Item Endpoint` | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.DeleteCatalogItemEndpoint` | Endpoint:DeleteCatalogItemEndpoint | none |
| `Update Catalog Item Endpoint` | `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.UpdateCatalogItemEndpoint` | Endpoint:UpdateCatalogItemEndpoint | none |
| `Catalog Type List Endpoint` | `Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints.CatalogTypeListEndpoint` | Endpoint:CatalogTypeListEndpoint | none |
| `Manage Controller` | `Microsoft.eShopWeb.Web.Controllers.ManageController` | Controller:ManageController -> Adapter:LoggerAdapter | none |
| `Order Controller` | `Microsoft.eShopWeb.Web.Controllers.OrderController` | Controller:OrderController | none |
| `User Controller` | `Microsoft.eShopWeb.Web.Controllers.UserController` | Controller:UserController -> ApplicationService:IdentityTokenClaimService | none |
| `Http Service` | `BlazorAdmin.Services.HttpService` | ApplicationService:HttpService -> ApplicationService:ToastService | none |
| `Base Api Controller` | `Microsoft.eShopWeb.Web.Controllers.Api.BaseApiController` | Controller:BaseApiController | none |
| `Basket Query Service` | `Microsoft.eShopWeb.Infrastructure.Data.Queries.BasketQueryService` | ApplicationService:BasketQueryService -> DbContext:CatalogContext -> AggregateRoot:CatalogItem -> AggregateRoot:CatalogBrand -> AggregateRoot:CatalogType -> AggregateRoot:Basket -> AggregateRoot:Order -> Entity:Address | `Basket`, `BasketItem`, `CatalogBrand`, `CatalogItem`, `CatalogType`, `Order` |
| `Toast Service` | `BlazorAdmin.Services.ToastService` | ApplicationService:ToastService | none |
| `Catalog Lookup Data Service` | `BlazorAdmin.Services.CatalogLookupDataService<TLookupData, TReponse>` | ApplicationService:CatalogLookupDataService | none |
| `Services Configuration` | `BlazorAdmin.ServicesConfiguration` | ApplicationService:ServicesConfiguration | none |
| `Configure Core Services` | `Microsoft.eShopWeb.Web.Configuration.ConfigureCoreServices` | ApplicationService:ConfigureCoreServices | none |
| `Configure Web Services` | `Microsoft.eShopWeb.Web.Configuration.ConfigureWebServices` | ApplicationService:ConfigureWebServices | none |
| `Get My Orders Handler` | `Microsoft.eShopWeb.Web.Features.MyOrders.GetMyOrdersHandler` | CQRSHandler:GetMyOrdersHandler -> Repository:EfRepository -> DbContext:CatalogContext -> AggregateRoot:CatalogItem -> AggregateRoot:CatalogBrand -> AggregateRoot:CatalogType -> AggregateRoot:Basket -> AggregateRoot:Order -> Entity:Address | `Basket`, `BasketItem`, `CatalogBrand`, `CatalogItem`, `CatalogType`, `Order` |
| `Get Order Details Handler` | `Microsoft.eShopWeb.Web.Features.OrderDetails.GetOrderDetailsHandler` | CQRSHandler:GetOrderDetailsHandler -> Repository:EfRepository -> DbContext:CatalogContext -> AggregateRoot:CatalogItem -> AggregateRoot:CatalogBrand -> AggregateRoot:CatalogType -> AggregateRoot:Basket -> AggregateRoot:Order -> Entity:Address | `Basket`, `BasketItem`, `CatalogBrand`, `CatalogItem`, `CatalogType`, `Order` |
| `Authenticate Endpoint` | `Microsoft.eShopWeb.PublicApi.AuthEndpoints.AuthenticateEndpoint` | Endpoint:AuthenticateEndpoint -> ApplicationService:IdentityTokenClaimService | none |

## Domain Relationships

| Source | Relationship | Target | Evidence |
| --- | --- | --- | --- |
| `CatalogItem` | has | `CatalogBrand` | `Property` |
| `CatalogItem` | has | `CatalogType` | `Property` |
| `Order` | contains | `Address` | `ConstructorInjection` |
| `OrderItem` | uses | `CatalogItemOrdered` | `ConstructorInjection` |

## Ubiquitous Language

| Term | Occurrences | Signals |
| --- | ---: | --- |
| `Catalog` | 74 | `CatalogFilterPaginatedSpecification`, `CatalogFilterSpecification`, `CatalogItemNameSpecification`, `CatalogItemsSpecification`, `CatalogItem`, `CatalogBrand` |
| `Basket` | 36 | `BasketService`, `IBasketService`, `IBasketQueryService`, `BasketWithItemsSpecification`, `Basket`, `BasketItem` |
| `Order` | 20 | `OrderService`, `IOrderService`, `CustomerOrdersSpecification`, `CustomerOrdersWithItemsSpecification`, `OrderWithItemsByIdSpec`, `Order` |
| `Identity` | 16 | `AppIdentityDbContext`, `AppIdentityDbContextSeed`, `IdentityTokenClaimService`, `ApplicationUser`, `UserNotFoundException`, `LoginModel` |
| `Brand` | 13 | `CatalogItem`, `CatalogBrand`, `CatalogBrandResponse`, `CatalogBrandConfiguration`, `CatalogBrandListEndpoint`, `ListCatalogBrandsResponse` |
| `Account` | 12 | `ManageController`, `LoginModel`, `RegisterModel`, `LogoutModel`, `ConfirmEmailModel`, `InputModel` |
| `Manage` | 11 | `ManageController`, `ManageNavPages`, `TwoFactorAuthenticationViewModel`, `ChangePasswordViewModel`, `EnableAuthenticatorViewModel`, `ExternalLoginsViewModel` |
| `Login` | 10 | `IAppLogger`, `LoggerAdapter`, `ManageController`, `LoginModel`, `ManageNavPages`, `LoginViewModel` |
| `User` | 9 | `UserInfo`, `ApplicationUser`, `UserNotFoundException`, `UserController`, `BasketViewModelService`, `IBasketViewModelService` |
| `Password` | 8 | `ManageController`, `ManageNavPages`, `ResetPasswordViewModel`, `ChangePasswordViewModel`, `SetPasswordViewModel` |
| `Area` | 7 | `LoginModel`, `RegisterModel`, `LogoutModel`, `IdentityHostingStartup`, `ConfirmEmailModel`, `InputModel` |
| `Authentication` | 5 | `CustomAuthStateProvider`, `ManageController`, `RevokeAuthenticationEvents`, `ManageNavPages`, `TwoFactorAuthenticationViewModel` |
| `Authenticator` | 5 | `ManageController`, `EnableAuthenticatorViewModel` |
| `Authorization` | 5 | `AuthorizationConstants`, `UserInfo`, `ClaimValue`, `Constants`, `Roles` |
| `Cache` | 5 | `CachedCatalogItemServiceDecorator`, `CachedCatalogLookupDataServiceDecorator`, `CacheEntry`, `CachedCatalogViewModelService`, `CacheHelpers` |
| `Warning` | 5 | `IAppLogger`, `LoggerAdapter`, `ManageController` |
| `Authenticate` | 4 | `AuthenticateEndpoint`, `AuthenticateRequest`, `AuthenticateResponse` |
| `Blazor` | 4 | `CatalogItemService`, `CachedCatalogItemServiceDecorator`, `HttpService`, `ToastService`, `CatalogLookupDataService`, `ServicesConfiguration` |
| `Change` | 4 | `ManageController`, `ManageNavPages`, `ChangePasswordViewModel` |
| `Check` | 4 | `EmptyBasketOnCheckoutException`, `BasketGuards`, `CheckoutModel`, `ApiHealthCheck`, `HomePageHealthCheck` |
| `Claim` | 4 | `ITokenClaimsService`, `ClaimValue`, `IdentityTokenClaimService` |
| `Code` | 4 | `ManageController`, `ShowRecoveryCodesViewModel` |
| `Cookie` | 4 | `Cookies`, `ConfigureCookieSettings` |
| `Feature` | 4 | `GetMyOrdersHandler`, `GetOrderDetailsHandler`, `GetMyOrders`, `GetOrderDetails` |
| `Health` | 4 | `ApiHealthCheck`, `HomePageHealthCheck` |
| `JavaScript` | 4 | `Cookies`, `Css`, `Route`, `JSInteropConstants` |
| `Log` | 4 | `CatalogFilterPaginatedSpecification`, `CatalogFilterSpecification`, `CatalogItemNameSpecification`, `CatalogItemsSpecification`, `CatalogItem`, `CatalogBrand` |
| `OrderAggregate` | 4 | `Order`, `OrderItem`, `Address`, `CatalogItemOrdered` |
| `Quantity` | 4 | `BasketItem` |
| `Query` | 4 | `IBasketQueryService`, `BasketQueryService` |
| `Recovery` | 4 | `ManageController`, `ShowRecoveryCodesViewModel` |
| `Refresh` | 4 | `BlazorComponent`, `BlazorLayoutComponent`, `RefreshBroadcast` |
| `Seed` | 4 | `AppIdentityDbContextSeed`, `CatalogContextSeed` |
| `Send` | 4 | `IEmailSender`, `EmailSender`, `ManageController`, `EmailSenderExtensions` |
| `Show` | 4 | `ToastService`, `Css`, `ManageController`, `ShowRecoveryCodesViewModel` |
| `Toast` | 4 | `ToastService`, `ToastComponent`, `ToastLevel` |
| `Token` | 4 | `ITokenClaimsService`, `IdentityTokenClaimService` |
| `used` | 4 | none |
| `App` | 3 | `BasketService`, `OrderService`, `IBasketService`, `IBasketQueryService`, `IOrderService`, `ITokenClaimsService` |
| `Cached` | 3 | `CachedCatalogItemServiceDecorator`, `CachedCatalogLookupDataServiceDecorator`, `CachedCatalogViewModelService` |
