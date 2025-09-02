using UnityEngine;

public class PatrollingState : IStateMachine
{
    private Enemy _enemy;
    private StateMachine _enemyStateMachine;

    public PatrollingState(Enemy enemy, StateMachine enemyStateMachine)
    {
        _enemy = enemy;
        _enemyStateMachine = enemyStateMachine;
    }

    public void Enter()
    {
        Debug.Log($"{_enemy.idName} entra en Patrolling");
    }

    public void UpdateState()
    {
        Debug.Log($"{_enemy.idName} está patrullando...");

        float distance = Vector3.Distance(_enemy.transform.position, _enemy.playerRef.transform.position);
        if (distance < 10f)
        {
            _enemyStateMachine.TransitionTo(_enemy.GetChasingState());
        }
    }

    public void Exit()
    {
        Debug.Log($"{_enemy.idName} deja de patrullar");
    }
}
