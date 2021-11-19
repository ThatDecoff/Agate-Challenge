using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game.Challenge9
{
    public class ConfirmModal : MonoBehaviour
    {
        public Text Title;
        public Text Message;
        public Button ConfirmButton;
        public Button CancelButton;

        public void ShowModal(string TitleText, string MessageText, UnityAction OnConfirm, UnityAction OnCancel=null)
        {
            Title.text = TitleText;
            Message.text = MessageText;

            SetButtonAction(ConfirmButton, OnConfirm);
            if(OnCancel != null)
            {
                SetButtonAction(CancelButton, OnCancel);
            }
            gameObject.SetActive(true);
        }

        public void DisableModal()
        {
            gameObject.SetActive(false);
        }

        private void SetButtonAction(Button button, UnityAction action)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(action);
            button.onClick.AddListener(DisableModal);
        }
    }
}
