using Portal301.TP0.Client.Core.View;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace Portal301.TP0.Client.UnityWorld.View
{
    public class DropDown : IDropDown
    {
        public event EventHandler<DropDownItemSelectedEventArgs> ItemSelectedEvent;

        private readonly DropdownField dropdownField;

        public DropDown(VisualElement root)
        {
            dropdownField = root as DropdownField;

            dropdownField.RegisterValueChangedCallback(OnItemSelected);
        }

        public void AddItem(string id)
        {
            if (dropdownField.choices == null)
                dropdownField.choices = new List<string>();
            dropdownField.choices.Add(id);
        }

        public void SelectItem(int index)
        {
            if (index >= 0 && index < dropdownField.choices.Count)
                dropdownField.value = dropdownField.choices[index];
        }

        public void OnItemSelected(ChangeEvent<string> evt)
        {
            var value = evt.newValue;
            var index = dropdownField.choices.IndexOf(value);

            ItemSelectedEvent?.Invoke(this, new DropDownItemSelectedEventArgs(index));
        }

        private void OnDestroy()
        {
            ItemSelectedEvent = null;
        }
    }
}