
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Owin;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using SmartTraining.Business.Handlers.Course;
using SmartTraining.Data.Domain.Students;
using SmartTraining.Data.Interfaces;
using SmartTraining.Data.Repository;
using SmartTraining.Business.Handlers.Student;
using SmartTraining.Data.Domain.Courses;
using SmartTraining.Data.EntityFramework;

[assembly: OwinStartup(typeof(SmartTraining.API.Startup))]

namespace SmartTraining.API
{
    public partial class Startup
    {


        public void Configuration(IAppBuilder app)
        {
            ////app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            var diContainer = new Container();
            diContainer.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            diContainer.Register<DataContext, DataContext>(Lifestyle.Scoped);
            diContainer.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            diContainer.Register<IRepository<Student>, Repository<Student>>(Lifestyle.Scoped);
            diContainer.Register<IRepository<Course>, Repository<Course>>(Lifestyle.Scoped);
            diContainer.Register<IRepository<CourseStudent>, Repository<CourseStudent>>(Lifestyle.Scoped);

            diContainer.Register<IStudentHandler, StudentHandler>(Lifestyle.Scoped);
            diContainer.Register<ICourseHandler, CourseHandler>(Lifestyle.Scoped);

            diContainer.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            diContainer.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            diContainer.EnableHttpRequestMessageTracking(GlobalConfiguration.Configuration);
            diContainer.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(diContainer));

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(diContainer);
            HttpConfiguration config = new HttpConfiguration
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(diContainer)
            };

            app.UseWebApi(config);
            ConfigureAuth(app);
        }
    }
}
