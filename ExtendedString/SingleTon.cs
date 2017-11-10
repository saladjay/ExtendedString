using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Threading;
namespace ExtendedString
{
    public static class SingleTon<T>where T:class,new()
    {
        private static T _instance = default(T);

        public static T GetInstance()
        {
            if ((object)SingleTon<T>._instance == null)
                Interlocked.CompareExchange<T>(ref SingleTon<T>._instance, Activator.CreateInstance<T>(), default(T));
            return SingleTon<T>._instance;
        }
    }
}
