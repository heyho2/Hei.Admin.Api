using Hei.Admin.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Hei.Admin.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var aa = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            Assembly ass3 = Assembly.LoadFrom($"{typeof(BaseService<>).Assembly.GetName().Name}.dll");
        }
    }
}
