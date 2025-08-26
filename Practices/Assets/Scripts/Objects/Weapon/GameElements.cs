using UnityEngine;

public abstract class GameElements : MonoBehaviour
{
    protected int _damage;
    public int damage
    {
        get { return _damage; }
    }

    public GameElements(int value)
    {
        _damage = value;
    }

    public abstract void Start();
    public abstract void Update();
    public abstract void FixedUpdate();
}