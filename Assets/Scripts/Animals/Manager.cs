using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject bird;
    public int numberOfBird = 50;
    public float xborder;
    public float yborder;
    void Start()
    {
        for (int i = 0; i < numberOfBird; i++)
        {
            float x = Random.Range(-30, 30);
            float y = Random.Range(-20, 20);
            GameObject b = Instantiate(bird, new Vector3(x,y,0),Quaternion.identity);
            bird.GetComponent<MOve>().initialVlocity = new Vector3(x,y,0);
            bird.GetComponent<MOve>().xBorder = xborder;
            bird.GetComponent<MOve>().yBorder = yborder;
        }
    }
}
