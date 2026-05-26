# Request Flows

## Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints.CatalogBrandListEndpoint

- Entry role: `Endpoint`
- Layer: `API`
- Flow: Endpoint:CatalogBrandListEndpoint

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CatalogItemGetByIdEndpoint

- Entry role: `Endpoint`
- Layer: `API`
- Flow: Endpoint:CatalogItemGetByIdEndpoint

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CatalogItemListPagedEndpoint

- Entry role: `Endpoint`
- Layer: `API`
- Flow: Endpoint:CatalogItemListPagedEndpoint

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemEndpoint

- Entry role: `Endpoint`
- Layer: `API`
- Flow: Endpoint:CreateCatalogItemEndpoint

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.DeleteCatalogItemEndpoint

- Entry role: `Endpoint`
- Layer: `API`
- Flow: Endpoint:DeleteCatalogItemEndpoint

## Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.UpdateCatalogItemEndpoint

- Entry role: `Endpoint`
- Layer: `API`
- Flow: Endpoint:UpdateCatalogItemEndpoint

## Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints.CatalogTypeListEndpoint

- Entry role: `Endpoint`
- Layer: `API`
- Flow: Endpoint:CatalogTypeListEndpoint

## Microsoft.eShopWeb.Web.Controllers.ManageController

- Entry role: `Controller`
- Layer: `API`
- Flow: Controller:ManageController -> Adapter:LoggerAdapter

## Microsoft.eShopWeb.Web.Controllers.OrderController

- Entry role: `Controller`
- Layer: `API`
- Flow: Controller:OrderController

## Microsoft.eShopWeb.Web.Controllers.UserController

- Entry role: `Controller`
- Layer: `API`
- Flow: Controller:UserController -> ApplicationService:IdentityTokenClaimService

## Microsoft.eShopWeb.Web.Controllers.Api.BaseApiController

- Entry role: `Controller`
- Layer: `API`
- Flow: Controller:BaseApiController

## Microsoft.eShopWeb.PublicApi.AuthEndpoints.AuthenticateEndpoint

- Entry role: `Endpoint`
- Layer: `API`
- Flow: Endpoint:AuthenticateEndpoint -> ApplicationService:IdentityTokenClaimService

## Microsoft.eShopWeb.Web.Features.MyOrders.GetMyOrdersHandler

- Entry role: `CQRSHandler`
- Layer: `Application`
- Flow: CQRSHandler:GetMyOrdersHandler -> Repository:EfRepository -> DbContext:CatalogContext -> AggregateRoot:CatalogItem -> AggregateRoot:CatalogBrand -> AggregateRoot:CatalogType -> AggregateRoot:Basket -> AggregateRoot:Order -> Entity:Address

## Microsoft.eShopWeb.Web.Features.OrderDetails.GetOrderDetailsHandler

- Entry role: `CQRSHandler`
- Layer: `Application`
- Flow: CQRSHandler:GetOrderDetailsHandler -> Repository:EfRepository -> DbContext:CatalogContext -> AggregateRoot:CatalogItem -> AggregateRoot:CatalogBrand -> AggregateRoot:CatalogType -> AggregateRoot:Basket -> AggregateRoot:Order -> Entity:Address

## BlazorAdmin.Services.CatalogItemService

- Entry role: `ApplicationService`
- Layer: `UI`
- Flow: ApplicationService:CatalogItemService -> ApplicationService:HttpService -> ApplicationService:ToastService -> Decorator:CachedCatalogLookupDataServiceDecorator -> ApplicationService:CatalogLookupDataService

## BlazorShared.Interfaces.ICatalogItemService

- Entry role: `ApplicationService`
- Layer: `UI`
- Flow: ApplicationService:ICatalogItemService

## Microsoft.eShopWeb.ApplicationCore.Services.BasketService

- Entry role: `ApplicationService`
- Layer: `Application`
- Flow: ApplicationService:BasketService -> Repository:EfRepository -> DbContext:CatalogContext -> AggregateRoot:CatalogItem -> AggregateRoot:CatalogBrand -> AggregateRoot:CatalogType -> AggregateRoot:Basket -> AggregateRoot:Order -> Entity:Address -> Adapter:LoggerAdapter

## Microsoft.eShopWeb.ApplicationCore.Services.OrderService

- Entry role: `ApplicationService`
- Layer: `Application`
- Flow: ApplicationService:OrderService -> Repository:EfRepository -> DbContext:CatalogContext -> AggregateRoot:CatalogItem -> AggregateRoot:CatalogBrand -> AggregateRoot:CatalogType -> AggregateRoot:Basket -> AggregateRoot:Order -> Entity:Address

## Microsoft.eShopWeb.Infrastructure.Identity.IdentityTokenClaimService

- Entry role: `ApplicationService`
- Layer: `Infrastructure`
- Flow: ApplicationService:IdentityTokenClaimService

## BlazorAdmin.Services.HttpService

- Entry role: `ApplicationService`
- Layer: `UI`
- Flow: ApplicationService:HttpService -> ApplicationService:ToastService

## Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketService

- Entry role: `ApplicationService`
- Layer: `Application`
- Flow: ApplicationService:IBasketService

## Microsoft.eShopWeb.Infrastructure.Data.Queries.BasketQueryService

- Entry role: `ApplicationService`
- Layer: `Application`
- Flow: ApplicationService:BasketQueryService -> DbContext:CatalogContext -> AggregateRoot:CatalogItem -> AggregateRoot:CatalogBrand -> AggregateRoot:CatalogType -> AggregateRoot:Basket -> AggregateRoot:Order -> Entity:Address

## BlazorAdmin.Services.ToastService

- Entry role: `ApplicationService`
- Layer: `UI`
- Flow: ApplicationService:ToastService

## BlazorAdmin.Services.CatalogLookupDataService<TLookupData, TReponse>

- Entry role: `ApplicationService`
- Layer: `UI`
- Flow: ApplicationService:CatalogLookupDataService

## BlazorAdmin.ServicesConfiguration

- Entry role: `ApplicationService`
- Layer: `UI`
- Flow: ApplicationService:ServicesConfiguration

## BlazorShared.Interfaces.ICatalogLookupDataService<TLookupData>

- Entry role: `ApplicationService`
- Layer: `UI`
- Flow: ApplicationService:ICatalogLookupDataService

## Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketQueryService

- Entry role: `ApplicationService`
- Layer: `Application`
- Flow: ApplicationService:IBasketQueryService

## Microsoft.eShopWeb.ApplicationCore.Interfaces.IOrderService

- Entry role: `ApplicationService`
- Layer: `Application`
- Flow: ApplicationService:IOrderService

## Microsoft.eShopWeb.ApplicationCore.Interfaces.ITokenClaimsService

- Entry role: `ApplicationService`
- Layer: `Application`
- Flow: ApplicationService:ITokenClaimsService

## Microsoft.eShopWeb.Web.Configuration.ConfigureCoreServices

- Entry role: `ApplicationService`
- Layer: `UI`
- Flow: ApplicationService:ConfigureCoreServices

## Microsoft.eShopWeb.Web.Configuration.ConfigureWebServices

- Entry role: `ApplicationService`
- Layer: `UI`
- Flow: ApplicationService:ConfigureWebServices

