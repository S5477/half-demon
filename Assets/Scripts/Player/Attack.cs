using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private float _speed = 2f;

    private Vector2 _direction;

    private Rigidbody2D _rb;

    private int enemyLayer = 3;

    [SerializeField]
    private AtackEnum _attackType;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == enemyLayer)
        {
            if (col.gameObject.GetComponent<Enemy>().GetAttackType() == _attackType)
            {
                col.gameObject.GetComponent<Health>().takeDamage(gameObject.GetComponent<Damage>().getDamage());
            }

            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        float angle = gameObject.transform.rotation.eulerAngles.magnitude * Mathf.Deg2Rad;
        _direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        float timer = 0f;

        switch (_attackType)
        {
            case AtackEnum.Water:
                timer = 2f;
                break;
            case AtackEnum.Fair:
                timer = 3f;
                break;
            case AtackEnum.Terra:
                timer = 1f;

                break;
            default:
                break;
        }
        Destroy(gameObject, timer);
    }

    // Update is called once per frame
    void Update()
    {
        _rb.MovePosition(_rb.position + _direction * Time.fixedDeltaTime * _speed);
    }

}
