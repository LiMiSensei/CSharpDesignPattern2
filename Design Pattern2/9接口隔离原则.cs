namespace 接口隔离原则
{
    class Program
    {
        static void Main9(string[] args)
        {
        }

        public interface IScore
        {
            //查询成绩
            void QueryScore(); //学生可以做

            //修改成绩
            void UpdateScore();

            //添加成绩
            void AddScore();

            //刑除成绩
            void DeleteScore();

            //计算总成续
            double GetSumScore();

            //计算班级平均成绩
            double GetAvgScore();

            //打印成绩单
            void PrintScore(); //学生可以做

            //发送成绩单
            void Sendscore();
        }

        public interface ITeacherScore
        {
            //修改成绩
            void UpdateScore();

            //添加成绩
            void AddScore();

            //刑除成绩
            void DeleteScore();

            //计算总成续
            double GetSumScore();

            //计算班级平均成绩
            double GetAvgScore();
        }

        public interface IStudentScore
        {
            //查询成绩
            void QueryScore(); //学生可以做

            //打印成绩单
            void PrintScore(); //学生可以做
        }
    }
}