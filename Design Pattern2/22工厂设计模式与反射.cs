using System.Diagnostics;
using System.Reflection;

namespace 工厂设计模式与反射
{
    class Program
    {
        static void Main22(string[] args)
        {
            Console.WriteLine("请输入操作数1");
            double d1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("请输入操作数2");
            double d2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("请输入操作符");
            string oper = Console.ReadLine();

            //根据用户的操作符来创建一个创建对象的工厂对象

            //抽象：描述了一段关系 运算符 和具体工厂对象的对应关系
            //Attribute特性,就是一块狗皮膏药

            ReflectioinFactory reflectioinFactory = new();
            ICalFactory cFactory = reflectioinFactory.GetFac(oper);
            ICalculator calculator = cFactory.GetCalFactory();
            var res = calculator.GetResult(d1, d2);


            Console.WriteLine($"计算结果为{res}");
        }
    }

//======================================== 狗皮膏药 =======================================//
    //1:使用Attribute给代码贴狗皮膏药
    public class OperToFactory : Attribute
    {
        public string Oper { get; } //因为值是直接写好，不需要提供Set方法

        public OperToFactory(string oper)
        {
            Oper = oper;
        }
    }

//=============================  通过反射 string对应狗屁膏药方法 ===============================//
    public class ReflectioinFactory
    {
        Dictionary<string, ICalFactory> dic = new();

        public ReflectioinFactory()
        {
            //1,拿到正在运行的程序集
            Assembly assembly = Assembly.GetExecutingAssembly();
            //AddFactory,SubFactory,MulFactory,DivFactory 拿他们
            foreach (var type in assembly.GetTypes()) //拿到所有的类型
            {
                if (typeof(ICalFactory).IsAssignableFrom(type) && !type.IsInterface)
                {
                    //拿狗皮膏药
                    OperToFactory otf = type.GetCustomAttribute<OperToFactory>();
                    if (otf != null)
                    {
                        //给键值对集合赋值了
                        dic[otf.Oper] = Activator.CreateInstance(type) as ICalFactory;
                    }
                }
            }
        }

        public ICalFactory GetFac(string s)
        {
            if (dic.ContainsKey(s))
                return dic[s];
            return null;
        }
    }

//==================================== 工厂方法 =====================================//
    //1,把创建对象的这件事，封装成抽象
    public interface ICalFactory
    {
        ICalculator GetCalFactory();
    }

    [OperToFactory("+")]
    public class AddFactory : ICalFactory
    {
        public ICalculator GetCalFactory()
        {
            return new Add();
        }
    }

    [OperToFactory("-")]
    public class SubFactory : ICalFactory
    {
        public ICalculator GetCalFactory()
        {
            return new Sub();
        }
    }

    [OperToFactory("*")]
    public class MulFactory : ICalFactory
    {
        public ICalculator GetCalFactory()
        {
            return new Mul();
        }
    }

    [OperToFactory("/")]
    public class DivFactory : ICalFactory
    {
        public ICalculator GetCalFactory()
        {
            return new Div();
        }
    }


//==================================== 实际方法 ==========================================//
    public interface ICalculator
    {
        double GetResult(double num1, double num2);
    }

    public class Add : ICalculator
    {
        public double GetResult(double num1, double num2)
        {
            return num1 + num2;
        }
    }

    public class Sub : ICalculator
    {
        public double GetResult(double num1, double num2)
        {
            return num1 - num2;
        }
    }

    public class Mul : ICalculator
    {
        public double GetResult(double num1, double num2)
        {
            return num1 * num2;
        }
    }

    public class Div : ICalculator
    {
        public double GetResult(double num1, double num2)
        {
            return num1 / num2;
        }
    }
}