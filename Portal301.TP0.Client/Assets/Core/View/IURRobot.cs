
namespace Portal301.TP0.Client.Core.View
{
    public interface IURRobot
    {
        void IncreaseJointAngle(int v);
        int GetJointAngle(int jointIndex);
        void DecreaseJointAngle(int v);
        void SetJointAngle(int angle);
        bool IsJointAngleReachedMax(int jointIndex);
        bool IsJointAngleReachedMin(int jointIndex);
    }
}