using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LiveChatMobile
{
    class UnityConfig
    {
        public static UnityContainer Container { get; set; }

        public static void RegisterComponents(Application app)
        {
            Container = new UnityContainer();
            SetDependencies(Container, app);
        }

        private static void SetDependencies(UnityContainer container, Application app)
        {
            //container.RegisterType<Interface, Class>();
        }
    }
}
