namespace 外观设计模式
{
    class Program
    {
        static void Main39(string[] args)
        {
            Palice palice = new Palice();
            Street street = new Street();
            Hospital hospital = new Hospital();
            palice.GetHuJi();
            street.GetHuKou();
            hospital.GetBorn();
            
            
            DaTing daTing = new DaTing();
            daTing.KaiZhenMing();
        }
    }


    public class DaTing
    {
        private Palice palice = new Palice();
        private Street _street = new Street();
        private Hospital hospital = new Hospital();
        
        public void KaiZhenMing()
        {
            this.palice.GetHuJi();
            this._street.GetHuKou();
            this.hospital.GetBorn();
        }
    }
    public class Palice
    {
        public void GetHuJi()
        {
            Console.WriteLine("开户籍证明");
        }
        
    }

    public class Street
    {
        public void GetHuKou()
        {
            Console.WriteLine("开户口证明");
        }
    }
    
    public class Hospital
    {
        public void GetBorn()
        {
            Console.WriteLine("开出生证明");
        }
    }
    
}