namespace 装饰器设计模式实现
{
    class Program
    {
        static void Main36(string[] args)
        {
            //创建奶茶对象
            MiKiTea miKiTea = new MiKiTea();

            //创建配料对象
            Buding buding1 = new Buding();
            Buding buding2 = new Buding();
            ZhenZhu zhenZhu = new ZhenZhu();

            // 正确的装饰器链：珍珠(布丁2(布丁1(奶茶)))
            buding1.SetComponent(miKiTea); // 布丁1装饰奶茶
            buding2.SetComponent(buding1); // 布丁2装饰布丁1
            zhenZhu.SetComponent(buding2); // 珍珠装饰布丁2

            Console.WriteLine($"总价：{zhenZhu.Cost()}元");
        }
    }


    //父类--主食
    public abstract class YinLian
    {
        public abstract double Cost();
    }

    public class MiKiTea : YinLian
    {
        public override double Cost()
        {
            Console.WriteLine("奶茶10块一杯");
            return 10;
        }
    }

    public class FruitTea : YinLian
    {
        public override double Cost()
        {
            Console.WriteLine("水果茶20块一杯");
            return 20;
        }
    }

    public class SoDaTea : YinLian
    {
        public override double Cost()
        {
            Console.WriteLine("苏打饮料30元一杯");
            return 30;
        }
    }

    //适配器 递归
    public abstract class Decorator : YinLian
    {
        //添加父类的引用
        private YinLian yinLian;

        public void SetComponent(YinLian y)
        {
            this.yinLian = y;
        }

        public override double Cost()
        {
            return yinLian.Cost();
        }
    }


    //配料1布丁
    public class Buding : Decorator
    {
        private static double money = 5;

        public override double Cost()
        {
            Console.WriteLine("布丁5块");
            return base.Cost() + money;
        }
    }

    //配料2仙草
    public class XiaoCao : Decorator
    {
        private static double money = 6;

        public override double Cost()
        {
            Console.WriteLine("仙草6快一杯");
            return base.Cost() + money;
        }
    }

    //配料2仙草
    public class ZhenZhu : Decorator
    {
        private static double money = 12;

        public override double Cost()
        {
            Console.WriteLine("珍珠12快一杯");
            return base.Cost() + money;
        }
    }
}