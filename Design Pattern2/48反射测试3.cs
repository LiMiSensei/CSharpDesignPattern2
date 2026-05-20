using System.Diagnostics;
using System.Reflection;
using 工厂设计模式与反射;


//TODO:
namespace 反射测试3
{
    class Program
    {
        static void Main3(string[] args)
        {
            Execute("One", true);
        }
        
        static void Execute(string labName, object value)
        {
            // 获取程序集
            Assembly assembly = Assembly.GetExecutingAssembly();

            // 找类型
            Type? type = assembly.GetTypes()
                .FirstOrDefault(t =>
                {
                    var attr = t.GetCustomAttribute<Lab>();

                    return attr != null &&
                           attr.Name == labName;
                });

            if (type == null)
                throw new Exception("没找到类型");

            // 创建实例
            object? instance = Activator.CreateInstance(type);

            if (instance == null)
                throw new Exception("实例创建失败");

            // 找 Do 方法
            MethodInfo? method = type.GetMethod("Do");

            if (method == null)
                throw new Exception("没找到 Do 方法");

            // 获取第一个参数类型
            ParameterInfo parameter = method.GetParameters()[0];

            Type parameterType = parameter.ParameterType;

            // value 的真实类型
            Type valueType = value.GetType();

            // 严格类型判断
            if (parameterType != valueType)
            {
                Console.WriteLine("不是同类型");
                return;
            }

            // 执行
            method.Invoke(instance, new object[] { value });
        }
    }

    


    public interface IBase1
    {
    }

    public interface Base1<T> : IBase1
    {
        Action<T> OnAction { get; set; }
        public T Value { get; set; }
        public void Do(T value);
    }

    [Lab("One")]
    public class Frist : Base1<float>
    {
        public Action<float> OnAction { get; set; }
        public float Value { get; set; }

        public void Do(float value)
        {
            Console.WriteLine("1");
        }
    }

    [Lab("Twoe")]
    public class Second : Base1<int>
    {
        public Action<int> OnAction { get; set; }
        public int Value { get; set; }

        public void Do(int value)
        {
            Console.WriteLine("1");
        }
    }


    public class Lab : Attribute
    {
        public string Name;

        public Lab(string name)
        {
            this.Name = name;
        }
    }
}