using Portal301.TP0.Client.Core.View;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Portal301.TP0.Client.UnityWorld.View
{
    public class URRobot : MonoBehaviour, IURRobot
    {
        [SerializeField]
        public List<GameObject> joints;
        public List<float> angles;
        public List<Quaternion> initialRotations;

        public void Setup()
        {
            angles = Enumerable.Repeat(0.0f, joints.Count).ToList();
            initialRotations = joints.Select(joint => joint.transform.localRotation).ToList();
        }

        public float GetJointAngle(int jointIndex)
        {
            return angles[jointIndex];
        }

        public void SetJointAngle(int jointIndex, float angle)
        {
            angles[jointIndex] = angle;

            var joint = joints[jointIndex];
            var rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            joint.transform.localRotation = initialRotations[jointIndex] * rotation;
        }
    }
}