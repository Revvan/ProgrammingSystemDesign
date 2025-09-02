public interface IStateMachine
{
    void Enter();
    void UpdateState();
    void Exit();
}