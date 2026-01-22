using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Celeste.Mod.CelesteModTutorial.Utils;

public static class AttributeHelper
{
    private static Dictionary<Type, List<MethodInfo>> cachedMethods = new Dictionary<Type, List<MethodInfo>>();
    private static Assembly cachedAssembly = null;

    public static void InvokeAllMethods<TAttribute>() where TAttribute : Attribute
    {
        var methods = GetAllMethods<TAttribute>();

        foreach (var method in methods)
            method.Invoke(null, null);
    }

    public static List<MethodInfo> GetAllMethods<TAttribute>() where TAttribute : Attribute
    {
        var attributeType = typeof(TAttribute);

        if (!cachedMethods.TryGetValue(attributeType, out List<MethodInfo> cacheEntries))
        {
            cacheEntries = new List<MethodInfo>();
            Assembly assembly = cachedAssembly ?? Assembly.GetCallingAssembly();

            foreach (var type in assembly.GetTypesSafe())
            {
                foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                {
                    if (method.IsDefined(attributeType, false))
                        cacheEntries.Add(method);
                }
            }

            cachedMethods[attributeType] = cacheEntries;
        }

        return cacheEntries;
    }
}

