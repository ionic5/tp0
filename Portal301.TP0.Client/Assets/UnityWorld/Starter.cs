using Portal301.TP0.Client.Core;
using Portal301.TP0.Client.UnityWorld.View;
using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Linq;
using Unity.Burst.CompilerServices;
using UnityEngine;

namespace Portal301.TP0.Client.UnityWorld
{
    public class Starter : MonoBehaviour
    {
        [SerializeField]
        private MainScene mainScene;

        // Use this for initialization
        void Start()
        {
            var dataStore = new DataStore();
            Load(dataStore);

            var resourceDataStore = new ResourceDataStore();
            Load(resourceDataStore);

            var camCtrl = new CameraController(mainScene.Camera, dataStore.Cameras.FirstOrDefault());
            mainScene.MouseScrollDownEvent += camCtrl.OnMouseScrollDownEvent;
            mainScene.MouseScrollUpEvent += camCtrl.OnMouseScrollUpEvent;
            mainScene.MouseMoveEvent += camCtrl.OnMouseMoveEvent;
            mainScene.MouseLeftButtonDownEvent += camCtrl.OnMouseLeftButtonDownEvent;
            mainScene.MouseLeftButtonUpEvent += camCtrl.OnMouseLeftButtonUpEvent;
            mainScene.MouseRightButtonDownEvent += camCtrl.OnMouseRightButtonDownEvent;
            mainScene.MouseRightButtonUpEvent += camCtrl.OnMouseRightButtonUpEvent;

            var fac = mainScene.Facility;
            fac.ResourceDataStore = resourceDataStore;

            var dropDown = mainScene.DropDown;

            var ctlrPnl = mainScene.ControlPanel;

            var mainSceneCtrl = new MainSceneController(fac, ctlrPnl, dropDown, dataStore);
            fac.URRobotRemovedEvent += mainSceneCtrl.OnURRobotRemovedEvent;
            fac.URRobotSettedEvent += mainSceneCtrl.OnURRobotSettedEvent;
            dropDown.ItemSelectedEvent += mainSceneCtrl.OnURRobotDropDownSelectedEvent;

            mainSceneCtrl.Setup("UR5e");

            Destroy(gameObject);
        }

        private void Load(ResourceDataStore resourceDataStore)
        {
            ReadCsv("ResourceData/URRobot", (reader) =>
            {
                var row = new ResourceData.URRobot();
                row.URRobotID = reader.GetField("urRobotID");
                row.Path = reader.GetField("path");
                resourceDataStore.URRobots.Add(row);
            });
        }

        private void Load(DataStore dataStore)
        {
            LoadCameras(dataStore);
            LoadURRobots(dataStore);
            LoadURRobotJoints(dataStore);
        }

        private void LoadURRobotJoints(DataStore dataStore)
        {
            ReadCsv("Data/URRobotJoint", (reader) =>
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
            ReadCsv("Data/URRobot", (reader) =>
            {
                var row = new Core.Data.URRobot();
                row.ID = reader.GetField("id");
                row.Index = Convert.ToInt32(reader.GetField("index"));

                dataStore.URRobots.Add(row);
            });
        }

        private void LoadCameras(DataStore dataStore)
        {
            ReadCsv("Data/Camera", (reader) =>
            {
                var row = new Core.Data.Camera();
                row.RotateSpeed = Convert.ToSingle(reader.GetField("rotateSpeed"));
                row.MoveSpeed = Convert.ToSingle(reader.GetField("moveSpeed"));
                row.ZoomSpeed = Convert.ToSingle(reader.GetField("zoomSpeed"));

                dataStore.Cameras.Add(row);
            });
        }

        private void ReadCsv(string path, Action<CsvHelper.IReader> callback)
        {
            TextAsset csvFile = Resources.Load<TextAsset>(path);
            using var reader = new StringReader(csvFile.text);
            using var csvReader = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
            csvReader.Read();
            csvReader.ReadHeader();
            while (csvReader.Read())
                callback(csvReader);
        }
    }
}