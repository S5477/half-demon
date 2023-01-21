using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AttackSystem : MonoBehaviour
{

    private AtackEnum _atackEnum = AtackEnum.Water;

    [SerializeField]
    private Sprite[] _sprites;
    [SerializeField]
    private Sprite[] _spritesEnemy;

    [SerializeField]
    private Image _image;
    [SerializeField]
    private Image _imageEnemy;

    [SerializeField]
    private GameObject[] _prefabs;

    private GameObject _attack;

    public AtackEnum GetAtackEnum()
    {
        return _atackEnum;
    }

    public GameObject GetAtackType()
    {
        switch (_atackEnum)
        {
            case AtackEnum.Water:
                _attack = _prefabs[0];
                break;
            case AtackEnum.Fair:
                _attack = _prefabs[1];
                break;
            case AtackEnum.Terra:
                _attack = _prefabs[2];
                break;
        }

        return _attack;
    }

    public void SetAtack(InputAction.CallbackContext context)
    {
        if (!Pause._isPause)
        {
            string key = context.action.activeControl.name;

            switch (key)
            {
                case "1":
                    _atackEnum = AtackEnum.Water;
                    _image.sprite = _sprites[0];
                    _imageEnemy.sprite = _spritesEnemy[0];
                    break;
                case "2":
                    _atackEnum = AtackEnum.Fair;
                    _image.sprite = _sprites[1];
                    _imageEnemy.sprite = _spritesEnemy[1];
                    break;
                case "3":
                    _atackEnum = AtackEnum.Terra;
                    _image.sprite = _sprites[2];
                    _imageEnemy.sprite = _spritesEnemy[2];
                    break;
                default:
                    break;

            }
        }
    }
}
