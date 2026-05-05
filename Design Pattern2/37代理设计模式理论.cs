namespace 代理设计模式理论
{
    class Program
    {
        static void Main37(string[] args)
        {
            ClassFlower classFlower = new ClassFlower();
            classFlower.Name = "没韩寒";
            
            //创建代理对象
            ISubject subject = new Proxy(new RealSubject(classFlower));
            
            subject.GiveSmoking();
            subject.GiveBeer();
            subject.GiveJK();
        }
    }

    public interface ISubject
    {
        void GiveSmoking();
        void GiveBeer();
        void GiveJK();
    }

    public class ClassFlower()
    {
        public string Name{get;set;}
    }
    
    public class RealSubject : ISubject
    {
        private ClassFlower classFlower = new ClassFlower();

        public RealSubject(ClassFlower  classFlower)
        {
            this.classFlower = classFlower;
        }

        public void GiveSmoking()
        {
            Console.WriteLine($"{this.classFlower.Name}同学，你抽烟！！！");
        }

        public void GiveBeer()
        {
            
        }

        public void GiveJK()
        {
            
        }
    }
    
    //代理
    public class Proxy : ISubject
    {
        private RealSubject _realSubject;
        
        public Proxy(RealSubject  realSubject)
        {
            this._realSubject = realSubject;
        }

        public void GiveSmoking()
        {
            this._realSubject.GiveSmoking();
        }

        public void GiveBeer()
        {
            this._realSubject.GiveBeer();
        }

        public void GiveJK()
        {
            this._realSubject.GiveJK();
        }
    }
}