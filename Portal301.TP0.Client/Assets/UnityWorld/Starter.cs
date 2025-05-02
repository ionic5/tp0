using Portal301.TP0.Client.Core;
using Portal301.TP0.Client.Core.Data;
using Portal301.TP0.Client.UnityWorld.View;
using System.Linq;
using UnityEngine;

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

            var defaultURRobotID = dataStore.Constants.Where(item => item.ID == ConstantID.DefaultURRobotID).Select(item => item.Value).First();

            mainSceneCtrl.Setup(defaultURRobotID);

            Destroy(gameObject);
        }
    }
}