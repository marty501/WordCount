using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class TestBase
    {
        protected static object RunInstanceMethod(Type type, string strMethod, object objInstance, object[] aobjParams)
        {
            const BindingFlags eFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            return RunMethod(type, strMethod, objInstance, aobjParams, eFlags);
        }

        private static object RunMethod(Type type, string strMethod, object objInstance, object[] aobjParams, BindingFlags eFlags)
        {
            MethodInfo m = type.GetMethod(strMethod, eFlags);
            if (m == null)
                throw new ArgumentException("There is no method '" + strMethod + "' for type '" + type + "'.");

            object objRet = m.Invoke(objInstance, aobjParams);
            return objRet;
        } 
    }
}