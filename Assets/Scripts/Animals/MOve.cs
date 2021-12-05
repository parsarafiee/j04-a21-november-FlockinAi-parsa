using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOve : MonoBehaviour
{
    Rigidbody2D m_Rigidbody2;

    public float cohesionArea = 10;
    Collider2D[] attractionnArea;

    Vector3 target;
    public Vector3 initialVlocity;


    public float alignmentArea = 5;
    Collider2D[] orientationArea;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2 = gameObject.GetComponent<Rigidbody2D>();
        m_Rigidbody2.velocity = initialVlocity;

        float angle = Mathf.Atan2(initialVlocity.y, initialVlocity.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (this.transform.position.x > 18f)
        {
            transform.position = new Vector3(-18f, transform.position.y, 0);
        }
        if (this.transform.position.x < -18f)
        {
            transform.position = new Vector3(18f, transform.position.y, 0);
        }
        if (this.transform.position.y > 10f)
        {
            transform.position = new Vector3(transform.position.x, -10f, 0);
        }
        if (this.transform.position.y < -10f)
        {
            transform.position = new Vector3(transform.position.x, 10f, 0);
        }
        attractionnArea = Physics2D.OverlapCircleAll(transform.position, cohesionArea);
        orientationArea = Physics2D.OverlapCircleAll(transform.position, alignmentArea);
        // set the destination
        if (attractionnArea.Length>=1)
        {
            GetDestination();
        }


        if (orientationArea.Length>=1)
        {
            SetOrientation();
        }

        float angle = Mathf.Atan2(m_Rigidbody2.velocity.y, m_Rigidbody2.velocity.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


    }

    private void SetOrientation()
    {
        Vector2 vlo = Vector2.zero;
        for (int i = 0; i < orientationArea.Length; i++)
        {
            vlo += orientationArea[i].GetComponent<Rigidbody2D>().velocity;
        }
        m_Rigidbody2.velocity = vlo / orientationArea.Length;

    }

    void GetDestination()
    {
        Vector3 pos =Vector3.zero;
        for (int i = 0; i < attractionnArea.Length; i++)
        {
            pos += attractionnArea[i].transform.position;
            Debug.Log(attractionnArea[i].name);
        }
                target = pos/ attractionnArea.Length;
        if (Vector3.Distance(this.transform.position, target) > alignmentArea)
        {
            Vector3 desireVector = (target - transform.position);
            Vector3 birdVlocity = (m_Rigidbody2.velocity);


            m_Rigidbody2.velocity = Vector2.Lerp(birdVlocity, desireVector, timer / 10);

        }
        else
            timer = 0;
    }


}
