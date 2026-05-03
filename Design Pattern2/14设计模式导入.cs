namespace 设计模式导入
{
    class Program
    {
        static void Main14(string[] args)
        {
        }

        //============================ 泛化&实现 ==============================//
        //2实现 继承接口
        public interface IClimb
        {
            void Climb();
        }

        //1 泛化 描述的是继承
        public class Animal
        {
            public char _gender;

            public void Eat()
            {
                Console.WriteLine("吃饭");
            }

            public void Sleep()
            {
                Console.WriteLine("睡觉");
            }
        }

        public class Tiger : Animal, IClimb
        {
            private string _name;
            private Leg _leg;
            private Food _food; //5 关联关系

            public Tiger(Leg leg)
            {
                //创建老虎就得创建腿 --》这就是组合
                _leg = leg;
            }

            public Tiger()
            {
                //放在构造函数里面也是一种
                _leg = new Leg();
            }

            public void Climb()
            {
            }
        }

        public class Leg
        {
            //3 组合关系
            private int _Count;
        }

        //4 聚合关系
        public class TigerGraph
        {
            //4聚合关系
            private Tiger[] _tigers;
        }

        //5 关联关系
        public class Food
        {
            public string FoodName;
            public string FoodColor;
        }

        //依赖
        public class Water
        {
            private float _weight;
        }
    }
}