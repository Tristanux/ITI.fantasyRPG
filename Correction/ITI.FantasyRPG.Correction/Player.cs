namespace ITI.FantasyRPG
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            Combat = 10;
            Defense = 10;
            Speed = 10;
            Level = new Level();
        }

        public string Name { get; }
        public int Combat { get; private set; }
        public int Defense { get; private set; }
        public int Speed { get; private set; }
        public Level Level { get; private set; }
    }
}