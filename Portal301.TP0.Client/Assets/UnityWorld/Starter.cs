using Portal301.TP0.Client.Core;
using Portal301.TP0.Client.UnityWorld.View;
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

            var camCtrl = new CameraController(mainScene.Camera, dataStore.Cameras.FirstOrDefault());
            mainScene.MouseScrollDownEvent += camCtrl.OnMouseScrollDownEvent;
            mainScene.MouseScrollUpEvent += camCtrl.OnMouseScrollUpEvent;
            mainScene.MouseMoveEvent += camCtrl.OnMouseMoveEvent;
            mainScene.MouseLeftButtonDownEvent += camCtrl.OnMouseLeftButtonDownEvent;
            mainScene.MouseLeftButtonUpEvent += camCtrl.OnMouseLeftButtonUpEvent;
            mainScene.MouseRightButtonDownEvent += camCtrl.OnMouseRightButtonDownEvent;
            mainScene.MouseRightButtonUpEvent += camCtrl.OnMouseRightButtonUpEvent;

            Destroy(gameObject);
        }

        private static void Load(DataStore dataStore)
        {
            var cam = new Core.Data.Camera();
            cam.RotateSpeed = 0.03f;
            cam.MoveSpeed = 0.03f;
            cam.ZoomSpeed = 1000.0f;

            dataStore.Cameras.Add(cam);
        }
    }
}