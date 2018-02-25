using Autofac;
using MetroFramework.Forms;
using System.Linq;
using System.Reflection;

namespace Homologador.Config
{
    public static class AutoFacConfig
    {
        public static IContainer BootStrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<StudentRepository>()
                .As<IModelRepository<WindowsApp.Models.Student>>()
                .InstancePerDependency();

            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .Where(type => type.IsSubclassOf(typeof(MetroForm)));

            return builder.Build();
        }
    }
}
