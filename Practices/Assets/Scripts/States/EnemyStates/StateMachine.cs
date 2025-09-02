public class StateMachine
{
    private IStateMachine _currentState;
    public IStateMachine currentState => _currentState;

    public void Initialize(IStateMachine state)
    {
        _currentState = state;
        state.Enter();
    }

    public void TransitionTo(IStateMachine state)
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