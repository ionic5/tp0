using System;

namespace Portal301.TP0.Client.Core.View
{
    public class DropDownItemSelectedEventArgs : EventArgs
    {
        public readonly int ItemIndex;

        public DropDownItemSelectedEventArgs(int index)
        {
            ItemIndex = index;
        }
    }
}