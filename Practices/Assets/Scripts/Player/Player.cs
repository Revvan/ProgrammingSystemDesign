using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    private IWeapons weapon;
    private IWeapons previousWeapon;

    private Rigidbody rb;
    private Transform t;

    [SerializeField] private float _speed = 0f;
    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
    }

    private void Update()
    {
        InputManager();
    }

    private void FixedUpdate()
    {
        float horizontalMov = Input.GetAxis("Horizontal");
        float verticalMov = Input.GetAxis("Vertical");

        Vector3 pos = new Vector3(horizontalMov, 0, verticalMov) * speed * Time.deltaTime;

        t.Translate(pos.x, pos.y, pos.z);
    }

    private void InputManager()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Manager_Scenes.Instance.ChangeActiveScene();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            Manager_Game.Instance.IncreaseScore(1);
            Manager_Game.Instance.CheckWin();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (weapon != null)
                weapon.Attack();
        }
    }

    private void ChangeWeapon(IWeapons weapon)
    {
        this.weapon = weapon;
    }

    private void OnCollisionEnter(Collision collision)
    {
        weapon = collision.gameObject.GetComponent<IWeapons>();

        if (weapon != null)
        {
            if (weapon == previousWeapon)
            {
                print("You already have this weapon" + weapon.ToString());
            }
            else
            {
                previousWeapon = weapon;
                ChangeWeapon(weapon);
                
                print("Arma" + weapon.ToString());
            }          
        }   
    }
}
