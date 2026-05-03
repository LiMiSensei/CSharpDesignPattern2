namespace 抽象工厂设计模式实现
{
    class Program
    {
        static void Main24(string[] args)
        {
            IAbstractFactory abstractFactory = new DellFactory();
            IKeyboard dellFactory = abstractFactory.GetKeyboard();
            IMouse mouse = abstractFactory.GetMouse();

            dellFactory.ShowKeyboard();
            mouse.ShowMouse();
        }
    }


    public interface IKeyboard
    {
        void ShowKeyboard();
    }

    public class HPKeyboard : IKeyboard
    {
        public void ShowKeyboard()
        {
            Console.WriteLine("HPKeyboard");
        }
    }

    public class LenovoKeyboard : IKeyboard
    {
        public void ShowKeyboard()
        {
            Console.WriteLine("LenovoKeyboard");
        }
    }

    public class DellKeyboard : IKeyboard
    {
        public void ShowKeyboard()
        {
            Console.WriteLine("DellKeyboard");
        }
    }


    public interface IMouse
    {
        void ShowMouse();
    }

    public class HPMouse : IMouse
    {
        public void ShowMouse()
        {
            Console.WriteLine("HPMouse");
        }
    }

    public class LenovoMouse : IMouse
    {
        public void ShowMouse()
        {
            Console.WriteLine("LenovoMouse");
        }
    }

    public class DellMouse : IMouse
    {
        public void ShowMouse()
        {
            Console.WriteLine("DellMouse");
        }
    }


    public interface IAbstractFactory
    {
        IKeyboard GetKeyboard();
        IMouse GetMouse();
    }

    public class DellFactory : IAbstractFactory
    {
        public IKeyboard GetKeyboard()
        {
            return new DellKeyboard();
        }

        public IMouse GetMouse()
        {
            return new DellMouse();
        }
    }

    public class HPFactory : IAbstractFactory
    {
        public IKeyboard GetKeyboard()
        {
            return new HPKeyboard();
        }

        public IMouse GetMouse()
        {
            return new HPMouse();
        }
    }

    public class LenovoFactory : IAbstractFactory
    {
        public IKeyboard GetKeyboard()
        {
            return new LenovoKeyboard();
        }

        public IMouse GetMouse()
        {
            return new LenovoMouse();
        }
    }
}