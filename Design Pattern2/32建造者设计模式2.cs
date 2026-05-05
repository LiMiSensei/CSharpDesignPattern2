namespace 建造者设计模式2
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
            
            Computer com2 = new Computer();

            IBuilderComputer b1 = new GoodComputer();
            IBuilderComputer b2 = new LowComputer();
            Directory directory = new Directory();
            
            //让b1按照指定集体构建者构建
            directory.BuildComputer(b1);
            Computer goodcom = b1.GetComputer();
            goodcom.ShowConputer();
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

    //抽象构建接口
    public interface IBuilderComputer
    {
        //1,封装创建各个部件的过程
        
        //2,将创建好的复杂对象返回

        void BuilCpu();
        void BuilGpu();
        void BuilMemory();
        void BuilScreen();
        void BuilSystem();

        Computer GetComputer();
    }

    //具体构建者1
    public class GoodComputer : IBuilderComputer
    {
        private Computer com = new();
        public void BuilCpu()
        {
            com.AddPart("i7的CPU");
        }

        public void BuilGpu()
        {
            com.AddPart("4060的GPU");
        }

        public void BuilMemory()
        {
            com.AddPart("32G的内存");
        }

        public void BuilScreen()
        {
            com.AddPart("32寸的显示器");
        }

        public void BuilSystem()
        {
            com.AddPart("Windows10的系统");
        }

        public Computer GetComputer()
        {
            return com;
        }
    }
    //具体构建者2
    public class LowComputer : IBuilderComputer
    {
        private Computer com = new();
        public void BuilCpu()
        {
            com.AddPart("i3的CPU");
        }

        public void BuilGpu()
        {
            com.AddPart("1030的GPU");
        }

        public void BuilMemory()
        {
            com.AddPart("8G的内存");
        }

        public void BuilScreen()
        {
            com.AddPart("16寸的显示器");
        }

        public void BuilSystem()
        {
            com.AddPart("Windows7的系统");
        }

        public Computer GetComputer()
        {
            return com;
        }
    }

    public class Directory
    {
        //稳定创建各个部件
        public void BuildComputer(IBuilderComputer builder)
        {
            builder.BuilCpu();
            builder.BuilGpu();
            builder.BuilMemory();
            builder.BuilSystem();
            
        }
    }
   
    
}