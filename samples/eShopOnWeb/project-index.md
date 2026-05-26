# Project Index

## ApplicationCore

- Layer: `Application`
- Purpose: Contains Repository, Service, Specification code.
- Frameworks: none
- Project references: `BlazorShared`
- Declared dependencies: `Ardalis.GuardClauses`, `Ardalis.Result`, `Ardalis.Specification`, `System.Security.Claims`, `System.Text.Json`
- Technologies: none
- Detected patterns: `Repository`, `Service`, `Specification`

| Type | Role | Layer | Score | Category | Patterns |
| --- | --- | --- | ---: | --- | --- |
| `Microsoft.eShopWeb.ApplicationCore.Services.BasketService` | ApplicationService | Application | 100 | High | `Service` |
| `Microsoft.eShopWeb.ApplicationCore.Services.OrderService` | ApplicationService | Application | 100 | High | `Service` |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketService` | ApplicationService | Application | 96 | High | `Service` |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.IBasketQueryService` | ApplicationService | Application | 90 | High | `Service` |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.IOrderService` | ApplicationService | Application | 90 | High | `Service` |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.ITokenClaimsService` | ApplicationService | Application | 90 | High | `Service` |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.IReadRepository<T>` | Repository | Application | 88 | High | `Repository` |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.IRepository<T>` | Repository | Application | 88 | High | `Repository` |
| `Microsoft.eShopWeb.ApplicationCore.Specifications.BasketWithItemsSpecification` | Specification | Application | 61 | Medium | `Specification` |
| `Microsoft.eShopWeb.ApplicationCore.Specifications.CatalogFilterPaginatedSpecification` | Specification | Application | 61 | Medium | `Specification` |
| `Microsoft.eShopWeb.ApplicationCore.Specifications.CatalogFilterSpecification` | Specification | Application | 61 | Medium | `Specification` |
| `Microsoft.eShopWeb.ApplicationCore.Specifications.CatalogItemNameSpecification` | Specification | Application | 61 | Medium | `Specification` |
| `Microsoft.eShopWeb.ApplicationCore.Specifications.CatalogItemsSpecification` | Specification | Application | 61 | Medium | `Specification` |
| `Microsoft.eShopWeb.ApplicationCore.Specifications.CustomerOrdersSpecification` | Specification | Application | 61 | Medium | `Specification` |
| `Microsoft.eShopWeb.ApplicationCore.Specifications.CustomerOrdersWithItemsSpecification` | Specification | Application | 61 | Medium | `Specification` |
| `Microsoft.eShopWeb.ApplicationCore.Specifications.OrderWithItemsByIdSpec` | Specification | Application | 61 | Medium | `Specification` |
| `Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem` | AggregateRoot | Domain | 50 | Medium | none |
| `Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate.PaymentMethod` | Entity | Domain | 45 | Medium | none |
| `Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate.Basket` | AggregateRoot | Domain | 42 | Medium | none |
| `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Order` | AggregateRoot | Domain | 41 | Medium | none |
| `Microsoft.eShopWeb.ApplicationCore.Entities.BuyerAggregate.Buyer` | AggregateRoot | Domain | 36 | Medium | none |
| `Microsoft.eShopWeb.ApplicationCore.Entities.CatalogBrand` | AggregateRoot | Domain | 36 | Medium | none |
| `Microsoft.eShopWeb.ApplicationCore.Entities.CatalogType` | AggregateRoot | Domain | 36 | Medium | none |
| `Microsoft.eShopWeb.ApplicationCore.Entities.BasketAggregate.BasketItem` | Entity | Domain | 34 | Low | none |
| `Microsoft.eShopWeb.ApplicationCore.Constants.AuthorizationConstants` | Unknown | Application | 33 | Low | none |
| `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.OrderItem` | Entity | Domain | 33 | Low | none |
| `Microsoft.eShopWeb.ApplicationCore.Entities.BaseEntity` | Entity | Domain | 30 | Low | none |
| `Microsoft.eShopWeb.ApplicationCore.Entities.CatalogItem.CatalogItemDetails` | Entity | Domain | 30 | Low | none |
| `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.Address` | Entity | Domain | 30 | Low | none |
| `Microsoft.eShopWeb.ApplicationCore.Entities.OrderAggregate.CatalogItemOrdered` | Entity | Domain | 30 | Low | none |
| `Microsoft.eShopWeb.ApplicationCore.Exceptions.EmptyBasketOnCheckoutException` | Unknown | Application | 27 | Low | none |
| `Microsoft.eShopWeb.JsonExtensions` | Unknown | Application | 25 | Low | none |
| `Microsoft.eShopWeb.ApplicationCore.Services.UriComposer` | Unknown | Application | 23 | Low | none |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.IAppLogger<T>` | Unknown | Application | 22 | Low | none |
| `Ardalis.GuardClauses.BasketGuards` | Unknown | Application | 20 | Low | none |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.IEmailSender` | Unknown | Application | 20 | Low | none |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.IUriComposer` | Unknown | Application | 20 | Low | none |
| `Microsoft.eShopWeb.ApplicationCore.Exceptions.BasketNotFoundException` | Unknown | Application | 18 | Low | none |
| `Microsoft.eShopWeb.ApplicationCore.Exceptions.DuplicateException` | Unknown | Application | 18 | Low | none |
| `Microsoft.eShopWeb.ApplicationCore.Interfaces.IAggregateRoot` | Unknown | Application | 18 | Low | none |
| `Microsoft.eShopWeb.CatalogSettings` | Unknown | Application | 18 | Low | none |

## BlazorAdmin

- Layer: `UI`
- Purpose: Contains ASP.NET Core, Blazor, Unity IoC, Service code.
- Frameworks: none
- Project references: `BlazorShared`
- Declared dependencies: `Blazored.LocalStorage`, `BlazorInputFile`, `Microsoft.AspNetCore.Components.Authorization`, `Microsoft.AspNetCore.Components.WebAssembly`, `Microsoft.AspNetCore.Components.WebAssembly.Authentication`, `Microsoft.AspNetCore.Components.WebAssembly.DevServer`, `Microsoft.Extensions.Identity.Core`, `Microsoft.Extensions.Logging.Configuration`, `System.Net.Http.Json`
- Technologies: `ASP.NET Core`, `Blazor`, `Unity IoC`
- Detected patterns: `Service`

| Type | Role | Layer | Score | Category | Patterns |
| --- | --- | --- | ---: | --- | --- |
| `BlazorAdmin.Services.CatalogItemService` | ApplicationService | UI | 100 | High | `Service` |
| `BlazorAdmin.Services.CachedCatalogItemServiceDecorator` | Decorator | UI | 99 | High | `Service` |
| `BlazorAdmin.Services.HttpService` | ApplicationService | UI | 99 | High | `Service` |
| `BlazorAdmin.Services.ToastService` | ApplicationService | UI | 92 | High | `Service` |
| `BlazorAdmin.Services.CatalogLookupDataService<TLookupData, TReponse>` | ApplicationService | UI | 90 | High | `Service` |
| `BlazorAdmin.ServicesConfiguration` | ApplicationService | UI | 90 | High | `Service` |
| `BlazorAdmin.Services.CachedCatalogLookupDataServiceDecorator<TLookupData, TReponse>` | Decorator | UI | 89 | High | `Service` |
| `BlazorAdmin.Pages.CatalogItemPage.List` | Unknown | UI | 36 | Medium | none |
| `BlazorAdmin.JavaScript.Cookies` | Unknown | UI | 25 | Low | none |
| `BlazorAdmin.JavaScript.Css` | Unknown | UI | 25 | Low | none |
| `BlazorAdmin.CustomAuthStateProvider` | Unknown | UI | 23 | Low | none |
| `BlazorAdmin.Helpers.BlazorComponent` | Unknown | UI | 23 | Low | none |
| `BlazorAdmin.Helpers.BlazorLayoutComponent` | Unknown | UI | 23 | Low | none |
| `BlazorAdmin.Helpers.ToastComponent` | Unknown | UI | 23 | Low | none |
| `BlazorAdmin.JavaScript.Route` | Unknown | UI | 23 | Low | none |
| `BlazorAdmin.Helpers.RefreshBroadcast` | Unknown | UI | 18 | Low | none |
| `BlazorAdmin.JavaScript.JSInteropConstants` | Unknown | UI | 18 | Low | none |
| `BlazorAdmin.Services.CacheEntry<T>` | Unknown | UI | 18 | Low | none |
| `BlazorAdmin.Shared.CustomInputSelect<TValue>` | Unknown | UI | 18 | Low | none |
| `BlazorAdmin.Services.ToastLevel` | Unknown | UI | 3 | Low | none |

## BlazorShared

- Layer: `UI`
- Purpose: Contains Blazor, Service code.
- Frameworks: none
- Project references: none
- Declared dependencies: `BlazorInputFile`, `FluentValidation`
- Technologies: `Blazor`
- Detected patterns: `Service`

| Type | Role | Layer | Score | Category | Patterns |
| --- | --- | --- | ---: | --- | --- |
| `BlazorShared.Interfaces.ICatalogItemService` | ApplicationService | UI | 100 | High | `Service` |
| `BlazorShared.Interfaces.ICatalogLookupDataService<TLookupData>` | ApplicationService | UI | 90 | High | `Service` |
| `BlazorShared.Authorization.UserInfo` | Unknown | UI | 36 | Medium | none |
| `BlazorShared.Authorization.ClaimValue` | ValueObject | UI | 33 | Low | none |
| `BlazorShared.Authorization.Constants` | Unknown | UI | 33 | Low | none |
| `BlazorShared.Authorization.Constants.Roles` | Unknown | UI | 33 | Low | none |
| `BlazorShared.Models.CatalogItem` | Unknown | UI | 22 | Low | none |
| `BlazorShared.Models.EditCatalogItemResult` | Unknown | UI | 21 | Low | none |
| `BlazorShared.Models.ErrorDetails` | Unknown | UI | 20 | Low | none |
| `BlazorShared.Attributes.EndpointAttribute` | Unknown | UI | 18 | Low | none |
| `BlazorShared.BaseUrlConfiguration` | Unknown | UI | 18 | Low | none |
| `BlazorShared.Models.CatalogBrand` | Unknown | UI | 18 | Low | none |
| `BlazorShared.Models.CatalogType` | Unknown | UI | 18 | Low | none |
| `BlazorShared.Models.LookupData` | Unknown | UI | 18 | Low | none |
| `BlazorShared.Models.CreateCatalogItemResponse` | DTO | UI | 9 | Low | none |
| `BlazorShared.Interfaces.ILookupDataResponse<TLookupData>` | DTO | UI | 6 | Low | none |
| `BlazorShared.Models.CatalogBrandResponse` | DTO | UI | 6 | Low | none |
| `BlazorShared.Models.CatalogTypeResponse` | DTO | UI | 6 | Low | none |
| `BlazorShared.Models.CreateCatalogItemRequest` | DTO | UI | 6 | Low | none |
| `BlazorShared.Models.DeleteCatalogItemResponse` | DTO | UI | 6 | Low | none |
| `BlazorShared.Models.PagedCatalogItemResponse` | DTO | UI | 6 | Low | none |

## FunctionalTests

- Layer: `Tests`
- Purpose: Contains ASP.NET Core, Entity Framework Core, Controller, Service, ViewModel code.
- Frameworks: none
- Project references: `ApplicationCore`, `PublicApi`, `Web`
- Declared dependencies: `Microsoft.AspNetCore.Mvc.Testing`, `Microsoft.EntityFrameworkCore.InMemory`, `Microsoft.NET.Test.Sdk`, `xunit`, `xunit.runner.visualstudio`
- Technologies: `ASP.NET Core`, `Entity Framework Core`
- Detected patterns: `Controller`, `Service`, `ViewModel`

| Type | Role | Layer | Score | Category | Patterns |
| --- | --- | --- | ---: | --- | --- |
| `Microsoft.eShopWeb.FunctionalTests.Web.Controllers.AccountControllerSignIn` | Controller | Tests | 100 | High | `Controller` |
| `Microsoft.eShopWeb.FunctionalTests.Web.Controllers.CatalogControllerIndex` | Controller | Tests | 100 | High | `Controller` |
| `Microsoft.eShopWeb.FunctionalTests.PublicApi.TestApiApplication` | Endpoint | Tests | 53 | Medium | none |
| `Microsoft.eShopWeb.FunctionalTests.Web.TestApplication` | ViewModel | Tests | 41 | Medium | `Service`, `ViewModel` |
| `Microsoft.eShopWeb.FunctionalTests.Web.Pages.Basket.IndexTest` | Unknown | Tests | 25 | Low | none |
| `Microsoft.eShopWeb.FunctionalTests.Web.Controllers.OrderIndexOnGet` | Unknown | Tests | 23 | Low | none |
| `Microsoft.eShopWeb.FunctionalTests.Web.Pages.Basket.BasketPageCheckout` | Unknown | Tests | 23 | Low | none |
| `Microsoft.eShopWeb.FunctionalTests.Web.Pages.Basket.CheckoutTest` | Unknown | Tests | 23 | Low | none |
| `Microsoft.eShopWeb.FunctionalTests.WebRazorPages.HomePageOnGet` | Unknown | Tests | 23 | Low | none |
| `Microsoft.eShopWeb.FunctionalTests.Web.Api.ApiTokenHelper` | Unknown | Tests | 22 | Low | none |
| `Microsoft.eShopWeb.FunctionalTests.Web.WebPageHelpers` | Unknown | Tests | 22 | Low | none |

## Infrastructure

- Layer: `Infrastructure`
- Purpose: Contains ASP.NET Core, Entity Framework Core, DbContext, Repository, Service code.
- Frameworks: none
- Project references: `ApplicationCore`
- Declared dependencies: `Ardalis.Specification.EntityFrameworkCore`, `Microsoft.AspNetCore.Identity.EntityFrameworkCore`, `Microsoft.EntityFrameworkCore.InMemory`, `Microsoft.EntityFrameworkCore.SqlServer`, `System.IdentityModel.Tokens.Jwt`
- Technologies: `ASP.NET Core`, `Entity Framework Core`
- Detected patterns: `DbContext`, `Repository`, `Service`

| Type | Role | Layer | Score | Category | Patterns |
| --- | --- | --- | ---: | --- | --- |
| `Microsoft.eShopWeb.Infrastructure.Data.CatalogContext` | DbContext | Infrastructure | 100 | High | `DbContext` |
| `Microsoft.eShopWeb.Infrastructure.Identity.AppIdentityDbContext` | DbContext | Infrastructure | 100 | High | `DbContext` |
| `Microsoft.eShopWeb.Infrastructure.Identity.AppIdentityDbContextSeed` | DbContext | Infrastructure | 100 | High | `DbContext` |
| `Microsoft.eShopWeb.Infrastructure.Identity.IdentityTokenClaimService` | ApplicationService | Infrastructure | 100 | High | `Service` |
| `Microsoft.eShopWeb.Infrastructure.Data.Queries.BasketQueryService` | ApplicationService | Application | 93 | High | `Service` |
| `Microsoft.eShopWeb.Infrastructure.Data.EfRepository<T>` | Repository | Infrastructure | 91 | High | `Repository` |
| `Microsoft.eShopWeb.Infrastructure.Data.Config.BasketConfiguration` | Configuration | Infrastructure | 38 | Medium | none |
| `Microsoft.eShopWeb.Infrastructure.Data.Config.BasketItemConfiguration` | Configuration | Infrastructure | 38 | Medium | none |
| `Microsoft.eShopWeb.Infrastructure.Data.Config.CatalogBrandConfiguration` | Configuration | Infrastructure | 38 | Medium | none |
| `Microsoft.eShopWeb.Infrastructure.Data.Config.CatalogItemConfiguration` | Configuration | Infrastructure | 38 | Medium | none |
| `Microsoft.eShopWeb.Infrastructure.Data.Config.CatalogTypeConfiguration` | Configuration | Infrastructure | 38 | Medium | none |
| `Microsoft.eShopWeb.Infrastructure.Data.Config.OrderConfiguration` | Configuration | Infrastructure | 38 | Medium | none |
| `Microsoft.eShopWeb.Infrastructure.Data.Config.OrderItemConfiguration` | Configuration | Infrastructure | 38 | Medium | none |
| `Microsoft.eShopWeb.Infrastructure.Identity.ApplicationUser` | Unknown | Infrastructure | 33 | Low | none |
| `Microsoft.eShopWeb.Infrastructure.Identity.UserNotFoundException` | Unknown | Infrastructure | 33 | Low | none |
| `Microsoft.eShopWeb.Infrastructure.Logging.LoggerAdapter<T>` | Adapter | Infrastructure | 22 | Low | none |
| `Microsoft.eShopWeb.Infrastructure.Data.CatalogContextSeed` | Unknown | Infrastructure | 20 | Low | none |
| `Microsoft.eShopWeb.Infrastructure.Dependencies` | Unknown | Infrastructure | 20 | Low | none |
| `Microsoft.eShopWeb.Infrastructure.Services.EmailSender` | Unknown | Infrastructure | 20 | Low | none |
| `Microsoft.eShopWeb.Infrastructure.Data.FileItem` | Unknown | Infrastructure | 18 | Low | none |

## IntegrationTests

- Layer: `Tests`
- Purpose: Contains Entity Framework Core code.
- Frameworks: none
- Project references: `Infrastructure`, `UnitTests`
- Declared dependencies: `Microsoft.EntityFrameworkCore.InMemory`, `Microsoft.NET.Test.Sdk`, `NSubstitute`, `NSubstitute.Analyzers.CSharp`, `xunit`, `xunit.runner.visualstudio`
- Technologies: `Entity Framework Core`
- Detected patterns: none

| Type | Role | Layer | Score | Category | Patterns |
| --- | --- | --- | ---: | --- | --- |
| `Microsoft.eShopWeb.IntegrationTests.Repositories.BasketRepositoryTests.SetQuantities` | Repository | Tests | 54 | Medium | none |
| `Microsoft.eShopWeb.IntegrationTests.Repositories.OrderRepositoryTests.GetById` | Repository | Tests | 54 | Medium | none |
| `Microsoft.eShopWeb.IntegrationTests.Repositories.OrderRepositoryTests.GetByIdWithItemsAsync` | Repository | Tests | 54 | Medium | none |

## PublicApi

- Layer: `API`
- Purpose: Contains ASP.NET Core, AutoMapper, Entity Framework Core, Unity IoC, Dto, Middleware, Repository code.
- Frameworks: none
- Project references: `ApplicationCore`, `Infrastructure`
- Declared dependencies: `Ardalis.ApiEndpoints`, `AutoMapper.Extensions.Microsoft.DependencyInjection`, `Microsoft.AspNetCore.Authentication.JwtBearer`, `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore`, `Microsoft.AspNetCore.Identity.EntityFrameworkCore`, `Microsoft.AspNetCore.Identity.UI`, `Microsoft.EntityFrameworkCore.InMemory`, `Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.EntityFrameworkCore.Tools`, `Microsoft.VisualStudio.Azure.Containers.Tools.Targets`, `Microsoft.VisualStudio.Web.CodeGeneration.Design`, `MinimalApi.Endpoint`, `Swashbuckle.AspNetCore`, `Swashbuckle.AspNetCore.Annotations`, `Swashbuckle.AspNetCore.SwaggerUI`, `System.IdentityModel.Tokens.Jwt`
- Technologies: `ASP.NET Core`, `AutoMapper`, `Entity Framework Core`, `Unity IoC`
- Detected patterns: `Dto`, `Middleware`, `Repository`

| Type | Role | Layer | Score | Category | Patterns |
| --- | --- | --- | ---: | --- | --- |
| `Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints.CatalogBrandListEndpoint` | Endpoint | API | 100 | High | `Repository` |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CatalogItemGetByIdEndpoint` | Endpoint | API | 100 | High | `Repository` |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CatalogItemListPagedEndpoint` | Endpoint | API | 100 | High | `Repository` |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemEndpoint` | Endpoint | API | 100 | High | `Repository` |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.DeleteCatalogItemEndpoint` | Endpoint | API | 100 | High | `Repository` |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.UpdateCatalogItemEndpoint` | Endpoint | API | 100 | High | `Repository` |
| `Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints.CatalogTypeListEndpoint` | Endpoint | API | 100 | High | `Repository` |
| `Microsoft.eShopWeb.PublicApi.Middleware.ExceptionMiddleware` | Middleware | API | 60 | Medium | `Middleware` |
| `Microsoft.eShopWeb.PublicApi.AuthEndpoints.AuthenticateEndpoint` | Endpoint | API | 58 | Medium | none |
| `Microsoft.eShopWeb.PublicApi.MappingProfile` | Mapper | API | 30 | Low | none |
| `Microsoft.eShopWeb.PublicApi.AuthEndpoints.UserInfo` | Unknown | API | 21 | Low | none |
| `Microsoft.eShopWeb.PublicApi.BaseMessage` | Unknown | API | 20 | Low | none |
| `Microsoft.eShopWeb.PublicApi.CustomSchemaFilters` | Unknown | API | 20 | Low | none |
| `Microsoft.eShopWeb.PublicApi.ImageValidators` | Unknown | API | 20 | Low | none |
| `Microsoft.eShopWeb.PublicApi.AuthEndpoints.ClaimValue` | ValueObject | API | 18 | Low | none |
| `Program` | Unknown | API | 18 | Low | none |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemResponse` | DTO | API | 9 | Low | none |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.GetByIdCatalogItemResponse` | DTO | API | 9 | Low | none |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.UpdateCatalogItemResponse` | DTO | API | 9 | Low | none |
| `Microsoft.eShopWeb.PublicApi.AuthEndpoints.AuthenticateRequest` | DTO | API | 6 | Low | none |
| `Microsoft.eShopWeb.PublicApi.AuthEndpoints.AuthenticateResponse` | DTO | API | 6 | Low | none |
| `Microsoft.eShopWeb.PublicApi.BaseRequest` | DTO | API | 6 | Low | none |
| `Microsoft.eShopWeb.PublicApi.BaseResponse` | DTO | API | 6 | Low | none |
| `Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints.ListCatalogBrandsResponse` | DTO | API | 6 | Low | none |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CreateCatalogItemRequest` | DTO | API | 6 | Low | none |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.DeleteCatalogItemRequest` | DTO | API | 6 | Low | none |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.DeleteCatalogItemResponse` | DTO | API | 6 | Low | none |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.GetByIdCatalogItemRequest` | DTO | API | 6 | Low | none |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.ListPagedCatalogItemRequest` | DTO | API | 6 | Low | none |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.ListPagedCatalogItemResponse` | DTO | API | 6 | Low | none |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.UpdateCatalogItemRequest` | DTO | API | 6 | Low | none |
| `Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints.ListCatalogTypesResponse` | DTO | API | 6 | Low | none |
| `Microsoft.eShopWeb.PublicApi.CatalogBrandEndpoints.CatalogBrandDto` | DTO | API | 0 | Low | `Dto` |
| `Microsoft.eShopWeb.PublicApi.CatalogItemEndpoints.CatalogItemDto` | DTO | API | 0 | Low | `Dto` |
| `Microsoft.eShopWeb.PublicApi.CatalogTypeEndpoints.CatalogTypeDto` | DTO | API | 0 | Low | `Dto` |

## PublicApiIntegrationTests

- Layer: `Tests`
- Purpose: Contains ASP.NET Core code.
- Frameworks: none
- Project references: `PublicApi`, `Web`
- Declared dependencies: `coverlet.collector`, `Microsoft.AspNetCore.Mvc.Testing`, `Microsoft.NET.Test.Sdk`, `MSTest.TestAdapter`, `MSTest.TestFramework`
- Technologies: `ASP.NET Core`
- Detected patterns: none

| Type | Role | Layer | Score | Category | Patterns |
| --- | --- | --- | ---: | --- | --- |
| `PublicApiIntegrationTests.CatalogItemEndpoints.CatalogItemListPagedEndpoint` | Endpoint | Tests | 59 | Medium | none |
| `PublicApiIntegrationTests.AuthEndpoints.AuthenticateEndpoint` | Endpoint | Tests | 55 | Medium | none |
| `PublicApiIntegrationTests.ProgramTest` | Unknown | Tests | 23 | Low | none |
| `PublicApiIntegrationTests.ApiTokenHelper` | Unknown | Tests | 22 | Low | none |
| `PublicApiIntegrationTests.AuthEndpoints.CreateCatalogItemEndpointTest` | Unknown | Tests | 22 | Low | none |
| `PublicApiIntegrationTests.CatalogItemEndpoints.CatalogItemGetByIdEndpointTest` | Unknown | Tests | 22 | Low | none |
| `PublicApiIntegrationTests.CatalogItemEndpoints.DeleteCatalogItemEndpointTest` | Unknown | Tests | 22 | Low | none |

## UnitTests

- Layer: `Tests`
- Purpose: Contains Specification code.
- Frameworks: none
- Project references: `ApplicationCore`, `Web`
- Declared dependencies: `Microsoft.NET.Test.Sdk`, `NSubstitute`, `NSubstitute.Analyzers.CSharp`, `xunit`, `xunit.runner.console`, `xunit.runner.visualstudio`
- Technologies: none
- Detected patterns: `Specification`

| Type | Role | Layer | Score | Category | Patterns |
| --- | --- | --- | ---: | --- | --- |
| `Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications.CustomerOrdersWithItemsSpecification` | Specification | Tests | 70 | High | `Specification` |
| `Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications.CatalogFilterPaginatedSpecification` | Specification | Tests | 65 | High | `Specification` |
| `Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications.CatalogFilterSpecification` | Specification | Tests | 65 | High | `Specification` |
| `Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications.CatalogItemsSpecification` | Specification | Tests | 65 | High | `Specification` |
| `Microsoft.eShopWeb.UnitTests.ApplicationCore.Specifications.BasketWithItems` | Specification | Tests | 46 | Medium | none |
| `Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.BasketTests.BasketAddItem` | Entity | Tests | 42 | Medium | none |
| `Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.OrderTests.OrderTotal` | Entity | Tests | 36 | Medium | none |
| `Microsoft.eShopWeb.UnitTests.ApplicationCore.Services.BasketServiceTests.TransferBasket` | Unknown | Tests | 35 | Medium | none |
| `Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.BasketTests.BasketTotalItems` | Entity | Tests | 34 | Low | none |
| `Microsoft.eShopWeb.UnitTests.ApplicationCore.Entities.BasketTests.BasketRemoveEmptyItems` | Entity | Tests | 32 | Low | none |
| `Microsoft.eShopWeb.UnitTests.Builders.OrderBuilder` | Unknown | Tests | 32 | Low | none |
| `Microsoft.eShopWeb.UnitTests.ApplicationCore.Services.BasketServiceTests.AddItemToBasket` | Unknown | Tests | 28 | Low | none |
| `Microsoft.eShopWeb.UnitTests.ApplicationCore.Services.BasketServiceTests.TransferBasket.Results<T>` | Unknown | Tests | 27 | Low | none |
| `Microsoft.eShopWeb.UnitTests.Builders.BasketBuilder` | Unknown | Tests | 27 | Low | none |
| `Microsoft.eShopWeb.UnitTests.ApplicationCore.Services.BasketServiceTests.DeleteBasket` | Unknown | Tests | 26 | Low | none |
| `Microsoft.eShopWeb.UnitTests.Builders.AddressBuilder` | Unknown | Tests | 25 | Low | none |
| `Microsoft.eShopWeb.UnitTests.MediatorHandlers.OrdersTests.GetMyOrders` | Unknown | Tests | 23 | Low | none |
| `Microsoft.eShopWeb.UnitTests.MediatorHandlers.OrdersTests.GetOrderDetails` | Unknown | Tests | 23 | Low | none |
| `Microsoft.eShopWeb.UnitTests.ApplicationCore.Extensions.JsonExtensions` | Unknown | Tests | 22 | Low | none |
| `Microsoft.eShopWeb.UnitTests.ApplicationCore.Extensions.TestChild` | Unknown | Tests | 20 | Low | none |
| `Microsoft.eShopWeb.UnitTests.ApplicationCore.Extensions.TestParent` | Unknown | Tests | 20 | Low | none |
| `Microsoft.eShopWeb.UnitTests.Web.Extensions.CacheHelpersTests.GenerateBrandsCacheKey` | Unknown | Tests | 20 | Low | none |
| `Microsoft.eShopWeb.UnitTests.Web.Extensions.CacheHelpersTests.GenerateCatalogItemCacheKey` | Unknown | Tests | 20 | Low | none |
| `Microsoft.eShopWeb.UnitTests.Web.Extensions.CacheHelpersTests.GenerateTypesCacheKey` | Unknown | Tests | 20 | Low | none |

## Web

- Layer: `UI`
- Purpose: Contains ASP.NET Core, AutoMapper, CQRS, Entity Framework Core, MediatR, Unity IoC, Controller, Handler code.
- Frameworks: none
- Project references: `ApplicationCore`, `BlazorAdmin`, `BlazorShared`, `Infrastructure`
- Declared dependencies: `Ardalis.ListStartupServices`, `Ardalis.Specification`, `AutoMapper.Extensions.Microsoft.DependencyInjection`, `Azure.Extensions.AspNetCore.Configuration.Secrets`, `Azure.Identity`, `BuildBundlerMinifier`, `MediatR`, `Microsoft.AspNetCore.Authentication.JwtBearer`, `Microsoft.AspNetCore.Components.WebAssembly.Server`, `Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore`, `Microsoft.AspNetCore.Identity.EntityFrameworkCore`, `Microsoft.AspNetCore.Identity.UI`, `Microsoft.EntityFrameworkCore.InMemory`, `Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.EntityFrameworkCore.Tools`, `Microsoft.VisualStudio.Web.CodeGeneration.Design`, `Microsoft.Web.LibraryManager.Build`, `System.IdentityModel.Tokens.Jwt`
- Technologies: `ASP.NET Core`, `AutoMapper`, `CQRS`, `Entity Framework Core`, `MediatR`, `Unity IoC`
- Detected patterns: `Controller`, `Handler`, `Service`, `ViewModel`

| Type | Role | Layer | Score | Category | Patterns |
| --- | --- | --- | ---: | --- | --- |
| `Microsoft.eShopWeb.Web.Controllers.ManageController` | Controller | API | 100 | High | `Controller` |
| `Microsoft.eShopWeb.Web.Controllers.OrderController` | Controller | API | 100 | High | `Controller` |
| `Microsoft.eShopWeb.Web.Controllers.UserController` | Controller | API | 100 | High | `Controller` |
| `Microsoft.eShopWeb.Web.Controllers.Api.BaseApiController` | Controller | API | 98 | High | `Controller` |
| `Microsoft.eShopWeb.Web.Configuration.ConfigureCoreServices` | ApplicationService | UI | 90 | High | `Service` |
| `Microsoft.eShopWeb.Web.Configuration.ConfigureWebServices` | ApplicationService | UI | 90 | High | `Service` |
| `Microsoft.eShopWeb.Web.Features.MyOrders.GetMyOrdersHandler` | CQRSHandler | Application | 73 | High | `Handler`, `ViewModel` |
| `Microsoft.eShopWeb.Web.Features.OrderDetails.GetOrderDetailsHandler` | CQRSHandler | Application | 73 | High | `Handler`, `ViewModel` |
| `Microsoft.eShopWeb.Web.Services.BasketViewModelService` | ViewModel | UI | 59 | Medium | `Service`, `ViewModel` |
| `Microsoft.eShopWeb.Web.Services.CatalogViewModelService` | ViewModel | UI | 59 | Medium | `Service`, `ViewModel` |
| `Microsoft.eShopWeb.Web.Services.CachedCatalogViewModelService` | ViewModel | UI | 50 | Medium | `Service`, `ViewModel` |
| `Microsoft.eShopWeb.Web.Interfaces.IBasketViewModelService` | ViewModel | UI | 47 | Medium | `Service`, `ViewModel` |
| `Microsoft.eShopWeb.Web.Services.ICatalogViewModelService` | ViewModel | UI | 47 | Medium | `Service`, `ViewModel` |
| `Microsoft.eShopWeb.Web.Services.CatalogItemViewModelService` | ViewModel | UI | 46 | Medium | `Service`, `ViewModel` |
| `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.LoginModel` | Unknown | UI | 43 | Medium | none |
| `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.RegisterModel` | Unknown | UI | 43 | Medium | none |
| `Microsoft.eShopWeb.Web.Interfaces.ICatalogItemViewModelService` | ViewModel | UI | 43 | Medium | `Service`, `ViewModel` |
| `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.LogoutModel` | Unknown | UI | 37 | Medium | none |
| `Microsoft.eShopWeb.Web.Pages.Basket.CheckoutModel` | Unknown | UI | 37 | Medium | none |
| `Microsoft.eShopWeb.Web.Pages.Basket.IndexModel` | Unknown | UI | 36 | Medium | none |
| `Microsoft.eShopWeb.Web.Areas.Identity.IdentityHostingStartup` | Unknown | UI | 35 | Medium | none |
| `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.ConfirmEmailModel` | Unknown | UI | 35 | Medium | none |
| `Microsoft.eShopWeb.Web.Configuration.RevokeAuthenticationEvents` | Unknown | UI | 35 | Medium | none |
| `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.LoginModel.InputModel` | Unknown | UI | 33 | Low | none |
| `Microsoft.eShopWeb.Web.Areas.Identity.Pages.Account.RegisterModel.InputModel` | Unknown | UI | 33 | Low | none |
| `Microsoft.eShopWeb.Web.Views.Manage.ManageNavPages` | Unknown | UI | 30 | Low | none |
| `Microsoft.eShopWeb.Web.Pages.Admin.EditCatalogItemModel` | Unknown | UI | 28 | Low | none |
| `Microsoft.eShopWeb.Web.Pages.IndexModel` | Unknown | UI | 26 | Low | none |
| `Microsoft.eShopWeb.Web.Extensions.CacheHelpers` | Unknown | UI | 24 | Low | none |
| `Microsoft.eShopWeb.Web.HealthChecks.ApiHealthCheck` | Unknown | API | 23 | Low | none |
| `Microsoft.eShopWeb.Web.Pages.Shared.Components.BasketComponent.Basket` | Unknown | UI | 23 | Low | none |
| `Microsoft.eShopWeb.Web.Features.MyOrders.GetMyOrders` | ViewModel | Application | 21 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.Features.OrderDetails.GetOrderDetails` | ViewModel | Application | 21 | Low | `ViewModel` |
| `Microsoft.AspNetCore.Mvc.UrlHelperExtensions` | Unknown | UI | 20 | Low | none |
| `Microsoft.eShopWeb.Web.Configuration.ConfigureCookieSettings` | Unknown | UI | 20 | Low | none |
| `Microsoft.eShopWeb.Web.HealthChecks.HomePageHealthCheck` | Unknown | UI | 20 | Low | none |
| `Microsoft.eShopWeb.Web.Pages.Basket.SuccessModel` | Unknown | UI | 20 | Low | none |
| `Microsoft.eShopWeb.Web.Pages.ErrorModel` | Unknown | UI | 20 | Low | none |
| `Microsoft.eShopWeb.Web.Pages.PrivacyModel` | Unknown | UI | 20 | Low | none |
| `Microsoft.eShopWeb.Web.Services.EmailSenderExtensions` | Unknown | UI | 20 | Low | none |
| `Microsoft.eShopWeb.Web.SlugifyParameterTransformer` | Unknown | UI | 20 | Low | none |
| `Microsoft.eShopWeb.Web.Constants` | Unknown | UI | 18 | Low | none |
| `Microsoft.eShopWeb.Web.Pages.Admin.IndexModel` | Unknown | UI | 18 | Low | none |
| `Microsoft.eShopWeb.Web.ViewModels.Manage.TwoFactorAuthenticationViewModel` | ViewModel | UI | 11 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.Pages.Basket.BasketItemViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.Pages.Basket.BasketViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.Account.LoginViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.Account.LoginWith2faViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.Account.RegisterViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.Account.ResetPasswordViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.BasketComponentViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.CatalogIndexViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.CatalogItemViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.File.FileViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.Manage.ChangePasswordViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.Manage.EnableAuthenticatorViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.Manage.ExternalLoginsViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.Manage.IndexViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.Manage.RemoveLoginViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.Manage.SetPasswordViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.Manage.ShowRecoveryCodesViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.OrderDetailViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.OrderItemViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.OrderViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |
| `Microsoft.eShopWeb.Web.ViewModels.PaginationInfoViewModel` | ViewModel | UI | 0 | Low | `ViewModel` |

