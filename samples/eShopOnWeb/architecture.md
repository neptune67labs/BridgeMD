# Architecture

## Layers

| Layer | Projects | Key Types | Key Roles | Responsibility |
| --- | --- | --- | --- | --- |
| API | `PublicApi`, `Web` | `CatalogBrandListEndpoint`, `CatalogItemGetByIdEndpoint`, `CatalogItemListPagedEndpoint`, `CreateCatalogItemEndpoint`, `DeleteCatalogItemEndpoint`, `UpdateCatalogItemEndpoint`, `CatalogTypeListEndpoint`, `ManageController` | `Endpoint`, `Middleware`, `Mapper`, `ValueObject`, `DTO`, `Controller` | HTTP endpoints, controllers, request/response boundary. |
| Application | `ApplicationCore`, `Infrastructure`, `Web` | `BasketService`, `OrderService`, `IBasketService`, `BasketQueryService`, `IBasketQueryService`, `IOrderService`, `ITokenClaimsService`, `IReadRepository` | `ApplicationService`, `Repository`, `Specification`, `CQRSHandler`, `ViewModel` | Use cases, orchestration, commands, queries, services. |
| Domain | `ApplicationCore` | `CatalogItem`, `PaymentMethod`, `Basket`, `Order`, `Buyer`, `CatalogBrand`, `CatalogType`, `BasketItem` | `AggregateRoot`, `Entity` | Business concepts, rules, entities, aggregates. |
| Infrastructure | `Infrastructure` | `CatalogContext`, `AppIdentityDbContext`, `AppIdentityDbContextSeed`, `IdentityTokenClaimService`, `EfRepository`, `BasketConfiguration`, `BasketItemConfiguration`, `CatalogBrandConfiguration` | `DbContext`, `ApplicationService`, `Repository`, `Configuration`, `Adapter` | Persistence, external integrations, IoC, EF, repositories. |
| Tests | `FunctionalTests`, `IntegrationTests`, `PublicApiIntegrationTests`, `UnitTests` | `AccountControllerSignIn`, `CatalogControllerIndex`, `CustomerOrdersWithItemsSpecification`, `CatalogFilterPaginatedSpecification`, `CatalogFilterSpecification`, `CatalogItemsSpecification`, `CatalogItemListPagedEndpoint`, `AuthenticateEndpoint` | `Controller`, `Endpoint`, `ViewModel`, `Repository`, `Specification`, `Entity` | Validation and regression coverage. |
| UI | `BlazorAdmin`, `BlazorShared`, `Web` | `CatalogItemService`, `ICatalogItemService`, `CachedCatalogItemServiceDecorator`, `HttpService`, `ToastService`, `CatalogLookupDataService`, `ServicesConfiguration`, `ICatalogLookupDataService` | `ApplicationService`, `Decorator`, `ValueObject`, `DTO`, `ViewModel` | User interface, MVC/Razor/Blazor pages and views. |

## Project Dependencies

| From | To | Inferred Rule |
| --- | --- | --- |
| `ApplicationCore` (Application) | `BlazorShared` (UI) | suspicious: application depending on presentation |
| `BlazorAdmin` (UI) | `BlazorShared` (UI) | allowed or not enough context |
| `FunctionalTests` (Tests) | `ApplicationCore` (Application) | allowed or not enough context |
| `FunctionalTests` (Tests) | `PublicApi` (API) | allowed or not enough context |
| `FunctionalTests` (Tests) | `Web` (UI) | allowed or not enough context |
| `Infrastructure` (Infrastructure) | `ApplicationCore` (Application) | typical: infrastructure implements lower-level abstractions |
| `IntegrationTests` (Tests) | `Infrastructure` (Infrastructure) | allowed or not enough context |
| `IntegrationTests` (Tests) | `UnitTests` (Tests) | allowed or not enough context |
| `PublicApi` (API) | `ApplicationCore` (Application) | allowed or not enough context |
| `PublicApi` (API) | `Infrastructure` (Infrastructure) | allowed or not enough context |
| `PublicApiIntegrationTests` (Tests) | `PublicApi` (API) | allowed or not enough context |
| `PublicApiIntegrationTests` (Tests) | `Web` (UI) | allowed or not enough context |
| `UnitTests` (Tests) | `ApplicationCore` (Application) | allowed or not enough context |
| `UnitTests` (Tests) | `Web` (UI) | allowed or not enough context |
| `Web` (UI) | `ApplicationCore` (Application) | allowed or not enough context |
| `Web` (UI) | `BlazorAdmin` (UI) | allowed or not enough context |
| `Web` (UI) | `BlazorShared` (UI) | allowed or not enough context |
| `Web` (UI) | `Infrastructure` (Infrastructure) | allowed or not enough context |
