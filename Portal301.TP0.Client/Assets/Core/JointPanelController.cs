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
            urRobot.IncreaseJointAngle(1);
            Update();
        }

        public void OnMinusButtonClickedEvent(object sender, EventArgs args)
        {
            urRobot.DecreaseJointAngle(1);
            Update();
        }

        public void OnAngleSettedEvent(object sender, AngleSettedEventArgs args)
        {
            urRobot.SetJointAngle(args.Angle);
            Update();
        }

        private void Update()
        {
            var angle = urRobot.GetJointAngle(jointIndex);
            jointPanel.SetAngle(angle);
            jointPanel.SetPlusButtonEnabled(urRobot.IsJointAngleReachedMax(jointIndex));
            jointPanel.SetMinusButtonEnabled(urRobot.IsJointAngleReachedMin(jointIndex));
        }
    }
}
