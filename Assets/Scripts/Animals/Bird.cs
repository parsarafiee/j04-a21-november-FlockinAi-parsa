using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D rb;
    public float timeToLerp = 1;
    List<GameObject> otherBirdsAround = new List<GameObject>(); 
    public Vector3 velocity;

    public float seprationArea=1;
    public float seprationAreaSPeed=3;
     Collider2D[] repulsionArea;

    public float alignmentAree;
     Collider2D[] orientationArea;


    public float cohesionArea=4;
    public float cohesionSpeed;
     Collider2D[] attractionnArea;

    bool timerWork;
    float timer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
        if (timerWork)
        {
        timer += Time.deltaTime;

        }

        if (!timerWork)
        {
            timer = 0;
        }
        if (this.transform.position.x > 18f)
        {
            transform.position = new Vector3(-18f,transform.position.y,0) ;
        }
        if (this.transform.position.x < -18f)
        {
            transform.position = new Vector3(18f, transform.position.y, 0);
        }
        if (this.transform.position.y > 10f)
        {
            transform.position = new Vector3(transform.position.x, -10f, 0);
        }
        if (this.transform.position.y <  -10f)
        {
            transform.position = new Vector3(transform.position.x, 10f, 0);
        }
        
        repulsionArea = Physics2D.OverlapCircleAll(transform.position, seprationArea);
        orientationArea = Physics2D.OverlapCircleAll(transform.position, alignmentAree);
        attractionnArea = Physics2D.OverlapCircleAll(transform.position, cohesionArea);


        Vector3 attra = velocity ;
        if (attractionnArea.Length>=1)
        {
            attra = ReGroup();
        }
        //if (repulsionArea.Length >= 1)
        //{
        //    VlocityIsChanged();
        //    AvoidingCoseBird();
        //}


        velocity = Vector3.Lerp(rb.velocity, attra, timer);



        velocity.z = 0;
        rb.velocity = velocity ; 
    }

    //void FindDirection()
    //{
    //    return Vector3.zero;
    //}

    //public float FindVlocity()
    //{
    //    return 0;
    //}

    public Vector3 ReGroup()
    {
        if (timerWork)
        {

        }
        timerWork = true;
        Vector3 center =Vector3.zero;
        for (int i = 0; i < attractionnArea.Length; i++)
        {
            center += attractionnArea[i].gameObject.transform.position;
        }

        return cohesionSpeed * ((center/ attractionnArea.Length) - transform.position).normalized;

    }

    //public void AvoidingCoseBird()
    //{
    //    Vector3 repulsion = Vector3.zero;
    //    for (int i = 0; i < repulsionArea.Length; i++)
    //    {
    //    }

        

    //}


    void VlocityIsChanged()
    {
        timer = 0;
    }
}
