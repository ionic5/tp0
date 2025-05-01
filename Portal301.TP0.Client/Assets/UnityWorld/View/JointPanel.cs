using Portal301.TP0.Client.Core.View;
using System;
using System.Collections;
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

        public void OnDropDownValueChanged(string value)
        {
            AngleSettedEvent?.Invoke(this, new AngleSettedEventArgs(Convert.ToInt32(value)));
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
            AngleSettedEvent?.Invoke(this, new AngleSettedEventArgs(angle));
        }

        public void SetMinusButtonEnabled(bool v)
        {
            minusButton.enabled = v;
        }

        public void SetPlusButtonEnabled(bool v)
        {
            plusButton.enabled = v;
        }

        public void Clear()
        {
            MinusButtonClickedEvent = null;
            PlusButtonClickedEvent = null;
            AngleSettedEvent = null;
        }
    }
}