namespace 开放封闭原则3
{
    class Program
    {
        static void Main4(string[] args)
        {
            BonkClient bonkClient = new BonkClient();
            bonkClient.BankType = "存款";
            
            BankStuff bankStuff = new BankStuff();
            bankStuff.HandleProcess(bonkClient);
        }
        //面向抽象  面向接口
        //把我们代码常去发生变化的地方抽象出来
    }
    
    
    //===================================================================//
    public class BonkClient
    {
        public string BankType { get; set; }
    }
    //===================================================================//
    public interface IBaankProcess
    {
        void BankProcess();
    }

    public class DeppositeClass : IBaankProcess
    {
        public void BankProcess()
        {
            Console.WriteLine("处理用户的存款");
        }
    }
    public class DrawMoneyClass : IBaankProcess
    {
        public void BankProcess()
        {
            Console.WriteLine("处理用户的取款");
        }
    }
    public class TraansferClass : IBaankProcess
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
        private IBaankProcess _baankProcess;
        public void HandleProcess(BonkClient bonkClient)
        {
            switch (bonkClient.BankType)
            {
                case"存款":
                    _baankProcess = new DeppositeClass();
                    break;
                case"取钱":
                    _baankProcess = new DrawMoneyClass();
                    break;
                case"转账":
                    _baankProcess = new TraansferClass();
                    break;
                case"购买基金":
                    _baankProcess = new DeppositeClass();
                    break;
                
                
                default:break;
            }
        }
    }
    //===================================================================//
}