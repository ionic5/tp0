using Portal301.TP0.Client.Core.Data;
using Portal301.TP0.Client.Core.View;
using System;

namespace Portal301.TP0.Client.Core
{
    public class JointPanelController
    {
        public readonly int jointIndex;
        public readonly IJointPanel jointPanel;
        public readonly IURRobot urRobot;
        public readonly URRobotJoint uRRobotJoint;

        public JointPanelController(int jointIndex, IJointPanel jointPanel, IURRobot urRobot, URRobotJoint uRRobotJoint)
        {
            this.jointIndex = jointIndex;
            this.jointPanel = jointPanel;
            this.urRobot = urRobot;
            this.uRRobotJoint = uRRobotJoint;
        }

        public void OnPlusButtonClickedEvent(object sender, EventArgs args)
        {
            SetJointAngle(jointIndex, urRobot.GetJointAngle(jointIndex) + uRRobotJoint.DeltaAngle);
        }

        public void OnMinusButtonClickedEvent(object sender, EventArgs args)
        {
            SetJointAngle(jointIndex, urRobot.GetJointAngle(jointIndex) - uRRobotJoint.DeltaAngle);
        }

        public void OnAngleSettedEvent(object sender, AngleSettedEventArgs args)
        {
            SetJointAngle(jointIndex, args.Angle);
        }

        private void SetJointAngle(int jointIndex, float angle)
        {
            angle = Math.Min(uRRobotJoint.MaxAngle, angle);
            angle = Math.Max(uRRobotJoint.MinAngle, angle);
            urRobot.SetJointAngle(jointIndex, angle);

            jointPanel.SetAngle(angle);
            jointPanel.SetPlusButtonEnabled(angle < uRRobotJoint.MaxAngle);
            jointPanel.SetMinusButtonEnabled(angle > uRRobotJoint.MinAngle);
        }
    }
}
