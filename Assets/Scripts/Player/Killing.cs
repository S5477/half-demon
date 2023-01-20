using UnityEngine;

public class Killing : MonoBehaviour
{
    private int _killing;

    private void Start()
    {
        _killing = 0; 
    }

    public int GetKilling()
    {
        return _killing;
    }

    public void AddKilling()
    {
       _killing += 1;
    }


}
