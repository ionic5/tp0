using Portal301.TP0.Client.Core.View;
using System;
using System.Linq;
using UnityEngine;

namespace Portal301.TP0.Client.UnityWorld.View
{
    public class Facility : MonoBehaviour, IFacility
    {
        public event EventHandler URRobotRemovedEvent;
        public event EventHandler URRobotSettedEvent;

        public ResourceDataStore ResourceDataStore;
        private URRobot urRobot;

        public IURRobot GetURRobot()
        {
            return urRobot;
        }

        public void SetRobot(string robotID)
        {
            if (urRobot != null)
            {
                Destroy(urRobot.gameObject);
                URRobotRemovedEvent?.Invoke(this, EventArgs.Empty);
            }

            var urRobotRD = ResourceDataStore.URRobots.FirstOrDefault(item => item.URRobotID == robotID);
            var original = Resources.Load<URRobot>(urRobotRD.Path);
            urRobot = Instantiate(original);
            urRobot.Setup();
            urRobot.transform.position = Vector3.zero;

            URRobotSettedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}