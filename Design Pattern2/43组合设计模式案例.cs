namespace 组合设计模式案例
{
    class Program
    {
        static void Main43(string[] args)
        {
            //Component 根节点  公司
            //Composite 树枝    部门
            //leaf      树叶    员工

            Component component = new DepartComposite("上市大公司");

            Component dep1 = new DepartComposite("总裁办");

            Component boss = new Employee("孙叔");
            
            //把部门添加到公司下
            component.Add(dep1);
            //把员工添加到部门下
            dep1.Add(boss);
            
            //打印效果
            component.Displaay(3);
        }
    }

    public abstract class Component
    {
        public string Name { get; set; }

        protected Component(string name)
        {
            Name = name;
        }

        public abstract void Add(Component component);
        public abstract void Remove(Component component);
        public abstract void Displaay(int depth);
    }

    public class DepartComposite : Component
    {
        public DepartComposite(string name) : base(name)
        {
        }

        //存储部门或者员工
        private List<Component> listComponent = new();

        public override void Add(Component component)
        {
            listComponent.Add(component);
        }

        public override void Remove(Component component)
        {
            listComponent.Remove(component);
        }

        public override void Displaay(int depth)
        {
            Console.WriteLine(new string('-', depth) + base.Name);
            foreach (Component component in listComponent)
            {
                component.Displaay(depth + 4);
            }
        }
    }

    public class Employee : Component
    {
        public Employee(string name) : base(name)
        {
        }

        public override void Add(Component component)
        {
            
        }

        public override void Remove(Component component)
        {
            
        }

        public override void Displaay(int depth)
        {
            Console.WriteLine(new string('-', depth) + base.Name);
        }
    }
}