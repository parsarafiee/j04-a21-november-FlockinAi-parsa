using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D m_Rigidbody2;

    Collider2D[] orientationArea;

    Vector3 target;
    public float alignmentArea;
    public Vector3 initialVlocity;

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
        //orientationArea = Physics2D.OverlapCircleAll(transform.position, alignmentArea);
        //// set the destination
        //GetDestination();

        m_Rigidbody2.velocity = initialVlocity;

        float angle = Mathf.Atan2(initialVlocity.y, initialVlocity.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void GetDestination()
    {
        for (int i = 0; i < orientationArea.Length; i++)
        {
            if (orientationArea[i].name == "Circle")
            {
                target = orientationArea[i].gameObject.transform.position;
            }
        }

        Vector3 desireVector = (target - transform.position);
        Vector3 birdVlocity = (m_Rigidbody2.velocity);


        m_Rigidbody2.velocity = Vector3.Lerp(birdVlocity, desireVector, timer / 10);


        float angle = Mathf.Atan2(m_Rigidbody2.velocity.y, m_Rigidbody2.velocity.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
