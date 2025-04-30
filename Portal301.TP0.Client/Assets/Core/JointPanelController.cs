using Portal301.TP0.Client.Core.View;
using System;

namespace Portal301.TP0.Client.Core
{
    public class JointPanelController
    {
        public readonly int jointIndex;
        public readonly IJointPanel jointPanel;
        public readonly IURRobot urRobot;

        public JointPanelController(int jointIndex, IJointPanel jointPanel, IURRobot urRobot)
        {
            this.jointIndex = jointIndex;
            this.jointPanel = jointPanel;
            this.urRobot = urRobot;
        }

        public void OnPlusButtonClickedEvent(object sender, EventArgs args)
        {
            urRobot.IncreaseJointDegree(1);
            Update();
        }

        public void OnMinusButtonClickedEvent(object sender, EventArgs args)
        {
            urRobot.DecreaseJointDegree(1);
            Update();
        }

        public void OnDegreeSettedEvent(object sender, DegreeSettedEventArgs args)
        {
            urRobot.SetJointDegree(args.Degree);
            Update();
        }

        private void Update()
        {
            var degree = urRobot.GetJointDegree(jointIndex);
            jointPanel.SetDegree(degree);
            jointPanel.SetPlusButtonEnabled(urRobot.IsJointDegreeReachedMax(jointIndex));
            jointPanel.SetMinusButtonEnabled(urRobot.IsJointDegreeReachedMin(jointIndex));
        }
    }
}
