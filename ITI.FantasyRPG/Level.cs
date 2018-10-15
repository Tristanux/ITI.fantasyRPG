namespace ITI.FantasyRPG
{
    public class Level
    {
        public Level()
        {
            Number = 1;
            Experience = 0;
        }

        public int Number { get; private set; }
        public int Experience { get; private set; }

        public void Add(int points)
        {
            Experience += points;
            Number += 1;
        }
    }
}