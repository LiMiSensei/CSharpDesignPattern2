namespace 原型模式2
{
    class Program
    {
        static void Main(string[] args)
        {
            Resume resume = new Resume();
            resume.SetInfo("孙权",28,'男');
            resume.SetWarkExperience("","");
            
            Resume resume2 = resume.Clone() as Resume;
            Resume resume3 = resume.Clone() as Resume;
            Resume resume4 = resume.Clone() as Resume;
            
            resume2.ShowResume();
            resume3.ShowResume();
            resume4.ShowResume();
            
            //最好的就是反射和序列化
        }
    }

    public class Resume : ICloneable
    {
        public string Name;
        public int Age;
        public char Gender;
        public string TimeArea;
        public string Compaany;
        //引用类型
        public WorkExperience warkExperience;

        private Resume(WorkExperience warkExperience)
        {
            //专为克隆做的构造
            this.warkExperience = warkExperience.Clone() as WorkExperience;
        }

        public Resume()
        {
            warkExperience =  new WorkExperience();
        }

        public void SetInfo(string name, int age, char gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public void SetWarkExperience(string timeArea, string compaany)
        {
            TimeArea = timeArea;
            Compaany = compaany;
        }

        public void ShowResume()
        {
            Console.WriteLine($"{Name},{Age},{Gender}");
            Console.WriteLine($"{TimeArea},{Compaany}");
            Console.WriteLine($"{warkExperience.Compaany},{warkExperience.TimeArea}");
        }

        public object Clone()
        {
            Resume resume = new Resume(warkExperience);
            resume.Name = this.Name;
            resume.Age = this.Age;
            resume.Gender = this.Gender;
            resume.TimeArea = this.TimeArea;
            resume.Compaany = this.Compaany;
            return resume;
            //return this.MemberwiseClone();
        }
    }

    public class WorkExperience : ICloneable
    {
        public string TimeArea;
        public string Compaany;
        public object Clone()
        {
            WorkExperience workExperience =  new WorkExperience();
            workExperience.TimeArea = TimeArea;
            workExperience.Compaany = Compaany;
            return workExperience;
        }
    }
    
}