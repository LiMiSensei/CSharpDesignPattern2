namespace 开放封闭原则1
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
                    case "存款": bankProcess.Deposite(); break;
                    case "取钱": bankProcess.DrawMoney(); break;
                    case "转账": bankProcess.Transfer(); break;
                    case "购买基金": bankProcess.ByJiJin(); break;
                    default: Console.WriteLine("没有办法处理的业务逻辑"); break;
                }
            }
        }

        public class BankProcess
        {
            //存钱
            public void Deposite()
            {
                Console.WriteLine("处理用户的存款");
            }

            //取钱
            public void DrawMoney()
            {
                Console.WriteLine("处理用户的取款");
            }

            //转账
            public void Transfer()
            {
                Console.WriteLine("处理用户的转账");
            }

            //基金
            public void ByJiJin()
            {
                Console.WriteLine("处理用户的基金");
            }
        }
    }
}