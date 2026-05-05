namespace 适配器设计模式实现
{
    class Program
    {
        static void Main30(string[] args)
        {
            IPhoneChage phoneChage = new PhoneChargeAdaoter();
            phoneChage.PhoneChage();
        }
    }

    //安卓充电线
    public class AndroidCharageAdaptee
    {
        public void AndriodChage()
        {
            Console.WriteLine("安卓充电线充电");
        }
    }

    //苹果充电线
    public interface IPhoneChage
    {
        void PhoneChage();
    }

    //转接口的作用
    public class PhoneChargeAdaoter : IPhoneChage
    {
        //在适配器中封装了Apatpe 的对象，对这个对象实现功能
        private AndroidCharageAdaptee _adaptee = new();
        
        public void PhoneChage()
        {
            _adaptee.AndriodChage();
        }
    }

    
}