using System.Diagnostics;
using System.Reflection;

class DynamicProxy<T> : DispatchProxy
{
    private T _decorated;

    public DynamicProxy() {}

    public DynamicProxy(T decorated) : base()
    {
        _decorated = decorated;
    }
    private void Log(string msg, object arg = null)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(msg, arg);
        Console.ResetColor();
    }

    protected override object Invoke(MethodInfo targetMethod, object[] args)
    {
        try
        {
            // LogBefore(targetMethod, args);
            Debug.WriteLine("teste enter method");
            var derivedMethod = _decorated.GetType().GetMethods().First(m => m.Name.Equals(targetMethod.Name));
            var attributes = Attribute.GetCustomAttributes(derivedMethod);
            var leto = attributes.First() as TestDecoratorAttribute;
            if (leto.Param == "on") 
            {
                var result = targetMethod.Invoke(_decorated, args);               
            }
            //var result = targetMethod.Invoke(_decorated, args);
            // LogAfter(targetMethod, args, result);
            return null;
        }
        catch (Exception ex) when (ex is TargetInvocationException)
        {
            // LogException(ex.InnerException ?? ex, targetMethod);
            throw ex.InnerException ?? ex;
        }
    }

    private void SetParameters(T decorated)
    {
        if (decorated == null)
        {
            throw new ArgumentNullException(nameof(decorated));
        }
        _decorated = decorated;
    }

    public static T Create(T decorated)
    {
        object proxy = Create<T, DynamicProxy<T>>();
        ((DynamicProxy<T>)proxy).SetParameters(decorated);

        return (T)proxy;
    }
}