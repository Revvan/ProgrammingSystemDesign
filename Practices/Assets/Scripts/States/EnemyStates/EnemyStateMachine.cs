public class EnemyStateMachine
{
    private IMachineState _currentState;
    public IMachineState currentState => _currentState;

    public void Initialize(IMachineState state)
    {
        _currentState = state;
        state.Enter();
    }

    public void TransitionTo(IMachineState state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    public void UpdateState()
    {
        _currentState.UpdateState();
    }
}