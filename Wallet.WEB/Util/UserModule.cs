using Ninject.Modules;
using BLL;

namespace WEB
{
    public class UserModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISocialNetworkService>().To<SocialNetworkService>();
        }
    }
}