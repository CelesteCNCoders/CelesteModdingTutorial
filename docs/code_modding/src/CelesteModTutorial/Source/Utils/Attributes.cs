using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Mod.CelesteModTutorial.Utils;

[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class LoadAttribute : Attribute
{

}

[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public class UnLoadAttribute : Attribute
{

}

