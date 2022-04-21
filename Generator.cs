using UnityEngine;

public class Generator : MonoBehaviour
{
    public Object generatingObject;
    public int length = 75;

    void Start()
    {
        for (int i = 0; i < length; i++)
        {
            AddBottle();
        }
    }

    public void AddBottle()
    {
        Instantiate(generatingObject, new Vector3(Random.Range(175, -175), 0, Random.Range(175, -175)), Quaternion.identity);
    }
}