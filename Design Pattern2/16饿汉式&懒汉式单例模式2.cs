namespace 饿汉式_懒汉式单例模式
{
    class Program
    {
        static void Main16(string[] args)
        {
           
            
        }


       
        public class LazySingHungry
        {
           //1,私有化构造函数
           private LazySingHungry(){}
           
           //2,申明静态字段，存我们的唯一对象
           private static LazySingHungry instance;
           
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