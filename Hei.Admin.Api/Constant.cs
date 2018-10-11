using System;

namespace Hei.Admin.Api
{
    internal static class Constant
    {

    }
}


//{"Message":
//@"System.ArgumentNullException: Value cannot be null.\nParameter name: connectionString\n   
//at Microsoft.EntityFrameworkCore.Utilities.Check.NotEmpty(String value, String parameterName)\n   
//at Microsoft.EntityFrameworkCore.MySqlDbContextOptionsExtensions.UseMySql(DbContextOptionsBuilder optionsBuilder, String connectionString, Action`1 mySqlOptionsAction)\n   
//at Hei.Admin.Api.Configures.DependencyInjectionConfigurer.<>c__DisplayClass2_0.<Configure>b__0(DbContextOptionsBuilder options)\n   
//at Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.<>c__DisplayClass1_0`2.<AddDbContext>b__0(IServiceProvider p, DbContextOptionsBuilder b)\n   
//at Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.DbContextOptionsFactory[TContext](IServiceProvider applicationServiceProvider, Action`2 optionsAction)\n   
//at Microsoft.Extensions.DependencyInjection.EntityFrameworkServiceCollectionExtensions.<>c__DisplayClass10_0`1.<AddCoreServices>b__0(IServiceProvider p)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitFactory(FactoryCallSite factoryCallSite, ServiceProviderEngineScope scope)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(IServiceCallSite callSite, TArgument argument)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitScoped(ScopedCallSite scopedCallSite, ServiceProviderEngineScope scope)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(IServiceCallSite callSite, TArgument argument)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite constructorCallSite, ServiceProviderEngineScope scope)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(IServiceCallSite callSite, TArgument argument)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitTransient(TransientCallSite transientCallSite, ServiceProviderEngineScope scope)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(IServiceCallSite callSite, TArgument argument)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite constructorCallSite, ServiceProviderEngineScope scope)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(IServiceCallSite callSite, TArgument argument)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitTransient(TransientCallSite transientCallSite, ServiceProviderEngineScope scope)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(IServiceCallSite callSite, TArgument argument)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite constructorCallSite, ServiceProviderEngineScope scope)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(IServiceCallSite callSite, TArgument argument)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitTransient(TransientCallSite transientCallSite, ServiceProviderEngineScope scope)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(IServiceCallSite callSite, TArgument argument)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.DynamicServiceProviderEngine.<>c__DisplayClass1_0.<RealizeService>b__0(ServiceProviderEngineScope scope)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngine.GetService(Type serviceType, ServiceProviderEngineScope serviceProviderEngineScope)\n   
//at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngineScope.GetService(Type serviceType)\n   
//at Microsoft.Extensions.DependencyInjection.ActivatorUtilities.GetService(IServiceProvider sp, Type type, Type requiredBy, Boolean isDefaultParameterRequired)\n   
//at lambda_method(Closure , IServiceProvider , Object[] )\n   
//at Microsoft.AspNetCore.Mvc.Controllers.ControllerActivatorProvider.<>c__DisplayClass4_0.<CreateActivator>b__0(ControllerContext controllerContext)\n   
//at Microsoft.AspNetCore.Mvc.Controllers.ControllerFactoryProvider.<>c__DisplayClass5_0.<CreateControllerFactory>g__CreateController|0(ControllerContext controllerContext)\n   
//at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)\n   
//at Microsoft.AspNetCore.Mvc.Internal.ControllerActionInvoker.InvokeInnerFilterAsync()\n   
//at Microsoft.AspNetCore.Mvc.Internal.ResourceInvoker.InvokeNextExceptionFilterAsync()","Data":null,"Code":1,"IsSucceed":false,"HttpStatusCode":500}