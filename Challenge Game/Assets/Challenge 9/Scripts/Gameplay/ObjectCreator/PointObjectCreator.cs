namespace Game.Challenge9
{
    public class PointObjectCreator : ObjectCreator
    {
        public ScoreHandler scoreHandler;

        public int point = 1;

        protected override void OnDespawn(BaseObject obj)
        {
            scoreHandler.AddScore(point);
            AddToDespawned(obj);

            Invoke("SpawnObject", 3);
        }
    }

}
