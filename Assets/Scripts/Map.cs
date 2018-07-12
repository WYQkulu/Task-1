using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map: MonoBehaviour {
    private Ray ray;
    private RaycastHit click;

    private Light m_light1;
    private Light m_light2;
    private GameObject m_lightobj1;
    private GameObject m_lightobj2;

    private GameObject ball;
    private Transform ballTransform;
    private Vector3 dis;
  
    // Use this for initialization
    void Start () {
        m_lightobj1 = GameObject.Find("Light5a (1)");
        m_light1 = m_lightobj1.GetComponent<Light>();
        //m_lightmat1 = m_lightobj1.GetComponent<Material>();

        m_lightobj2 = GameObject.Find("Light5a (2)");
        m_light2 = m_lightobj2.GetComponent<Light>();
        //m_lightmat2 = m_lightobj2.GetComponent<Material>();

        //m_lightmat1.color = new Color(255f, 0f, 0f);
        //m_lightmat2.color = new Color(0f, 255f, 0f);
        
        m_light1.enabled = true ;
        m_light1.color = Color.red;
        m_light2.enabled = false;

        ball = GameObject.Find("Ball");
        ballTransform = ball.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out click);
        //Vector3 dis = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(10, 0, 10));
        if (click.collider.tag == "Ball" && Input.GetMouseButton(0))
        {
            dis = new Vector3(click.point.x,2.095f,click.point.z);
            ballTransform.position = dis;
        }
        if (m_light2.enabled == true)
        {
            m_light1.enabled = false;
        }
    }
    void OnTriggerStay(Collider collider )
    {
        if (collider.gameObject.name == "Ball")
        {
            //Debug.Log("!!!");
            m_light1.enabled = false;
            m_light2.enabled = true;
            m_light2.color = Color.green;
        }
    }
}
