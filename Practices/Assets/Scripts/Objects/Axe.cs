using UnityEngine;

public class Axe : GameElements, IWeapons
{
    public int newDamage = 0;
    public Axe(int value) : base(value)
    {
        newDamage = value;
    }

    public override void Start()
    {
        _damage = newDamage;
    }

    public override void Update()
    {

    }

    public override void FixedUpdate()
    {

    }

    public void Attack()
    {
        print("Estas atacando con " + this.name + " infligiste " + damage.ToString());
    }
}
