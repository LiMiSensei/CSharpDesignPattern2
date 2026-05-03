namespace 迪米特原则
{
    class Program
    {
        static void Main10(string[] args)
        {
        }
    }

    public class Computer
    {
        //1,保存当前程序
        public void SaveCurrentTask()
        {
            Console.WriteLine("保存当前程序");
        }

        //2，关闭屏幕
        public void CloseScreen()
        {
            Console.WriteLine("关闭屏幕");
        }

        //3，关闭电源
        public void ShutDown()
        {
            Console.WriteLine("关闭电源");
        }

        //提供关机方法
        public void CloseComputer()
        {
            this.SaveCurrentTask();
            this.CloseScreen();
            this.ShutDown();
        }
    }

    public class Person()
    {
        public void CloseComputer(Computer computer)
        {
            //不符合迪米特原则
            computer.CloseComputer();
        }
    }
}