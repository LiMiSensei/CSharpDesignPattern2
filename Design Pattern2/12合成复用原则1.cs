namespace 合成复用原则1
{
    class Program
    {
        static void Main12(string[] args)
        {
            Car car = new QYCar();
            car.Run(new Green());
        }
        public interface IColor
        {
            string ShowColor();
        }

        public class Green : IColor
        {
            public string ShowColor()
            {
                return "Green";
            }
        }
        
        public class Red : IColor
        {
            public string ShowColor()
            {
                return "Red";
            }
        }
        
        
        public abstract  class Car
        {
          public abstract void Run(IColor color);
        }

        public class QYCar : Car
        {
            public override void Run(IColor color)
            {
                Console.WriteLine($"汽油 {color.ShowColor()}颜色的车");
            }
        }
        
        public class DYCar : Car
        {
            public override void Run(IColor color)
            {
                Console.WriteLine($"电动 {color.ShowColor()}颜色的车");
            }
        }
      
    }
}