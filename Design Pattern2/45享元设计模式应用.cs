namespace 享元设计模式应用
{
    class Program
    {
        static void Main45(string[] args)
        {
            BikeFactory factory = new BikeFactory();
            
            FlyWeightBike bike = factory.GetBike();
            bike.Ride("张三");
        }
    }

    public abstract class FlyWeightBike
    {
        //内部状态 Bike ID State 0--锁定中 1--骑行中
        //外部状态 用户
        //骑行 锁定
        public string BikeID { get; set; }
        public int State { get; set; }

        public abstract void Ride(string userName);

        public abstract void Bock(string userName);
    }


    public class YellowBike : FlyWeightBike
    {
        public YellowBike(string id)
        {
            BikeID = id;
        }

        public override void Ride(string userName)
        {
            this.State = 1;
            Console.WriteLine($"用户：{userName}，正在骑行的ID是：{BikeID}的自行车");
        }

        public override void Bock(string userName)
        {
            State = 0;
            Console.WriteLine($"用户：{userName}，归还车的ID是：{BikeID}的自行车");
        }
    }

    public class BikeFactory
    {
        private List<FlyWeightBike> bikeList = new List<FlyWeightBike>();

        public BikeFactory()
        {
            for (int i = 0; i < 3; i++)
            {
                bikeList.Add(new  YellowBike(i.ToString()));
            }
        }

        public FlyWeightBike GetBike()
        {
            for (int i = 0; i < bikeList.Count; i++)
            {
                if (bikeList[i].State == 0)
                {
                    return bikeList[i];
                }
            }
            return null;
        }
    }
}