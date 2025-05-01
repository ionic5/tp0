using System;

namespace Portal301.TP0.Client.Core.View
{
    public interface IJointPanel
    {
        event EventHandler MinusButtonClickedEvent;
        event EventHandler PlusButtonClickedEvent;
        event EventHandler<AngleSettedEventArgs> AngleSettedEvent;

        void SetAngle(float angle);
        void SetIndex(int jointIndex);
        void SetMinusButtonEnabled(bool v);
        void SetPlusButtonEnabled(bool v);
    }
}