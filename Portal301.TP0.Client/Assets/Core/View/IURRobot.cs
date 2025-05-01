
namespace Portal301.TP0.Client.Core.View
{
    public interface IURRobot
    {
        float GetJointAngle(int jointIndex);
        void SetJointAngle(int jointIndex, float angle);
    }
}