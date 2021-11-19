namespace Game.Challenge9
{
    [System.Serializable]
    public class ScoreData
    {
        public string Name;
        public int Score;

        public ScoreData(string Name, int Score)
        {
            this.Name = Name;
            this.Score = Score;
        }

        public static int ScoreDataCompare(ScoreData obj1, ScoreData obj2)
        {
            return obj1.Score - obj2.Score;
        }
    }
}
