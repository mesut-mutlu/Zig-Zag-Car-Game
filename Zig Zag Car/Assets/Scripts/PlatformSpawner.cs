using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    public Transform lastPlatform;
    Vector3 lastPosition;   //lasPos
    Vector3 newPosition;    //newPos

    public bool stop;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = lastPlatform.position;
        StartCoroutine(SpawnPlatforms());

    }//Start


    void GeneratePosition() //GenratePos
    {
        newPosition = lastPosition;
        int rand = Random.Range(0, 2);  // 0 1 
        if(rand > 0)    //yeni gelen küp 2birim x veya z yönünde öteye gelecek
        {
            newPosition.x += 2f;
        }
        else
        {
            newPosition.z += 2f;
        }
    }

    IEnumerator SpawnPlatforms()
    {
        while(!stop)
        {
            GeneratePosition();
            Instantiate(platform, newPosition, Quaternion.identity);
            lastPosition = newPosition;
            yield return new WaitForSeconds(0.2f);
        }
    }

}
