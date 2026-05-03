namespace 抽象工厂设计模式导入
{
    class Program
    {
        static void Main23(string[] args)
        {
        }
    }

    /// <summary>
    /// 键盘接口
    /// </summary>
    public interface IKeyboard
    {
        void ShowKeyboard();
    }


    public class DellKeyboard : IKeyboard
    {
        public void ShowKeyboard()
        {
            Console.WriteLine("我是戴尔品牌的键盘");
        }
    }

    public class LenovoKeybiard : IKeyboard
    {
        public void ShowKeyboard()
        {
            Console.WriteLine("我是联想品牌的键盘");
        }
    }

    public class HPKeyboard : IKeyboard
    {
        public void ShowKeyboard()
        {
            Console.WriteLine("我是HP品牌的键盘");
        }
    }


    /// <summary>
    /// 简单工厂
    /// </summary>
    public class KeyboardFactory
    {
        public static IKeyboard GetKeyboard(string brand)
        {
            IKeyboard keyboard = null;
            switch (brand)
            {
                case "Dell": keyboard =  new DellKeyboard(); break;
                case "Lenovo": keyboard = new LenovoKeybiard(); break;
                case "HP": keyboard = new HPKeyboard(); break;
                
            }
            return null;
        }
    }
    
    
    /// <summary>
    /// 工厂方法
    /// </summary>
    public interface IkeyboardFactory
    {
        IKeyboard GetKeyboard();
    }

    public class DellKeyboardFactory : IkeyboardFactory
    {
        public IKeyboard GetKeyboard() => new DellKeyboard();
    }
    
    public class LenovoKeyboardFactory : IkeyboardFactory
    {
        public IKeyboard GetKeyboard() => new LenovoKeybiard();
    }
    
    public class HPKeyboardFactory : IkeyboardFactory
    {
        public IKeyboard GetKeyboard() => new HPKeyboard();

    }
    
    
}