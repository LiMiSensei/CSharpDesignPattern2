namespace 桥接设计模式应用
{
    class Program
    {
        static void Main41(string[] args)
        {
            Car car = new QYCar();
            car.Move(new Red());
            
            Car car2 = new DDCar();
            car.Move(new White());
        }
    }

    public interface IColor
    {
        void ShowColor();
    }

    public class Red : IColor
    {
        public void ShowColor()
        {
            throw new NotImplementedException();
        }
    }

    public class White : IColor
    {
        public void ShowColor()
        {
            throw new NotImplementedException();
        }
    }

    
    public abstract class Car
    {
        public abstract void Move(IColor color);
    }

    public class QYCar : Car
    {
        public override void Move(IColor color)
        {
            Console.WriteLine("QYCar");
        }
    }
    
    public class DDCar : Car
    {
        public override void Move(IColor color)
        {
            Console.WriteLine("DDCar");
        }
    }
}