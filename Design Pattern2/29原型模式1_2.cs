namespace 原型模式1_2
{
    class Program
    {
        static void Main29(string[] args)
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
        }
    }

    public class Resume : ICloneable
    {
        public string Name;
        public int Age;
        public char Gender;
        public string TimeArea;
        public string Compaany;

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
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    
}