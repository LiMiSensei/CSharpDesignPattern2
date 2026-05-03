namespace 编程思想
{
/*

【面向对象】【设计原则】【设计模式】【设计应用】


淘宝
商家卖货
    订单系统                业务逻辑
    物流系统                流程环节
    文件系统                人机交互
买家买货
    直播系统
    红包雨系统
    秒杀系统




 */

    public class Program
    {
        public static void Main1()
        {
        }

        //public class TelPhone
        //{
        //    public void Dial(string number)
        //    {
        //        Console.WriteLine("给" + number + "打电话");
        //    }
        //
        //    public void HangUp(string number)
        //    {
        //        Console.WriteLine("挂断" + number + "电话");
        //    }
        //
        //    public void SendMessage(string number)
        //    {
        //        Console.WriteLine("发生" + number);
        //    }
        //
        //    public void ReciveMessage(string number)
        //    {
        //        Console.WriteLine("接收" + number);
        //    }
        //}


        //(添加功能)，引起TelPhone的变化

        // 思路：给每个方法，都提炼啊成一个接口，抽象成一种能力，分别写类，去实现接口


//=======================================================================//
        public interface IDial
        {
            void DiolNumber(string number);
        }

        public interface IHangUp
        {
            void HangUp(string number);
        }

        public interface ISendMessage
        {
            void SendMessage(string number);
        }

        public interface IReciveMessage
        {
            void ReciveMessage(string number);
        }

//=======================================================================//
        public class Dial1 : IDial
        {
            public void DiolNumber(string number)
            {
                Console.WriteLine("给" + number + "打电话");
            }
        }

        public class HangUp1 : IHangUp
        {
            public void HangUp(string number)
            {
                Console.WriteLine("挂断" + number + "电话");
            }
        }

        public class SendMessage1 : ISendMessage
        {
            public void SendMessage(string number)
            {
                Console.WriteLine("发生" + number);
            }
        }

        public class ReciveMessage1 : IReciveMessage
        {
            public void ReciveMessage(string number)
            {
                Console.WriteLine("接收" + number);
            }
        }

//=======================================================================//


        public interface IPowerOn
        {
            void PowerOn();
        }

        public interface IPowerDown
        {
            void PowerDown();
        }


        public class PowerOnClass : IPowerOn
        {
            public void PowerOn()
            {
                Console.WriteLine("开机");
            }
        }

        public class PowerDownClass : IPowerDown
        {
            public void PowerDown()
            {
                Console.WriteLine("关机");
            }
        }

        //=======================================================================//
        public class TelPhone
        {
            private IHangUp hangUp;
            private IDial dial;
            private ISendMessage sendMessage;
            private IReciveMessage reciveMessage;
            private IPowerOn powerOn;
            private IPowerDown powerDown;


            public void HangUpPhoneNumber(string number)
            {
                hangUp.HangUp(number);
            }

            public void DialPhoneNumber(string number)
            {
                dial.DiolNumber(number);
            }

            public void SendMessageNumber(string number)
            {
                sendMessage.SendMessage(number);
            }

            public void ReciveMessageNumber(string number)
            {
                reciveMessage.ReciveMessage(number);
            }

            public void PowerDownNumber()
            {
                powerDown.PowerDown();
            }

            public void PowerOnNumber()
            {
                powerOn.PowerOn();
            }
        }
    }
}