using TMPro;
using UnityEngine;

public class KillingUI : MonoBehaviour
{
    [SerializeField]
    private Killing _killing;

    [SerializeField]
    private TextMeshProUGUI _text;

    private void FixedUpdate()
    {
        _text.SetText( "kill:" + _killing.GetKilling());
    }
}
