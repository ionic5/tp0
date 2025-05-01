using Portal301.TP0.Client.Core.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Portal301.TP0.Client.UnityWorld.View
{
    public class URRobot : MonoBehaviour, IURRobot
    {
        [SerializeField]
        public List<GameObject> joints;

        public float GetJointAngle(int jointIndex)
        {
            var joint = joints[jointIndex];
            return joint.transform.localEulerAngles.z;
        }

        public void SetJointAngle(int jointIndex, float angle)
        {
            var joint = joints[jointIndex];
            Vector3 currentRotation = joint.transform.localEulerAngles;
            joint.transform.localEulerAngles = new Vector3(currentRotation.x, currentRotation.y, angle);
        }
    }
}