namespace 开放封闭原则2
{
    class Program
    {
        static void Main2(string[] args)
        {
            //使用代码，描述不同需求的用户去银行办理不同的业务：

            //1、在这殿程序中5会出现多少个对象？
            //2、每个对象的属性和行为


            //对象1：用户：属性：记录不同类型的用户（存钱，取钱，转账......）
            //对象2：银行柜员：帮助我们用户处理不同需求
            //对象3：银行业务系统：处理存钱，取钱，转账等需求
            
            //在类中，将每一个方法都进行按口抽象接口的封装（根据业务，进行高度抽象封装按

            BonkClient bonkClient = new BonkClient();
            bonkClient.BankType = "存款";

            BonkStuff bonkStuff = new BonkStuff();
            bonkStuff.HandleProcess(bonkClient);
        }


        public class BonkClient
        {
            public string BankType { get; set; }
        }

        public class BonkStuff
        {
            private BankProcess bankProcess = new();

            public void HandleProcess(BonkClient bonkClient)
            {
                //调用银行的业务系统，处理我们的用户需求

                //依托答辩 低端和冗余
                switch (bonkClient.BankType)
                {
                    case "存款": bankProcess.Deposite.Deposite(); break;
                    case "取钱": bankProcess.DrawMoney.DrawMoney(); break;
                    case "转账": bankProcess.Transfer.Transfer(); break;
                    case "购买基金": bankProcess.ByJiJin.ByJiJin(); break;
                    default: Console.WriteLine("没有办法处理的业务逻辑"); break;
                }
            }
        }


        //1抽取接口
        public interface IDeposite
        {
            public void Deposite();
        }

        public interface IDrawMoney
        {
            public void DrawMoney();
        }

        public interface ITransfer
        {
            public void Transfer();
        }

        public interface IByJiJin
        {
            public void ByJiJin();
        }
        //实现接口

        public class DepositeClass : IDeposite
        {
            public void Deposite()
            {
                Console.WriteLine("处理用户的存款");
            }
        }

        public class DrawMoneyClass : IDrawMoney
        {
            public void DrawMoney()
            {
                Console.WriteLine("处理用户的取款");
            }
        }

        public class TransferClass : ITransfer
        {
            public void Transfer()
            {
                Console.WriteLine("处理用户的转账");
            }
        }

        public class ByJiJinClass : IByJiJin
        {
            public void ByJiJin()
            {
                Console.WriteLine("处理用户的基金");
            }
        }

        //2 在BankProcess进行调用

        public class BankProcess
        {
            //1, 字段 + GetSet
            //2, 属性

            public IDeposite Deposite = new DepositeClass();
            public IDrawMoney DrawMoney = new DrawMoneyClass();
            public ITransfer Transfer = new TransferClass();
            public IByJiJin ByJiJin = new ByJiJinClass();
        }
    }
}