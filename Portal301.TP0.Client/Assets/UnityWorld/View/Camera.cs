using Portal301.TP0.Client.Core.View;
using UnityEngine;

namespace Portal301.TP0.Client.UnityWorld.View
{
    public class Camera : MonoBehaviour, ICamera
    {
        public System.Numerics.Vector2 GetPosition()
        {
            return new System.Numerics.Vector2(transform.position.x, transform.position.y);
        }

        public System.Numerics.Vector2 GetRotation()
        {
            return new System.Numerics.Vector2(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y);
        }

        public void SetPosition(System.Numerics.Vector2 vector2)
        {
            transform.position = new UnityEngine.Vector3(vector2.X, vector2.Y, transform.position.z);
        }

        public void SetRotation(System.Numerics.Vector2 vector2)
        {
            transform.rotation = UnityEngine.Quaternion.Euler(vector2.X, vector2.Y, transform.rotation.eulerAngles.z);
        }

        public void ZoomIn(float zoomSpeed)
        {
            transform.position += transform.forward * zoomSpeed * Time.deltaTime;
        }

        public void ZoomOut(float zoomSpeed)
        {
            transform.position -= transform.forward * zoomSpeed * Time.deltaTime;
        }
    }
}