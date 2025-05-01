using Portal301.TP0.Client.Core.Data;
using System.Collections.Generic;

namespace Portal301.TP0.Client.Core
{
    public class DataStore
    {
        public List<Camera> Cameras;
        public List<URRobot> URRobots;
        public List<URRobotJoint> URRobotJoints;

        public DataStore()
        {
            Cameras = new List<Camera>();
            URRobots = new List<URRobot>();
            URRobotJoints = new List<URRobotJoint>();
        }
    }
}
