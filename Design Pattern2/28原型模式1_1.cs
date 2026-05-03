namespace 原型模式1_1
{
    class Program
    {
        static void Main28(string[] args)
        {
            Resume resume = new Resume("张三");

            Resume resume2 = (Resume)resume.Clone();

        }
    }

    public abstract class ResumePrototype
    {
        public string Name;

        public ResumePrototype(string name)
        {
            Name = name;
        }
        
        public abstract ResumePrototype Clone();
    }

    public class Resume : ResumePrototype
    {
        public Resume(string name) : base(name)
        {
            
        }

        public override ResumePrototype Clone()
        {
            //MemberwiseClone 浅克隆
            //值类型：成员全部赋值一边，
            //引用类型：只是赋值引用，不赋值其对象
            return this.MemberwiseClone() as ResumePrototype;
        }
    }
    
}