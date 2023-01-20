using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private float timeRemaining = 3f;
    private float timeRemainingStart = 3f;

    [SerializeField]
    private GameObject[] _prefs;

    [SerializeField]
    private GameObject _player;

    // Update is called once per frame
    void Update()
    {
        if (!Pause._isPause)
        {
            if (timeRemaining > 0f)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                float Rand = Random.Range(1, 5);

                GameObject pref = _prefs[Random.Range(0, 3)];

                switch (Rand)
                {
                    case 1:
                        Instantiate(pref, new Vector3(_player.transform.position.x - Random.Range(3f, 8f), _player.transform.position.y - Random.Range(3f, 8f), 0), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(pref, new Vector3(_player.transform.position.x - Random.Range(-8f, -3f), _player.transform.position.y - Random.Range(3f, 8f), 0), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(pref, new Vector3(_player.transform.position.x - Random.Range(3f, 8f), _player.transform.position.y - Random.Range(-8f, -3f), 0), Quaternion.identity);
                        break;
                    case 4:
                        Instantiate(pref, new Vector3(_player.transform.position.x - Random.Range(-8f, -3f), _player.transform.position.y - Random.Range(-8f, -3f), 0), Quaternion.identity);
                        break;
                }

                timeRemaining = timeRemainingStart - (_player.GetComponent<Killing>().GetKilling() / 1000);
            }
        }
       
    }
}
