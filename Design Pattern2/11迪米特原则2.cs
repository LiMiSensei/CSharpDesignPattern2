namespace 迪米特原则2
{
    class Program
    {
        static void Main11(string[] args)
        {
            //打印总公司员工的ID和分公司员工的ID

            //类1：总公司的工类
            //类2：总公司的员工管理类
            //1，获取到总公司所有的员工
            //2，打印总公司所有员工的ID
            //3，打印总公司所有员工的ID
            //类3：分公司员工类
            //类4：分公司员工管理类
            //1，获取分公司所有员工
            //2,打印分公司所有员工ID

            HeadOfficeManager headOfficeManager = new HeadOfficeManager();
            BranchOfficeManager branchOfficeManager = new BranchOfficeManager();
            headOfficeManager.Print();
            branchOfficeManager.Print();
        }

        public class HeadOfficeEmployee
        {
            public int ID { get; set; }
        }

        public class BranchOfficeEmployee
        {
            public int ID { get; set; }
        }

        //分析：对于HeadOfficeManage而言，谁是他的直接朋友

        //HeadOfficeEmployee 是直接朋友
        public class HeadOfficeManager
        {
            //获取总公司所有员工
            public List<HeadOfficeEmployee> GetHeadOfficeEmployee()
            {
                List<HeadOfficeEmployee> list = new();
                for (int i = 0; i < 10; i++)
                {
                    HeadOfficeEmployee headOfficeEmployee = new HeadOfficeEmployee();
                    headOfficeEmployee.ID = i;
                    list.Add(headOfficeEmployee);
                }

                return list;
            }

            //打印总公司员工的ID
            public void Print()
            {
                //1，打印总公司所有员工
                List<HeadOfficeEmployee> listHead = new();
                Console.WriteLine("总公司的员工ID分别是：");
                foreach (var item in listHead)
                {
                    Console.WriteLine(item.ID);
                }

                // //2，分别打印所有员工ID
                // List<BranchOfficeEmployee> listBranch = manager.GetBranchOfficeEmployee();
                // Console.WriteLine("分总公司的员工ID分别是：");
                // foreach (var item in listBranch)
                // {
                //     Console.WriteLine(item.ID);
                // }
            }
        }


        public class BranchOfficeManager
        {
            //获取分公司员工
            public List<BranchOfficeEmployee> GetBranchOfficeEmployee()
            {
                List<BranchOfficeEmployee> list = new();
                for (int i = 0; i < 4; i++)
                {
                    BranchOfficeEmployee headOfficeEmployee = new BranchOfficeEmployee();
                    headOfficeEmployee.ID = i;
                    list.Add(headOfficeEmployee);
                }

                return list;
            }

            public void Print()
            {
                //2，分别打印所有员工ID
                List<BranchOfficeEmployee> listBranch = this.GetBranchOfficeEmployee();
                Console.WriteLine("分总公司的员工ID分别是：");
                foreach (var item in listBranch)
                {
                    Console.WriteLine(item.ID);
                }
            }
        }
    }
}