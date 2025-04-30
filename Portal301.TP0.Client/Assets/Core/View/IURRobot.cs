
namespace Portal301.TP0.Client.Core.View
{
    public interface IURRobot
    {
        void IncreaseJointDegree(int v);
        int GetJointDegree(int jointIndex);
        void DecreaseJointDegree(int v);
        void SetJointDegree(int degree);
        bool IsJointDegreeReachedMax(int jointIndex);
        bool IsJointDegreeReachedMin(int jointIndex);
    }
}