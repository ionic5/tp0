using Portal301.TP0.Client.Core.View;
using System;
using System.Numerics;

namespace Portal301.TP0.Client.Core
{
    public class CameraController
    {
        public readonly ICamera camera;
        public readonly CameraSetting cameraSetting;
        public bool isMouseLeftButtonPressed;
        public bool isMouseRightButtonPressed;
        public System.Numerics.Vector2 lastMousePosition;

        public CameraController(ICamera camera, CameraSetting cameraSetting)
        {
            this.camera = camera;
            this.cameraSetting = cameraSetting;
            isMouseLeftButtonPressed = false;
            isMouseRightButtonPressed = false;
            lastMousePosition = Vector2.Zero;
        }

        public void OnMouseScrollUpEvent(object sender, EventArgs args)
        {
            camera.ZoomIn(cameraSetting.ZoomSpeed);
        }

        public void OnMouseScrollDownEvent(object sender, EventArgs args)
        {
            camera.ZoomOut(cameraSetting.ZoomSpeed);
        }

        public void OnMouseMoveEvent(object sender, MouseMoveEventArgs args)
        {
            var delta = lastMousePosition - args.Position;


            if (isMouseLeftButtonPressed)
            {
                var currentPosition = camera.GetPosition();
                var direction = camera.GetDirection() * delta.Y + Vector3.Cross(Vector3.UnitY, camera.GetDirection()) * delta.X;
                var nextPosition = currentPosition + direction * cameraSetting.MoveSpeed;

                camera.SetPosition(new Vector3(nextPosition.X, currentPosition.Y, nextPosition.Z));
            }
            else if (isMouseRightButtonPressed)
                camera.SetRotation(camera.GetRotation() + new Vector2(delta.Y, delta.X) * cameraSetting.RotateSpeed);

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