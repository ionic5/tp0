using System;

namespace Portal301.TP0.Client.Core.View
{
    public interface IJointPanel
    {
        event EventHandler MinusButtonClickedEvent;
        event EventHandler PlusButtonClickedEvent;
        event EventHandler<DegreeSettedEventArgs> DegreeSettedEvent;

        void SetDegree(int degree);
        void SetMinusButtonEnabled(bool v);
        void SetPlusButtonEnabled(bool v);
    }
}