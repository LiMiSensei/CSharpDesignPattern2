using System.Diagnostics;
using System.Reflection;
using 工厂设计模式与反射;

namespace 反射测试1
{
    class Program
    {
        static void Main46(string[] args)
        {
            var m = new MethodFactory();
            
            m.存储(typeof(TestClass));
        }
    }


    public class MethodFactory
    {
        /// <summary>
        /// 参数类型
        ///     -> 名字
        ///         -> MethodInfo
        /// </summary>
        public Dictionary<Type, Dictionary<string, MethodInfo>> Dict = new();

        public void 存储(Type t)
        {
            Type type = t;

            // 获取所有方法
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (MethodInfo method in methods)
            {
                // 获取 Attribute
                OperToFactoryAttribute? attr = method.GetCustomAttribute<OperToFactoryAttribute>();
                if (attr == null) continue;
                // 方法名
                string methodName = method.Name;
                // 参数列表
                ParameterInfo[] parameters = method.GetParameters();
                Type firstParamType = null;
                if (parameters.Length > 0)
                {
                    firstParamType = parameters[0].ParameterType;
                }

                Console.WriteLine($"1:Attribute名字: {attr.Name}");
                Console.WriteLine($"2:函数名: {methodName}");
                Console.WriteLine($"3:第一个参数类型: {firstParamType}");
            }
        }
        public void Register(object target)
        {
            Type type = target.GetType();

            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo method in methods)
            {
                var attr = method.GetCustomAttribute<OperToFactoryAttribute>();
                if (attr == null) continue;
                ParameterInfo[] parameters = method.GetParameters();
                // 这里只处理一个参数的方法
                if (parameters.Length != 1) continue;
                Type paramType = parameters[0].ParameterType;
                // 没有这一类型则创建
                if (!Dict.ContainsKey(paramType))
                {
                    Dict[paramType] = new Dictionary<string, MethodInfo>();
                }
                Dict[paramType].Add(attr.Name, method);
                Console.WriteLine($"注册成功: 参数类型={paramType.Name} 名字={attr.Name} 方法={method.Name}");
            }
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class OperToFactoryAttribute : Attribute
    {
        public string Name { get; }

        public OperToFactoryAttribute(string label)
        {
            Name = label;
        }
    }


    
    public class TestClass
    {
        [OperToFactoryAttribute("无输入输出")]
        void TestFunction()
        {
            Console.WriteLine("无输入输出");
        }

        [OperToFactoryAttribute("int输入输出")]
        void TestFunction2(int d1)
        {
            Console.WriteLine("int输入输出");
        }
    }
}