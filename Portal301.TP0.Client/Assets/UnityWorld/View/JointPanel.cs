using Portal301.TP0.Client.Core.View;
using System;
using System.Collections;
using UnityEngine;

namespace Portal301.TP0.Client.UnityWorld.View
{
    public class JointPanel : MonoBehaviour, IJointPanel
    {
        public event EventHandler MinusButtonClickedEvent;
        public event EventHandler PlusButtonClickedEvent;
        public event EventHandler<DegreeSettedEventArgs> DegreeSettedEvent;

        public void SetDegree(int degree)
        {
            throw new NotImplementedException();
        }

        public void SetMinusButtonEnabled(bool v)
        {
            throw new NotImplementedException();
        }

        public void SetPlusButtonEnabled(bool v)
        {
            throw new NotImplementedException();
        }
    }
}