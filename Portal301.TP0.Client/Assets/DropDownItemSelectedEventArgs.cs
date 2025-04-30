using System;

public class DropDownItemSelectedEventArgs : EventArgs
{
    public readonly int ItemIndex;

    public DropDownItemSelectedEventArgs(int index)
    {
        ItemIndex = index;
    }
}