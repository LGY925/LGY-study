using System.IO.Compression;

namespace _13._Factory_Builder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. 첫맵
            MonsterFactory Level01Factory = new MonsterFactory();
            Level01Factory.rate = 1.5f;
            Monster Level01Monster = Level01Factory.Create("고블린");
            Monster Level01Monster0 = Level01Factory.Create("고블린");
            Monster Level01Monster1 = Level01Factory.Create("고블린");
            Monster Level01Monster2 = Level01Factory.Create("슬라임");

            // 2. 두번쨰맵
            MonsterFactory Level02Factory = new MonsterFactory();
            Level02Factory.rate = 2.5f;
            Monster Level02Monster3 = Level02Factory.Create("고블린");
            Monster Level02Monster4 = Level02Factory.Create("고블린");
            Monster Level02Monster5 = Level02Factory.Create("고블린");
            Monster Level02Monster6 = Level02Factory.Create("슬라임");

            GameObject gameObject = new GameObject();
            gameObject.SetX(10).SetY(10).SetZ(10);

            HambergerBuilder CAWbgb = new HambergerBuilder();
            CAWbgb.SetBread("참꺠방")
                .SetSource("샤워소스")
                .SetPatty("쇠고기패티")
                .SetVegetable("양배추");
            Hamberger hamberger = CAWbgb.Builder();
            Hamberger hamberger1 = CAWbgb.Builder();
            
            HambergerBuilder SSbgb = new HambergerBuilder();
            SSbgb.SetBread("버터빵")
                .SetSource("머스타드")
                .SetPatty("세우패티")
                .SetVegetable("양상추");
            Hamberger hamberger2 = SSbgb.Builder();
            Hamberger hamberger3 = SSbgb.Builder();
        }
    }
    public class HambergerBuilder
    {
        public string bread;
        public string source;
        public string patty;
        public string vegetable;
        public HambergerBuilder()
        {
            bread = "기본빵";
            source="케찹";
            patty="기본패티";
            vegetable="양상추";
        }

        public Hamberger Builder()
        {
            Hamberger hamberger=new Hamberger();
            hamberger.bread=bread;
            hamberger.source=source;
            hamberger.patty=patty;
            hamberger.vegetable=vegetable;
            return hamberger;
        }
        public HambergerBuilder SetBread(string bread)
        {
            this.bread = bread;
            return this;
        }
        public HambergerBuilder SetSource(string source)
        {
            this.source = source;
            return this;
        }
        public HambergerBuilder SetPatty(string patty)
        {
            this.patty = patty;
            return this;
        }
        public HambergerBuilder SetVegetable(string vegetable)
        {
            this.vegetable = vegetable;
            return this;
        }
    }
    public class Hamberger
    {
        public string bread;
        public string source;
        public string patty;
        public string vegetable;
    }
    public class GameObject
    {
        public int x;
        public int y;
        public int z;

        public GameObject SetX(int x)
        {
            this.x = x; return this;
        }
        public GameObject SetY(int y)
        {
            this.y = y; return this;
        }
        public GameObject SetZ(int z)
        {
            this.z = z; return this;
        }
    }


    public class MonsterFactory
    {
        public float rate;

        public Monster Create(string name)
        {
            Monster monster;
            switch (name)
            {
                case "슬라임":    
                    monster = new Monster("슬라임", 1, 100); break;
                case "고블린":    
                    monster = new Monster("고블린", 3, 200); break;
                case "오크족장":  
                    monster = new Monster("오크족장", 10, 2000); break;
                default: return null;
            }

            monster.hp = (int)(monster.hp * rate);
            return monster;
        }

        public Monster Create(string name, float rate)
        {
            Monster monster = Create(name);
            monster.hp = (int)(monster.hp * rate);
            return monster;
        }
    }

    public class Monster
    {
        private string name;
        private int level;
        public int hp;

        public Monster(string name, int level,int hp)
        {
            this.name = name;
            this.level = level;
            this.hp = hp;
        }
    }
}
