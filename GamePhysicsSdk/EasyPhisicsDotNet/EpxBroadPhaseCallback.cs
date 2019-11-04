namespace EasyPhisicsDotNet
{
    public interface IEpxBroadPhaseCallback
    {
        bool Execute(int rigidBodyIndexA, int rigidBodyIndexB);
    }
}
