using Portal301.TP0.Client.Core.View;
using System;
using System.Collections;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Portal301.TP0.Client.UnityWorld.View
{
    public class JointPanel : MonoBehaviour, IJointPanel
    {
        public event EventHandler MinusButtonClickedEvent;
        public event EventHandler PlusButtonClickedEvent;
        public event EventHandler<AngleSettedEventArgs> AngleSettedEvent;

        [SerializeField]
        private Button plusButton;
        [SerializeField]
        private Button minusButton;
        [SerializeField]
        private TMP_InputField angleInputField;
        [SerializeField]
        private TMP_Text indexText;

        public void OnDropDownValueChanged(string value)
        {
            if (int.TryParse(value, out int number))
                AngleSettedEvent?.Invoke(this, new AngleSettedEventArgs(number));

            if (string.IsNullOrEmpty(value))
                SetAngle(0);
        }

        public void OnPlusButtonClicked()
        {
            PlusButtonClickedEvent?.Invoke(this, EventArgs.Empty);
        }

        public void OnMinusButtonClicked()
        {
            MinusButtonClickedEvent?.Invoke(this, EventArgs.Empty);
        }

        public void SetAngle(float angle)
        {
            angleInputField.SetTextWithoutNotify($"{angle}");
        }

        public void SetMinusButtonEnabled(bool v)
        {
            minusButton.interactable = v;
        }

        public void SetPlusButtonEnabled(bool v)
        {
            plusButton.interactable = v;
        }

        public void Clear()
        {
            MinusButtonClickedEvent = null;
            PlusButtonClickedEvent = null;
            AngleSettedEvent = null;
        }

        public void SetIndex(int jointIndex)
        {
            indexText.text = $"{jointIndex}";
        }
    }
}