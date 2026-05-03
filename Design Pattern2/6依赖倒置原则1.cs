namespace 依赖倒置原则1
{
    class Program
    {
        static void Main6(string[] args)
        {
            //歌手唱中国的歌曲
            //歌手对象一：唱歌
            //歌曲：返网歌曲的歌词
            Singer singer = new Singer();
            singer.SingASong(new EnglishSong());
            singer.SingASong(new ChineseSong());
        }
    }

    //把可变抽象成接口

    public interface ISongWords
    {
        string GetSongWords();
    }


    public class ChineseSong : ISongWords
    {
        public string GetSongWords()
        {
            return "中国歌曲";
        }
    }

    public class EnglishSong : ISongWords
    {
        public string GetSongWords()
        {
            return "英文歌曲";
        }
    }
    //=====================================================//


    //Singer作为高层模块，目前是严格依赖底层模块的d
    public class Singer //高层模块
    {
        //底层模块
        public void SingASong(ISongWords words)
        {
            Console.WriteLine("歌手正在唱：" + words.GetSongWords());
        }
    }
}