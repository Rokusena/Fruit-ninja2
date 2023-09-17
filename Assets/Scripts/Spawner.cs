using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public List<GameObject> fruitPrefabs;
    public AudioSource audio;

    public int maxfruits = 5;
    public float spawnRate = 2;
    public float timeBeteweemwawes = 5;
    public float minWaitTime = 1;
    public float maxWaitTime = 5;

    Vector2 screenBounds;
    
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(wawetest());
        
        }
    

IEnumerator wawetest()
{
    while (true)
    {
        yield return new WaitForSeconds(timeBeteweemwawes);

            StartCoroutine(wawe());

    }

}   


IEnumerator wawe()
    {
        var count = Random.Range(1, maxfruits);

        for (int i = 0; i < count; i++)
        {
            TossRandomFruit();
            audio.Play();

            var waitTime = Random.Range(0, 1 / spawnRate);

            yield return new WaitForSeconds(waitTime);
        }
    }

    void TossRandomFruit()
    {
        var tosDirection = Vector3.up * 10 + Vector3.right * Random.Range(-7, 7);

        var fruitPrefab = fruitPrefabs[Random.Range(0, fruitPrefabs.Count)];

        var positon = new Vector3();
        positon.x = Random.Range(-screenBounds.x / 3 * 2, screenBounds.x / 3 * 2);
        positon.y = Random.Range(-screenBounds.y / 3 * 2, screenBounds.y / 3 * 2);



        var fruit = Instantiate(fruitPrefab, positon, Quaternion.identity);
        fruit.GetComponent<Rigidbody>().AddForce(tosDirection, ForceMode.Impulse);
    }
        
}
