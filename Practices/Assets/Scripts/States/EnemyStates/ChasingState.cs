using UnityEngine;

public class ChasingState : IMachineState
{
    private Enemy _enemy;
    private EnemyStateMachine _enemyStateMachine;

    public ChasingState(Enemy enemy, EnemyStateMachine enemyStateMachine)
    {
        _enemy = enemy;
        _enemyStateMachine = enemyStateMachine;
    }


    public void Enter()
    {
        Debug.Log($"{_enemy.idName} entra en Chasing");
    }

    public void UpdateState()
    {
        Debug.Log($"{_enemy.idName} persigue al jugador...");
        float speed = 3f;
        float distance = Vector3.Distance(_enemy.transform.position, _enemy.playerRef.transform.position);

        Vector3 direction = (_enemy.playerRef.transform.position - _enemy.transform.position).normalized * speed * Time.deltaTime;

        _enemy.transform.Translate(direction.x, 0, direction.z);

        if (distance <= 2f)
        {
            _enemyStateMachine.TransitionTo(_enemy.GetAttackState());
        }
        else if (distance > 15f)
        {
            _enemyStateMachine.TransitionTo(_enemy.GetPatrollingState());
        }
    }

    public void Exit()
    {
        Debug.Log($"{_enemy.idName} deja de perseguir");
    }
}