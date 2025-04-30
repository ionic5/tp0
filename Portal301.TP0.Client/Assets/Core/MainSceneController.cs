using Portal301.TP0.Client.Core.View;
using System;

namespace Portal301.TP0.Client.Core
{
    public class MainSceneController
    {
        public readonly ISpace space;
        public readonly IControlPanel controlPanel;

        public void OnURRobotDropDownSelectedEvent(object sender, DropDownItemSelectedEventArgs args)
        {
            var index = args.ItemIndex;
            string robotID = "";
            space.SetRobot(robotID);
        }

        public void OnURRobotRemovedEvent(object sender, EventArgs args)
        {
            controlPanel.ClearJointPanels();
        }

        public void OnURRobotSettedEvent(object sender, EventArgs args)
        {
            var jointCount = 6;
            for (var jointIndex = 0; jointIndex < jointCount; jointIndex++)
            {
                var panel = controlPanel.AddJointPanel();
                var urRobot = space.GetURRobot();

                var controller = new JointPanelController(jointIndex, panel, urRobot);
                panel.MinusButtonClickedEvent += controller.OnMinusButtonClickedEvent;
                panel.PlusButtonClickedEvent += controller.OnPlusButtonClickedEvent;
                panel.DegreeSettedEvent += controller.OnDegreeSettedEvent;
            }
        }
    }
}