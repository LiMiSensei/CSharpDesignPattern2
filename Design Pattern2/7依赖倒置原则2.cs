namespace 依赖倒置原则2
{
    class Program
    {
        static void Main7(string[] args)
        {
            //不同的人，开不同的车
            Stuent stuet = new Stuent();
            stuet.SetCar(new Benz());
            stuet.Drive();
        }
        
        public interface ICar
        {
            void Run();
        }

        public interface IDrive
        {
            //在接口/类中注入服务对象，以参数的形式，我们称之为接口注入
            void SetCar(ICar car);
            void Drive();
        }
        
        public class Benz : ICar
        {
            public void Run()
            {
                Console.WriteLine("奔驰在奔跑");
            }
        }
        public class Stuent : IDrive
        {
            private ICar car;
            public void SetCar(ICar car)
            {
                this.car = car;
            }

            public void Drive()
            {
                car.Run();
            }
        }
    }

    
    
    
}