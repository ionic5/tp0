using Portal301.TP0.Client.Core.View;
using System;
using System.Linq;

namespace Portal301.TP0.Client.Core
{
    public class MainSceneController
    {
        public readonly IFacility facility;
        public readonly IControlPanel controlPanel;
        public readonly DataStore dataStore;
        private string urRobotID;

        public MainSceneController(IFacility facility, IControlPanel controlPanel, DataStore dataStore)
        {
            this.facility = facility;
            this.controlPanel = controlPanel;
            this.dataStore = dataStore;
            urRobotID = string.Empty;
        }

        public void OnURRobotDropDownSelectedEvent(object sender, DropDownItemSelectedEventArgs args)
        {
            var urRobotData = dataStore.URRobots.FirstOrDefault(item => item.Index == args.ItemIndex);
            urRobotID = urRobotData.ID;

            facility.SetRobot(urRobotID);
        }

        public void OnURRobotRemovedEvent(object sender, EventArgs args)
        {
            controlPanel.ClearJointPanels();
        }

        public void OnURRobotSettedEvent(object sender, EventArgs args)
        {
            var urRobotData = dataStore.URRobots.FirstOrDefault(item => item.ID == urRobotID);
            var uRRobotJoints = dataStore.URRobotJoints.Where(item => item.URRobotID == urRobotID).OrderBy(item => item.Index);

            for (var jointIndex = 0; jointIndex < uRRobotJoints.Count(); jointIndex++)
            {
                var panel = controlPanel.AddJointPanel();
                var urRobot = facility.GetURRobot();

                var controller = new JointPanelController(jointIndex, panel, urRobot);
                panel.MinusButtonClickedEvent += controller.OnMinusButtonClickedEvent;
                panel.PlusButtonClickedEvent += controller.OnPlusButtonClickedEvent;
                panel.DegreeSettedEvent += controller.OnDegreeSettedEvent;
            }
        }
    }
}