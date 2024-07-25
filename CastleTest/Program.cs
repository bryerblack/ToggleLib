using Castle.DynamicProxy;
using CastleTest;

//Test test = new Test();
var i = new FeatureToggleInterceptor();
var proxyFactory = new ProxyGenerator();
var proxy = proxyFactory.CreateClassProxy<Test>(i);
proxy.TestMethod();
Console.WriteLine("APPLICATION ENDED. . .");