using System.Collections.Generic;
using System.Reflection;
using System.Web.Http.Dispatcher;

namespace GreenField.API.App_Start
{
    public class CustomAssemblyResolver : IAssembliesResolver
    {
        private readonly string _path;
        public CustomAssemblyResolver(string path)
        {
            _path = path;
        }

        ICollection<Assembly> IAssembliesResolver.GetAssemblies()
        {
            var assemblies = new List<Assembly> {Assembly.LoadFrom(_path)};
            return assemblies;
        }
    } 
}