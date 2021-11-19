using UnityEngine;
using UnityEngine.UI;

namespace Game.Challenge9
{
    public class TimerController : MonoBehaviour
    {
        public GameOverHandler gameOverHandler;

        public int TimeInSeconds = 90;

        public Text TimerText;

        private long timer;

        private void Start()
        {
            timer = TimeInSeconds * 1000;
            TimerText.text = ConvertTimer(timer);
        }

        public void Update()
        {
            if(timer > 0)
            {
                timer -= (long)Mathf.Round(Time.deltaTime * 1000);
                if (timer < 0) timer = 0;
                TimerText.text = ConvertTimer(timer);
            }
            else
            {
                OnTimerExpire();
            }
        }

        private void OnTimerExpire()
        {
            gameOverHandler.OnGameOver();
        }

        private string ConvertTimer(long time)
        {
            int milisec = (int)(time % 1000);
            int second = (int)(time / 1000) % 60;
            int minute = (int)(time / 1000) / 60;

            return $"{minute:00} : {second:00} : {milisec:000}";
        }
    }
}
