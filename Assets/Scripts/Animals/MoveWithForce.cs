//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MoveWithForce : MonoBehaviour
//{
//    Rigidbody2D rb;
//    public float timeToLerp = 1;
//    List<GameObject> otherBirdsAround = new List<GameObject>();

//    public float speed = 10;
//    Vector2 velocity;


//    public float alignmentArea;
//    Collider2D[] orientationArea;

//    [Header("CohesionInfo")]
//    public float cohesionArea = 4;
//    public float cohesionForce = 10;
//    Collider2D[] attractionnArea;

//    [Header("SeprationInfo")]
//    public float seprationArea = 2;
//    public float seprationAreaForce = 20;
//    Collider2D[] repulsionArea;

//    private void Start()
//    {
//        velocity = transform.rotation * Vector3.right * speed;

//        rb = GetComponent<Rigidbody2D>();
//    }
//    void Update()
//    {

//        if (this.transform.position.x > 18f)
//        {
//            transform.position = new Vector3(-18f, transform.position.y, 0);
//        }
//        if (this.transform.position.x < -18f)
//        {
//            transform.position = new Vector3(18f, transform.position.y, 0);
//        }
//        if (this.transform.position.y > 10f)
//        {
//            transform.position = new Vector3(transform.position.x, -10f, 0);
//        }
//        if (this.transform.position.y < -10f)
//        {
//            transform.position = new Vector3(transform.position.x, 10f, 0);
//        }
//        orientationArea = Physics2D.OverlapCircleAll(transform.position, alignmentArea);

//        attractionnArea = Physics2D.OverlapCircleAll(transform.position, cohesionArea);

//        repulsionArea = Physics2D.OverlapCircleAll(transform.position, seprationArea);


//        if (attractionnArea.Length >= 2)
//        {
//            ReGroup();
//        }

//        if (repulsionArea.Length >= 2)
//        {
//            Repulsion();
//        }
//        rb.velocity = velocity;

//        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

//        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


//    }

//    public void Repulsion()
//    {
//        Vector3 center = Vector3.zero;
//        for (int i = 0; i < repulsionArea.Length; i++)
//        {
//            Vector3 repulsionForce = seprationAreaForce * (repulsionArea[i].gameObject.transform.position - transform.position).normalized;
//            repulsionArea[i].gameObject.GetComponent<Rigidbody2D>().AddForce(repulsionForce);
//        }
//    }
//    public void ReGroup()
//    {
//        Vector3 center = Vector3.zero;
//        for (int i = 0; i < attractionnArea.Length; i++)
//        {
//            center += attractionnArea[i].gameObject.transform.position;
//        }
//        velocity = (cohesionForce * ((center / attractionnArea.Length) - transform.position).normalized);
//        if (orientationArea.Length >= 1)
//        {
//            GetTheVlocity();
//        }

//    }
//    public void GetTheVlocity()
//    {
//        Vector2 vlocity2 = Vector3.zero;
//        for (int i = 0; i < orientationArea.Length; i++)
//        {
//            vlocity2 += orientationArea[i].gameObject.GetComponent<Bird>().velocity;

//        }
//        velocity = vlocity2 / orientationArea.Length;
//    }
//}
