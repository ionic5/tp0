using Portal301.TP0.Client.Core.View;
using System;
using System.Numerics;

namespace Portal301.TP0.Client.Core
{
    public class CameraController
    {
        public readonly ICamera camera;
        public readonly Data.Camera cameraData;
        public bool isMouseLeftButtonPressed;
        public bool isMouseRightButtonPressed;
        public System.Numerics.Vector2 lastMousePosition;

        public CameraController(ICamera camera, Data.Camera cameraData)
        {
            this.camera = camera;
            this.cameraData = cameraData;
            isMouseLeftButtonPressed = false;
            isMouseRightButtonPressed = false;
            lastMousePosition = Vector2.Zero;
        }

        public void OnMouseScrollUpEvent(object sender, EventArgs args)
        {
            camera.ZoomIn(cameraData.ZoomSpeed);
        }

        public void OnMouseScrollDownEvent(object sender, EventArgs args)
        {
            camera.ZoomOut(cameraData.ZoomSpeed);
        }

        public void OnMouseMoveEvent(object sender, MouseMoveEventArgs args)
        {
            var delta = lastMousePosition - args.Position;

            if (isMouseLeftButtonPressed)
                camera.SetPosition(camera.GetPosition() + delta * cameraData.MoveSpeed);
            else if (isMouseRightButtonPressed)
                camera.SetRotation(camera.GetRotation() + delta * cameraData.RotateSpeed);

            lastMousePosition = args.Position;
        }

        public void OnMouseLeftButtonDownEvent(object sender, MouseButtonDownEventArgs args)
        {
            if (isMouseRightButtonPressed)
                return;

            isMouseLeftButtonPressed = true;
            lastMousePosition = args.Position;
        }

        public void OnMouseLeftButtonUpEvent(object sender, MouseButtonDownEventArgs args)
        {
            isMouseLeftButtonPressed = false;
        }

        public void OnMouseRightButtonDownEvent(object sender, MouseButtonDownEventArgs args)
        {
            if (isMouseLeftButtonPressed)
                return;

            isMouseRightButtonPressed = true;
            lastMousePosition = args.Position;
        }

        public void OnMouseRightButtonUpEvent(object sender, MouseButtonDownEventArgs args)
        {
            isMouseRightButtonPressed = false;
        }
    }

}