using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _health;

    [SerializeField]
    private bool _isPlayer;

    private GameObject _player;

    private string _playerTag = "Player";

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag(_playerTag);
    }

    public void takeDamage(int damage)
    {
        _health = _health - damage;

        if(_health <= 0)
        {
            if(!_isPlayer) {
                _player.GetComponent<Killing>().AddKilling();
            } else
            {
                SceneManager.LoadScene("fail");
            }

            Destroy(gameObject);
        }
            
    }

    public int GetHealth()
    {
        return _health;
    }
}
