using System.Reflection;

namespace 反射_单例1
{
    class Program
    {
        static void Main(string[] args)
        {
           //1，通过单例创建对象
            var lay1 = LazySingHungry.Instance;
            
            //2，通过反射来破坏单例 ---->通过反射调用私有的构造函数
            Type type = Type.GetType("反射_单例1.LazySingHungry");
            //获取私有的构造函数
            type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
        }


       
        public class LazySingHungry
        {
           //1,私有化构造函数
           private LazySingHungry(){}
           
           //2,申明静态字段，存我们的唯一对象
           // 用volatile标记的成员，可以避免指令重排
           private volatile static LazySingHungry instance;
           
           //3,通过方法创建对象存储我们唯一的对象实例

           
           //4，加锁来解决线程安全问题
           private static object locker = new object();
           public static LazySingHungry Instance()
           {
               //在调用之前，要判断有没有类的实例，如果没有就创建，并放回
               //通过加锁

               //双重锁节约性能
               if (instance == null)
               {
                   lock (locker)//C# 提供的语法糖 互斥锁
                   {
                       if (instance == null)
                       {
                           instance = new LazySingHungry();
                       }
                       
                   }
               }
               return instance;
           }

        }
    }
}