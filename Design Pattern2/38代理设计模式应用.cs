namespace 代理设计模式应用
{
    class Program
    {
        static void Main38(string[] args)
        {
            IOrder order = new PoxyOrder(
                new RealOrder("笔记本电脑", 100, "张三"));
            
            order.SetOrderNum(200,"张三");
        }
    }

    public interface IOrder
    {
        int GetOrderNum();
        string GetProductUser();
        string GetProductName();

        void SetOrderNum(int orderNum, string user);

        void SetOrderUser(string orderName, string user);

        void SetProductName(string productName, string user);
    }

    public class RealOrder : IOrder
    {
        public string ProductName;
        public int ProductCount;
        public string OrderUser;


        public RealOrder(string productName, int productCount, string orderUser)
        {
            ProductName = productName;
            ProductCount = productCount;
            OrderUser = orderUser;
        }


        public int GetOrderNum()
        {
            return ProductCount;
        }

        public string GetProductUser()
        {
            return OrderUser;
        }

        public string GetProductName()
        {
            return ProductName;
        }

        public void SetOrderNum(int orderNum, string user)
        {
            this.ProductCount = orderNum;
        }

        public void SetOrderUser(string orderUserName, string user)
        {
            this.OrderUser = orderUserName;
        }

        public void SetProductName(string productName, string user)
        {
            this.ProductName = productName;
        }
    }

    public class PoxyOrder : IOrder
    {
        private RealOrder realOrder;

        public PoxyOrder(RealOrder realOrder)
        {
            this.realOrder = realOrder;
        }


        public int GetOrderNum()
        {
            throw new NotImplementedException();
        }

        public string GetProductUser()
        {
            throw new NotImplementedException();
        }

        public string GetProductName()
        {
            throw new NotImplementedException();
        }

        public void SetOrderNum(int orderNum, string user)
        {
            if (user == null && user.Equals(this.realOrder))
            {
                this.realOrder.SetOrderNum(orderNum, user);
            }
            else
            {
                Console.WriteLine("你无权修改");
            }
        }

        public void SetOrderUser(string orderName, string user)
        {
            if (user == null && user.Equals(this.realOrder))
            {
                this.realOrder.SetOrderUser(orderName, user);
            }
            else
            {
                Console.WriteLine("你无权修改");
            }
        }

        public void SetProductName(string productName, string user)
        {
            if (user == null && user.Equals(this.realOrder))
            {
                this.realOrder.SetProductName(productName, user);
            }
            else
            {
                Console.WriteLine("你无权修改");
            }
        }
    }
}