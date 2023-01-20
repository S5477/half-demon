using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]
    private int _damage;

    public int getDamage()
    {
        return _damage;
    }
}
