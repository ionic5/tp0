using Portal301.TP0.Client.Core.View;
using UnityEngine;

namespace Portal301.TP0.Client.UnityWorld.View
{
    public class Camera : MonoBehaviour, ICamera
    {
        [SerializeField]
        private UnityEngine.Camera targetCamera;

        public System.Numerics.Vector3 GetDirection()
        {
            var direction = targetCamera.transform.localRotation * Vector3.forward;
            return System.Numerics.Vector3.Normalize(new System.Numerics.Vector3(direction.x, direction.y, direction.z));
        }

        public System.Numerics.Vector3 GetPosition()
        {
            return new System.Numerics.Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

        public System.Numerics.Vector2 GetRotation()
        {
            return new System.Numerics.Vector2(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y);
        }

        public void SetPosition(System.Numerics.Vector3 position)
        {
            transform.position = new UnityEngine.Vector3(position.X, position.Y, position.Z);
        }

        public void SetRotation(System.Numerics.Vector2 vector2)
        {
            transform.rotation = UnityEngine.Quaternion.Euler(vector2.X, vector2.Y, transform.rotation.eulerAngles.z);
        }

        public void ZoomIn(float zoomSpeed)
        {
            targetCamera.fieldOfView -= zoomSpeed * Time.deltaTime;
            targetCamera.fieldOfView = Mathf.Clamp(targetCamera.fieldOfView, 10f, 100f);
        }

        public void ZoomOut(float zoomSpeed)
        {
            targetCamera.fieldOfView += zoomSpeed * Time.deltaTime;
            targetCamera.fieldOfView = Mathf.Clamp(targetCamera.fieldOfView, 10f, 100f);
        }
    }
}