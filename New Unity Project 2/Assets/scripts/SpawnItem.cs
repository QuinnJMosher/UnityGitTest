using UnityEngine;
using System.Collections;

public class SpawnItem : MonoBehaviour {

    public GameObject spawnedItem;
    public float x = 0;
    public float y = 0;
    public float maxCount = 0;
    float currentCount;

	// Use this for initialization
	void Start () {
        currentCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CallSpawnItem()
    {
        if (maxCount == 0 || currentCount < maxCount)
        {
            Instantiate(spawnedItem, new Vector3(x, y, 0), Quaternion.identity);
            currentCount++;
        }

    }
}
