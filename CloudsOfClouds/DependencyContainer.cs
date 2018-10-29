using System.Drawing;
using Autofac;
using CloudsOfClouds.Domain.Gateways;
using CloudsOfClouds.Domain.Mapper;
using CloudsOfClouds.Domain.Services;
using CloudsOfClouds.Domain.Store;
using CloudsOfClouds.Gateways_;
using CloudsOfClouds.Interface;
using CloudsOfClouds.Services;
using CloudsOfClouds.Store;
using Colorful;

namespace CloudsOfClouds
{
    public class DependencyContainer
    {
        private static IContainer container;

        public static ICloudOfCloudsClient ResolveLibaray()
        {
            RegistrationRoot();
            using (var scope = container.BeginLifetimeScope())
            {
                var DA = 244;
                var V = 212;
                var ID = 255;
                Console.WriteAscii("Cloud of Clouds", Color.FromArgb(DA, V, ID));
               return container.Resolve<ICloudOfCloudsClient>();
            }
        }

        private static void RegistrationRoot()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Mapper.Mapper>().As<IMapper>().SingleInstance();
            builder.RegisterType<CloudOfCloudsClient>().As<ICloudOfCloudsClient>().SingleInstance();
            builder.RegisterType<FileSplitter>().As<IFileSplitter>().SingleInstance();

            var store = new BlobStore();
            var cocService = new CoCService(new ICloudService[] {new GoogleCloudService(store), new DropboxCloudService(store)});

            builder.RegisterInstance(store).As<IBlobStore>();
            builder.RegisterInstance(cocService).As<ICoCService>();
            
            container = builder.Build();
        }
    }
}