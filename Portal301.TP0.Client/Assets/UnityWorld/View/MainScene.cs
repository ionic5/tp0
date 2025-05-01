using Portal301.TP0.Client.Core.View;
using System;
using System.Collections;
using UnityEngine;

namespace Portal301.TP0.Client.UnityWorld.View
{
    public class MainScene : MonoBehaviour
    {
        public event EventHandler MouseScrollUpEvent;
        public event EventHandler<MouseMoveEventArgs> MouseMoveEvent;
        public event EventHandler<MouseButtonDownEventArgs> MouseLeftButtonDownEvent;
        public event EventHandler<MouseButtonDownEventArgs> MouseLeftButtonUpEvent;
        public event EventHandler<MouseButtonDownEventArgs> MouseRightButtonDownEvent;
        public event EventHandler<MouseButtonDownEventArgs> MouseRightButtonUpEvent;
        public event EventHandler MouseScrollDownEvent;

        [SerializeField]
        public Portal301.TP0.Client.UnityWorld.View.Camera Camera;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                MouseScrollUpEvent?.Invoke(this, EventArgs.Empty);
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                MouseScrollDownEvent?.Invoke(this, EventArgs.Empty);
            }

            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                Vector2 position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                MouseMoveEvent?.Invoke(this, new MouseMoveEventArgs(position.x, position.y));
            }

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                MouseLeftButtonDownEvent?.Invoke(this, new MouseButtonDownEventArgs(position.x, position.y));
            }

            if (Input.GetMouseButtonUp(0))
            {
                Vector2 position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                MouseLeftButtonUpEvent?.Invoke(this, new MouseButtonDownEventArgs(position.x, position.y));
            }

            if (Input.GetMouseButtonDown(1))
            {
                Vector2 position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                MouseRightButtonDownEvent?.Invoke(this, new MouseButtonDownEventArgs(position.x, position.y));
            }

            if (Input.GetMouseButtonUp(1))
            {
                Vector2 position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                MouseRightButtonUpEvent?.Invoke(this, new MouseButtonDownEventArgs(position.x, position.y));
            }
        }
    }
}