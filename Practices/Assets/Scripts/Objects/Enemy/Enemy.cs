using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected string _idName;
    public string idName => _idName;

    [SerializeField] protected float _maxHealth;
    public float maxHealth => _maxHealth;

    [SerializeField] protected float _damage;
    public float damage => _damage;

    [SerializeField] protected Player _playerRef;
    public Player playerRef => _playerRef;


    protected StateMachine _enemyStateMachine;

    protected PatrollingState _patrollingState;
    protected ChasingState _chasingState;
    protected AttackState _attackState;

    protected virtual void OnEnable()
    {
        Initialize();
    }
    protected virtual void Awake()
    { 
        _enemyStateMachine = new StateMachine();
    }
    protected virtual void Start()
    {
        
    }
    protected virtual void Update()
    {
        _enemyStateMachine.UpdateState();
    }
    protected virtual void FixedUpdate()
    {

    }

    protected virtual void Initialize()
    {
        _playerRef = FindObjectOfType<Player>();
    }

    public IStateMachine GetPatrollingState() => _patrollingState;
    public IStateMachine GetChasingState() => _chasingState;
    public IStateMachine GetAttackState() => _attackState;
}
