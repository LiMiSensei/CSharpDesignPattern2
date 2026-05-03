namespace 原型模式1
{
    class Program
    {
        static void Main27(string[] args)
        {
            Resume resume = new Resume();
            resume.SetInfo("张三",28,'男');
            resume.SetWarkExperience("2013-2020","腾讯.Net高级开发工程师");
            
            Resume resume2 = new Resume();
            resume2.SetInfo("张三",28,'男');
            resume2.SetWarkExperience("2013-2020","腾讯.Net高级开发工程师");
            
            Resume resume3 = new Resume();
            resume3.SetInfo("张三",28,'男');
            resume3.SetWarkExperience("2013-2020","腾讯.Net高级开发工程师");
            

           
        }
    }

    public class Resume
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
    }
}