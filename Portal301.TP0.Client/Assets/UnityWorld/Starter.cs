using Portal301.TP0.Client.Core;
using Portal301.TP0.Client.Core.Data;
using Portal301.TP0.Client.UnityWorld.View;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Portal301.TP0.Client.UnityWorld
{
    public class Starter : MonoBehaviour
    {
        [SerializeField]
        private MainScene mainScene;
        [SerializeField]
        private DataStoreLoader dataStoreLoader;
        [SerializeField]
        private ResourceDataStoreLoader resourceDataStoreLoader;

        // Use this for initialization
        void Start()
        {
            var readCsvActn = new ReadCsvAction();

            dataStoreLoader.ReadCsvAction = readCsvActn;

            resourceDataStoreLoader.ReadCsvAction = readCsvActn;

            var dataStore = new DataStore();
            dataStoreLoader.Load(dataStore);

            var resourceDataStore = new ResourceDataStore();
            resourceDataStoreLoader.Load(resourceDataStore);

            var cam = mainScene.Camera;

            var camSetting = new CameraSetting();
            camSetting.ZoomSpeed = cam.ZoomSpeed;
            camSetting.MoveSpeed = cam.MoveSpeed;
            camSetting.RotateSpeed = cam.RotateSpeed;

            var camCtrl = new CameraController(cam, camSetting);
            mainScene.MouseScrollDownEvent += camCtrl.OnMouseScrollDownEvent;
            mainScene.MouseScrollUpEvent += camCtrl.OnMouseScrollUpEvent;
            mainScene.MouseMoveEvent += camCtrl.OnMouseMoveEvent;
            mainScene.MouseLeftButtonDownEvent += camCtrl.OnMouseLeftButtonDownEvent;
            mainScene.MouseLeftButtonUpEvent += camCtrl.OnMouseLeftButtonUpEvent;
            mainScene.MouseRightButtonDownEvent += camCtrl.OnMouseRightButtonDownEvent;
            mainScene.MouseRightButtonUpEvent += camCtrl.OnMouseRightButtonUpEvent;

            var fac = mainScene.Facility;
            fac.ResourceDataStore = resourceDataStore;

            var doc = mainScene.UIDocument;
            var ctrlPanelElem = doc.rootVisualElement.Q("ControlPanel");

            var dropDown = new DropDown(ctrlPanelElem.Q("Row0").Q("URRobotDropDown"));

            var jointPanels = new List<JointPanel>();
            foreach (var item in ctrlPanelElem.Q("Row1").Query("JointPanel").ToList())
                jointPanels.Add(new JointPanel(item));
            var ctrlPanel = new ControlPanel(jointPanels);

            var mainSceneCtrl = new MainSceneController(fac, ctrlPanel, dropDown, dataStore);
            fac.URRobotRemovedEvent += mainSceneCtrl.OnURRobotRemovedEvent;
            fac.URRobotSettedEvent += mainSceneCtrl.OnURRobotSettedEvent;
            dropDown.ItemSelectedEvent += mainSceneCtrl.OnURRobotDropDownSelectedEvent;

            var defaultURRobotID = dataStore.Constants.Where(item => item.ID == ConstantID.DefaultURRobotID).Select(item => item.Value).First();

            mainSceneCtrl.Setup(defaultURRobotID);

            Destroy(gameObject);
        }
    }
}