using UnityEngine;

public class Sword : GameElements, IWeapons
{
    [SerializeField] private WeaponType _weaponType = WeaponType.MELEE;
    public WeaponType type => _weaponType;

    public int newDamage = 0;
    public Sword(int value) : base(value)
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
        print("You're attacking with: " + this.name + " You deal: " + damage.ToString());
    }
}
