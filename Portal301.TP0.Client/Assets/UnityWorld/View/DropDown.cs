using Portal301.TP0.Client.Core.View;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.UnityWorld.View
{
    public class DropDown : MonoBehaviour, IDropDown
    {
        public event EventHandler<DropDownItemSelectedEventArgs> ItemSelectedEvent;

        [SerializeField]
        private TMP_Dropdown dropdown;

        public void AddItem(string id)
        {
            dropdown.AddOptions(new List<string> { id });
        }

        public void SelectItem(int index)
        {
            dropdown.value = index;
        }

        public void OnItemSelected(int index)
        {
            ItemSelectedEvent?.Invoke(this, new DropDownItemSelectedEventArgs(index));
        }

        private void OnDestroy()
        {
            ItemSelectedEvent = null;
        }
    }
}