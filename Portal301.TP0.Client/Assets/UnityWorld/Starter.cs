using Portal301.TP0.Client.Core;
using Portal301.TP0.Client.UnityWorld.View;
using System;
using System.Collections;
using System.Linq;
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

            Destroy(gameObject);
        }

        private void Load(ResourceDataStore resourceDataStore)
        {
            var row = new ResourceData.URRobot();
            row.URRobotID = "UR5e";
            row.Path = "URRobots/UR5e/UR5e";

            resourceDataStore.URRobots.Add(row);
        }

        private void Load(DataStore dataStore)
        {
            var row = new Core.Data.Camera();
            row.RotateSpeed = 0.03f;
            row.MoveSpeed = 0.03f;
            row.ZoomSpeed = 1000.0f;

            dataStore.Cameras.Add(row);
        }
    }
}