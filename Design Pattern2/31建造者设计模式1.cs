namespace 建造者设计模式1
{
    class Program
    {
        static void Main30(string[] args)
        {
            Computer com = new Computer();
            com.AddPart("i5CPR");
            com.AddPart("5060GPU");
            com.AddPart("32G的内存");
            com.AddPart("17寸的显示器");
        }
    }

    public class Computer
    {
        private List<string> listPart = new();

        public void AddPart(string part)
        {
            listPart.Add(part);
        }

        public void ShowConputer()
        {
            foreach (string item in listPart)
            {
                Console.WriteLine($"正在安装{item}");
            }
        }
    }

   
    
}