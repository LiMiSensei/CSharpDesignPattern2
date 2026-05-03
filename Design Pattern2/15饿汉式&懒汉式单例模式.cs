namespace 饿汉式_懒汉式单例模式2
{
    class Program
    {
        static void Main15(string[] args)
        {
            //单例设计模式：要求在一个程序中有且只有一个实例
            //new的三部曲
            //1，在内存中开辟空间
            //2，执行对象的构成函数，创建对象
            //3，把我的内存空间，指向我创建的对象

            SingHungry singHungry1 = SingHungry.GetInstance();
            SingHungry singHungry2 = SingHungry.GetInstance();
            SingHungry singHungry3 = SingHungry.GetInstance();
        }


        //这种我们称为饿汉式，不推荐使用
        //因为会造成资源的浪费
        public class SingHungry
        {
            //1，构造函数私有化
            private SingHungry()
            {
            }

            //2，创建一个唯一的对象
            //private,迪米特，没有必要暴露给外界的成员
            //static:静态成员，保证内存的唯一性
            //readonly:不允许修改
            private static readonly SingHungry singHungry = new SingHungry();


            //3，创建一个方法，实现对提供外界的唯一对象的能力
            public static SingHungry GetInstance()
            {
                return singHungry;
            }
        }
    }
}