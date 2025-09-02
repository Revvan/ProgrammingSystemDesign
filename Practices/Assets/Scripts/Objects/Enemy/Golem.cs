using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : Enemy
{
    protected override void OnEnable()
    {
        base.OnEnable();
    }
    protected override void Awake()
    {
        base.Awake();
        _patrollingState = new PatrollingState(this, _enemyStateMachine);
        _chasingState = new ChasingState(this, _enemyStateMachine);
        _attackState = new AttackState(this, _enemyStateMachine);

        _enemyStateMachine.Initialize(_patrollingState);
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
