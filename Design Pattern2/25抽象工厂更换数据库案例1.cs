namespace 抽象工厂更换数据库案例1
{
    class Program
    {
        static void Main25(string[] args)
        {
            //练习： 更换数据库
            //刚入行的小白
            //两年的小白  工厂方法设计模式
            //五年的大白

            User user = new User();
            user.Name = "张三";
            user.ID = 1;

            //SqlServerUser sqlServerUser = new SqlServerUser();
            //sqlServerUser.InsertUser(user);
            //sqlServerUser.GetUser(user.ID);
            Department department = new Department();
            department.Name = "张三";
            department.ID = 1;
            
            IFactory factory = new SQLiteFactoryUser();
            IDatabaseUser databaseUser = factory.GetUser();
            IDatabaseDepartment databaseDepartment = factory.GetDepartment();
            databaseUser.InsertUser(user);
            databaseUser.GetUser(user.ID);
            
            databaseDepartment.InsertDepartment(department);
            databaseDepartment.GetDepartment(department.ID);
            
        }

        public class User
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }


        public class Department
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }
        
        
        
//====================================================
        public interface IDatabaseDepartment
        {
            void InsertDepartment(Department department);
            Department GetDepartment(int id);
        }

        public class SqlSeverDepartment : IDatabaseDepartment
        {
            public void InsertDepartment(Department department)
            {
                Console.WriteLine($"SqlSeverDepartment插入了{department.Name}");
            }

            public Department GetDepartment(int id)
            {
                Console.WriteLine($"SqlSeverDepartment获取了{id}");
                return null;
            }
        }
        
        public class SQLiteSeverDepartment : IDatabaseDepartment
        {
            public void InsertDepartment(Department department)
            {
                Console.WriteLine($"SQLiteSeverDepartment插入了{department.Name}");
            }

            public Department GetDepartment(int id)
            {
                Console.WriteLine($"SQLiteSeverDepartment获取了{id}");
                return null;
            }
        }
        
        public class MySeverDepartment : IDatabaseDepartment
        {
            public void InsertDepartment(Department department)
            {
                Console.WriteLine($"MySeverDepartment插入了{department.Name}");
            }

            public Department GetDepartment(int id)
            {
                Console.WriteLine($"MySeverDepartment获取了{id}");
                return null;
            }
        }

//====================================================
        public interface IDatabaseUser
        {
            void InsertUser(User user);
            User GetUser(int id);
        }

        public class SqlServerUser : IDatabaseUser
        {
            public void InsertUser(User user)
            {
                Console.WriteLine($"Sql插入了：{user.Name}");
            }

            public User GetUser(int id)
            {
                Console.WriteLine($"Sql获取了ID是{id}的用户");
                return null;
            }
        }

        public class MysqlUser : IDatabaseUser
        {
            public void InsertUser(User user)
            {
                Console.WriteLine($"MysqlUser插入了：{user.Name}");
            }

            public User GetUser(int id)
            {
                Console.WriteLine($"MysqlUser获取了ID是{id}的用户");
                return null;
            }
        }

        public class SQLiteUser : IDatabaseUser
        {
            public void InsertUser(User user)
            {
                Console.WriteLine($"SQLiteUser插入了：{user.Name}");
            }

            public User GetUser(int id)
            {
                Console.WriteLine($"SQLiteUser获取了ID是{id}的用户");
                return null;
            }
        }
//====================================================
        public interface IFactory
        {
            IDatabaseUser GetUser();            //获取用户信息
            IDatabaseDepartment GetDepartment();//获取我们操作部门表的对象
        }

        public class SqlSeverFactoryUser : IFactory
        {
            public IDatabaseUser GetUser()
            {
                return new SqlServerUser();
            }

            public IDatabaseDepartment GetDepartment()
            {
                return  new SqlSeverDepartment();
            }
        }

        public class MysqlSeverFactoryUser : IFactory
        {
            public IDatabaseUser GetUser()
            {
                return new MysqlUser();
            }

            public IDatabaseDepartment GetDepartment()
            {
                return new MySeverDepartment();
            }
        }

        public class SQLiteFactoryUser : IFactory
        {
            public IDatabaseUser GetUser()
            {
                return new SQLiteUser();
            }

            public IDatabaseDepartment GetDepartment()
            {
                return new SQLiteSeverDepartment();
            }
        }
    }
}