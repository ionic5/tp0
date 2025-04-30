using Portal301.TP0.Client.Core.View;
using System;

namespace Portal301.TP0.Client.Core
{
    public class Controller
    {
        public readonly ISpace space;

        public readonly ICamera camera;
        public bool isMouseLeftButtonPressed;
        public bool isMouseRightButtonPressed;
        public System.Numerics.Vector2 lastMousePosition;
        public float zoomSpeed;
        public readonly IControlPanel controlPanel;

        public void OnURRobotDropDownSelectedEvent(object sender, DropDownItemSelectedEventArgs args)
        {
            var index = args.ItemIndex;
            string robotID = "";
            space.SetRobot(robotID);
        }

        public void OnURRobotRemovedEvent(object sender, EventArgs args)
        {
            controlPanel.ClearJointPanels();
        }

        public void OnURRobotSettedEvent(object sender, EventArgs args)
        {
            var jointCount = 6;
            for (var jointIndex = 0; jointIndex < jointCount; jointIndex++)
            {
                var panel = controlPanel.AddJointPanel();
                var urRobot = space.GetURRobot();

                var controller = new SetJointPanelController(jointIndex, panel, urRobot);
                panel.MinusButtonClickedEvent += controller.OnMinusButtonClickedEvent;
                panel.PlusButtonClickedEvent += controller.OnPlusButtonClickedEvent;
                panel.DegreeSettedEvent += controller.OnDegreeSettedEvent;
            }
        }

        public void OnMouseScrollUpEvent(object sender, EventArgs args)
        {
            camera.ZoomIn(zoomSpeed);
        }

        public void OnMouseScrollDownEvent(object sender, EventArgs args)
        {
            camera.ZoomOut(zoomSpeed);
        }

        public void OnMouseMoveEvent(object sender, MouseMoveEventArgs args)
        {
            var delta = lastMousePosition - args.Position;
            if (isMouseLeftButtonPressed)
            {
                var moveSpeed = 10.0f;
                camera.SetPosition(camera.GetPosition() + delta * moveSpeed);
            }
            else if (isMouseRightButtonPressed)
            {
                var rotateSpeed = 10.0f;
                camera.SetRotation(camera.GetRotation() + delta * rotateSpeed);
            }

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