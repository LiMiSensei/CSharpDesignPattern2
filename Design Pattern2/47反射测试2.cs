using System.Diagnostics;
using System.Reflection;
using 工厂设计模式与反射;



//TODO:根据标签创建类
namespace 反射测试2
{
    class Program
    {
        static void Main47(string[] args)
        {
            IBase fun = Factory.Create("Twoe");
            fun.Do();
        }
    }


    public interface IBase
    {
        void Do();
    }

    [Lab("One")]
    public class Frist : IBase
    {
        public void Do()
        {
            Console.WriteLine(this.GetType().Name);
        }
    }
    
    [Lab("Twoe")]
    public class Second : IBase
    {
        public void Do()
        {
            Console.WriteLine(this.GetType().Name);
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
    
    public static class Factory
    {
        public static IBase Create(string name)
        {
            // 获取当前程序集
            Assembly assembly = Assembly.GetExecutingAssembly();

            // 查找符合条件的类型
            Type type = assembly
                .GetTypes()
                .FirstOrDefault(t =>
                {
                    // 必须实现 IBase
                    if (!typeof(IBase).IsAssignableFrom(t)) return false;
                    // 获取特性
                    Lab attr = t.GetCustomAttribute<Lab>();
                    // 判断标签
                    return attr != null && attr.Name == name;
                });

            if (type == null)
                throw new Exception($"未找到类型: {name}");

            // 创建实例
            return (IBase)Activator.CreateInstance(type);
        }
    }
}