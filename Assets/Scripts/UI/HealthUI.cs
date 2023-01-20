using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField]
    private Health _health;

    [SerializeField]
    private TextMeshProUGUI _text;

    private void FixedUpdate()
    {
        _text.SetText("+ " + _health.GetHealth());
    }
}
