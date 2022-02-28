
#nullable disable
using System.Reflection;


//Assembly Klasse repräsentiert eine geladene DLL 
Assembly geladeneDll = Assembly.LoadFrom("Taschenrechner.dll");

Type taschenrechnerClassAsType = geladeneDll.GetType("Taschenrechner.MyCalc");
object tr = Activator.CreateInstance(taschenrechnerClassAsType);


MethodInfo methodInfo = taschenrechnerClassAsType.GetMethod("Add", new Type[] { typeof(Int32), typeof(Int32) });

object result = methodInfo.Invoke(tr, new object[] { 11,22}); //33

Console.WriteLine(result);