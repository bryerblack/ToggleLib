// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using MrAdviceTest;

var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseSqlServer(@"Server=DESKTOP-IPRIRSK\SQLEXPRESS;Database=Test;ConnectRetryCount=0;Integrated Security=SSPI;Integrated Security=true;TrustServerCertificate=True")
           .Options;

using var contextDb = new ApplicationDbContext(contextOptions);
var ft = contextDb.featureToggleModels.ToList();
contextDb.SaveChanges();
contextDb.Dispose();
var test = new Test();
test.TestMethod();
Console.WriteLine("APPLICATION ENDED. . .");