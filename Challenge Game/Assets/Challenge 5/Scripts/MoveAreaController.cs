using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Challenge5
{
    public class MoveAreaController : MonoBehaviour, IPointerDownHandler
    {
        private event Action<Vector2> OnMouseClick = delegate { };

        public void AddClickListener(Action<Vector2> method)
        {
            OnMouseClick += method;
        }

        public void RemoveClickListener(Action<Vector2> method)
        {
            OnMouseClick -= method;
        }

        public void ClearClickListener()
        {
            OnMouseClick = delegate { };
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnMouseClick.Invoke(eventData.position);
        }
    }
}
