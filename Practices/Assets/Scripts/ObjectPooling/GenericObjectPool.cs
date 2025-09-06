using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class GenericObjectPool : MonoBehaviour
{
    private ObjectPool<Fireball> _pool;
    [SerializeField] private Transform _poolContainer;
    [SerializeField] private Fireball _fireBallObject;

    private void Awake()
    {
        _pool = new ObjectPool<Fireball>(Create, OnGetObject, OnReleaseObject, OnDestroyObject, false, 10, 10000);
    }

    public Fireball Create()
    {
        Fireball fireball = Instantiate(_fireBallObject, _poolContainer);
        fireball.gameObject.SetActive(false);
        fireball._pool = _pool;
        return fireball;
    }

    public void OnGetObject(Fireball fireball)
    {
        fireball.gameObject.SetActive(true);
    }

    public void OnReleaseObject(Fireball fireball)
    {
        fireball.gameObject.SetActive(false);
    }
    private void OnDestroyObject(Fireball fireball)
    {
        Destroy(fireball.gameObject);
    }
}