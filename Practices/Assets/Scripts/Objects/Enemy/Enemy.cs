using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected string _idName;
    public string idName => _idName;

    [SerializeField] protected float _maxHealth;
    public float maxHealth => _maxHealth;

    [SerializeField] protected float _damage;
    public float damage => _damage;

    [SerializeField] protected Player _playerRef;
    private float healthValue;
    private float damageValue;
    private Player player;

    public Player playerRef => _playerRef;

    public Enemy(string nameValue, float healthValue, float damageValue, Player player)
    {
        _idName = nameValue;
        _maxHealth = healthValue;
        _damage = damageValue;
        _playerRef = player;
    }

    protected Enemy(float healthValue, float damageValue, Player player)
    {
        this.healthValue = healthValue;
        this.damageValue = damageValue;
        this.player = player;
    }

    public abstract void Start();
    public abstract void Update();
    public abstract void FixedUpdate();
}
