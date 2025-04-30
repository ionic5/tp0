using System.Numerics;

namespace Portal301.TP0.Client.Core.View
{
    public interface ICamera
    {
        Vector2 GetPosition();
        Vector2 GetRotation();
        void SetPosition(Vector2 vector2);
        void SetRotation(Vector2 vector2);
        void ZoomIn(float zoomSpeed);
        void ZoomOut(float zoomSpeed);
    }
}
