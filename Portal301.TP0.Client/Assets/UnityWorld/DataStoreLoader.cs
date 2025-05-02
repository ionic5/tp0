using Portal301.TP0.Client.Core;
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using UnityEngine;

namespace Portal301.TP0.Client.UnityWorld
{
    public class DataStoreLoader : MonoBehaviour
    {
        [SerializeField]
        private string rootPath;

        public ReadCsvAction ReadCsvAction;

        public void Load(DataStore dataStore)
        {
            LoadCameras(dataStore);
            LoadURRobots(dataStore);
            LoadURRobotJoints(dataStore);
        }

        private void LoadURRobotJoints(DataStore dataStore)
        {
            ReadCsvAction.Invoke($"{rootPath}/URRobotJoint", (reader) =>
            {
                var row = new Core.Data.URRobotJoint();
                row.URRobotID = reader.GetField("urRobotID");
                row.Index = Convert.ToInt32(reader.GetField("index"));
                row.DeltaAngle = Convert.ToSingle(reader.GetField("deltaAngle"));
                row.MaxAngle = Convert.ToSingle(reader.GetField("maxAngle"));
                row.MinAngle = Convert.ToSingle(reader.GetField("minAngle"));

                dataStore.URRobotJoints.Add(row);
            });
        }

        private void LoadURRobots(DataStore dataStore)
        {
            ReadCsvAction.Invoke($"{rootPath}/URRobot", (reader) =>
            {
                var row = new Core.Data.URRobot();
                row.ID = reader.GetField("id");
                row.Index = Convert.ToInt32(reader.GetField("index"));

                dataStore.URRobots.Add(row);
            });
        }

        private void LoadCameras(DataStore dataStore)
        {
            ReadCsvAction.Invoke($"{rootPath}/Camera", (reader) =>
            {
                var row = new Core.Data.Camera();
                row.RotateSpeed = Convert.ToSingle(reader.GetField("rotateSpeed"));
                row.MoveSpeed = Convert.ToSingle(reader.GetField("moveSpeed"));
                row.ZoomSpeed = Convert.ToSingle(reader.GetField("zoomSpeed"));

                dataStore.Cameras.Add(row);
            });
        }
    }
}