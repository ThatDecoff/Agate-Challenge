using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Challenge7
{
    public class PointHandler : MonoBehaviour
    {
        private int Point = 0;

        public Text PointText;

        private void Start()
        {
            SetView();
        }

        public void AddPoint(int value)
        {
            Point += value;
            SetView();
        }

        public void SetPoint(int value)
        {
            Point = value;
            SetView();
        }

        private void SetView()
        {
            PointText.text = $"Point : {Point}";
        }
    }
}
