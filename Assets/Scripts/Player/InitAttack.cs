using UnityEngine;
using UnityEngine.InputSystem;

public class InitAttack : MonoBehaviour
{
    [SerializeField]
    private AttackSystem _attackSystem;
    [SerializeField]
    private SpriteRenderer _player;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.8f;

    private float _attackTimer = 0.4f;
    private float _attackTimerSec = 0.4f;
    private bool _checkAttack = true;

    private void FixedUpdate()
    {
        if(!_checkAttack && !Pause._isPause)
        {
            if(_attackTimer <= 0f) {
                _attackTimer = _attackTimerSec;
                _checkAttack = true;
            } else
            {
                _attackTimer = _attackTimer - Time.fixedDeltaTime;
            }
        }
    }

    private string attackAnimation = "Attack";

    public void AttackAnim(InputAction.CallbackContext context)
    {
        if (_checkAttack && !Pause._isPause)
        {
            GameObject prefab = GetAttackType();
            Vector3 diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
            
            _checkAttack = false;
            Vector3 init = GetFlip() ? new Vector3(-0.3f, 0f) : new Vector3(0.3f, 0f);
            _animator.SetTrigger(attackAnimation);
            GameObject Pref = Instantiate(prefab, gameObject.transform.position + init, Quaternion.Euler(0f, 0f, rotateZ));
            audioSource.PlayOneShot(clip, volume);
        }
    }

    private GameObject GetAttackType()
    {
        return _attackSystem.GetAtackType();
    }

    private bool GetFlip()
    {
        return _player.flipX;
    }

}
