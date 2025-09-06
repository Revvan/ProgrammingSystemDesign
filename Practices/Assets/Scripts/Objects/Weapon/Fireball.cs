using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Fireball : MonoBehaviour
{
    public ObjectPool<Fireball> _pool;
    public float speed = 0f;

    private void OnEnable()
    {
        Invoke("DeactiveObject", 5f);
    }

    private void Update()
    {
        transform.Translate(1f * speed * Time.deltaTime, 0f, 1f * speed * Time.deltaTime);
    }
    private void DeactiveObject()
    {
        _pool.Release(this);
    }
}
