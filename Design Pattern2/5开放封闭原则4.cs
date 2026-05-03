namespace 开放封闭原则4
{
    class Program
    {
        static void Main5(string[] args)
        {
            //创建存款对象
            IBonkClient bonkClient = new DeppositeClient();
            //创建我们的业务员目标
            BankStuff bankStuff = new BankStuff();
            bankStuff.HandleProcess(bonkClient);
            
        }
        //面向抽象  面向接口
        //把我们代码常去发生变化的地方抽象出来
    }
    
    //===================================================================//
    public interface IBonkProcess
    {
        void BankProcess();
    }

    public class DeppositeClass :IBonkProcess
    {
        public void BankProcess()
        {
            Console.WriteLine("处理用户的存款");
        }
    }
    public class DrawMoneyClass : IBonkProcess
    {
        public void BankProcess()
        {
            Console.WriteLine("处理用户的取款");
        }
    }
    public class TraansferClass : IBonkProcess
    {
        public void BankProcess()
        {
            Console.WriteLine("处理用户的转账");
        }
    }
    //===================================================================//
    public class BankStuff
    {
        //拿到接口引用
        private IBonkProcess _bonkProcess;
        public void HandleProcess(IBonkClient bonkClient)
        {
            //用户端调用自己的的 GetBaankProcess 
            _bonkProcess = bonkClient.GetBaankProcess();
            //业务处理对象 调用BankProcess执行业务操作方法 
            _bonkProcess.BankProcess();
        }
    }
    //=============================== IBonkClient ====================================//
    
    public interface IBonkClient
    {
        //封装的是变化
        //变化的是什么
        //根据不同需求的用户|返网不同的处理对象|处理方法
        
        public IBonkProcess GetBaankProcess();
    }
    
    public class DeppositeClient : IBonkClient
    {
        public IBonkProcess GetBaankProcess()
        {
            return new DeppositeClass();
        }
    }
    
    public class DrawMoneyClient : IBonkClient
    {
        public IBonkProcess GetBaankProcess()
        {
            return new DrawMoneyClass();
        }
    }
    
    public class TraansferClient : IBonkClient
    {
        public IBonkProcess GetBaankProcess()
        {
            return new TraansferClass();
        }
    }
}