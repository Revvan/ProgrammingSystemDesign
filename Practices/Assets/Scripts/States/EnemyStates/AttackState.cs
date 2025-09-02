using UnityEngine;

public class AttackState : IStateMachine
{
    private Enemy _enemy;
    private StateMachine _enemyStateMachine;

    public AttackState(Enemy enemy, StateMachine enemyStateMachine)
    {
        _enemy = enemy;
        _enemyStateMachine = enemyStateMachine;
    }

    public void Enter()
    {
        Debug.Log($"{_enemy.idName} entra en Attack");
    }

    public void UpdateState()
    {
        Debug.Log($"{_enemy.idName} ataca al jugador causando {_enemy.damage} de daño.");

        float distance = Vector3.Distance(_enemy.transform.position, _enemy.playerRef.transform.position);
        if (distance > 2f)
        {
            _enemyStateMachine.TransitionTo(_enemy.GetChasingState());
        }
    }

    public void Exit()
    {
        Debug.Log($"{_enemy.idName} deja de atacar");
    }
}
