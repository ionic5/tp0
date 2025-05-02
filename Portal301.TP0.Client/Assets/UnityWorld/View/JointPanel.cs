using GLTFast.Schema;
using Portal301.TP0.Client.Core.View;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Portal301.TP0.Client.UnityWorld.View
{
    public class JointPanel : IJointPanel
    {
        public event EventHandler MinusButtonClickedEvent;
        public event EventHandler PlusButtonClickedEvent;
        public event EventHandler<AngleSettedEventArgs> AngleSettedEvent;

        private readonly VisualElement root;
        private readonly IntegerField angleInputField;
        private readonly Label indexLabel;
        private readonly UnityEngine.UIElements.Button plusButton;
        private readonly UnityEngine.UIElements.Button minusButton;

        public bool IsActive => root.style.display == DisplayStyle.Flex;

        public JointPanel(VisualElement root)
        {
            this.root = root;
            plusButton = root.Q("PlusButton") as UnityEngine.UIElements.Button;
            minusButton = root.Q("MinusButton") as UnityEngine.UIElements.Button;
            angleInputField = root.Q("AngleInputField") as IntegerField;
            indexLabel = root.Q("IndexLabel") as Label;

            plusButton.RegisterCallback<ClickEvent>(OnPlusButtonClicked);
            minusButton.RegisterCallback<ClickEvent>(OnMinusButtonClicked);
            angleInputField.RegisterValueChangedCallback(OnAngleChanged);
        }

        public void OnAngleChanged(ChangeEvent<int> evt)
        {
            AngleSettedEvent?.Invoke(this, new AngleSettedEventArgs(evt.newValue));
        }

        public void OnPlusButtonClicked(ClickEvent clickEvent)
        {
            PlusButtonClickedEvent?.Invoke(this, EventArgs.Empty);
        }

        public void OnMinusButtonClicked(ClickEvent clickEvent)
        {
            MinusButtonClickedEvent?.Invoke(this, EventArgs.Empty);
        }

        public void SetAngle(float angle)
        {
            angleInputField.SetValueWithoutNotify(Convert.ToInt32(angle));
        }

        public void SetMinusButtonEnabled(bool v)
        {
            minusButton.SetEnabled(v);
        }

        public void SetPlusButtonEnabled(bool v)
        {
            plusButton.SetEnabled(v);
        }

        public void Clear()
        {
            MinusButtonClickedEvent = null;
            PlusButtonClickedEvent = null;
            AngleSettedEvent = null;
        }

        public void SetIndex(int jointIndex)
        {
            indexLabel.text = $"{jointIndex}";
        }

        public void SetActive(bool value)
        {
            root.style.display = value ? DisplayStyle.Flex : DisplayStyle.None;
        }
    }
}