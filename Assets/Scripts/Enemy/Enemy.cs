using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private GameObject _player;

    private NavMeshAgent _agent;

    private int playerLayer = 6;

    [SerializeField]
    private AtackEnum _attackType;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        gameObject.AddComponent<NavMeshAgent>();
        _agent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            collision.gameObject.GetComponent<Health>().takeDamage(gameObject.GetComponent<Damage>().getDamage());
        }
    }

    private void FixedUpdate()
    {
        _agent.destination = _player.transform.position;

    }

    public AtackEnum GetAttackType()
    {
        return _attackType;
    }
}
