using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject _menu;
    [SerializeField]
    private GameObject _ui;

    public static bool _isPause;
    private void Awake()
    {
        _isPause = false;
        _menu.SetActive(_isPause);
        _ui.SetActive(!_isPause);
    }

    public void GamePause(InputAction.CallbackContext context)
    {
        _isPause = !_isPause;
        _menu.SetActive(_isPause);
        _ui.SetActive(!_isPause);
    }
}
