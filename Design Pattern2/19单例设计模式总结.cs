using System.Reflection;

namespace 单例设计模式总结
{
    class Program
    {
        static void Main19(string[] args)
        {
          
           
        }

        public class HungryClass
        {
            public static HungryClass GetHungryClass()
            {
                //只要在外部调用GetSIngleHungryO这个方法的时候，才会加载内部类的成员
                return InnerClass.HungryClass;
            }
            //在类的内部写一个
            public static class InnerClass
            {
                //他不会跟着我们外部的HungryClass一起加载到内存中
                public static readonly HungryClass HungryClass = new HungryClass();
            }
        }
       
      
    }
}