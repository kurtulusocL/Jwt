using AuthProjectJWT.Business.Abstract;
using AuthProjectJWT.Business.Conctere;
using AuthProjectJWT.Core.Utilities.Interceptors;
using AuthProjectJWT.Core.Utilities.Security.Jwt;
using AuthProjectJWT.DataAccess.Abstract;
using AuthProjectJWT.DataAccess.Concrete.EntityFramework;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthProjectJWT.Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<ProductDAL>().As<IProductDAL>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<CategoryDAL>().As<ICategoryDAL>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserDAL>().As<IUserDAL>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
