using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {
    private Ray ray;
    private RaycastHit click;

    private Light m_light1;
    private Light m_light2;
    private GameObject m_lightobj1;
    private GameObject m_lightobj2;

    private GameObject wheelobj;
    private Transform wheel;

    // Use this for initialization
    void Start () {
        wheelobj = GameObject.Find("Wheel");
        wheel = wheelobj.GetComponent<Transform>();

        m_lightobj1 = GameObject.Find("Light5a (1)");
        m_light1 = m_lightobj1.GetComponent<Light>();
        //m_lightmat1 = m_lightobj1.GetComponent<Material>();

        m_lightobj2 = GameObject.Find("Light5a (2)");
        m_light2 = m_lightobj2.GetComponent<Light>();
        //m_lightmat2 = m_lightobj2.GetComponent<Material>();

        //m_lightmat1.color = new Color(255f, 0f, 0f);
        //m_lightmat2.color = new Color(0f, 255f, 0f);

        m_light1.enabled = true;
        m_light1.color = Color.red;
        m_light2.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out click);
        if (click.collider.tag == "Handle" && Input.GetMouseButton(0))
        //if(Input.GetMouseButtonDown(0))
        {
            /*Debug.Log("hey");
            if (m_light.enabled == false)
            {
                m_light.enabled = true;
            }
            else
            {
                m_light.enabled = false;
            }*/
            wheel.Rotate(Vector3.up, 5f);
        }
        if (wheel.rotation == Quaternion.Euler(0, 180, 0))
        {
            Debug.Log("hey");
            if (m_light2.enabled == false)
            {
                m_light2.enabled = true;
                m_light2.color = Color.green;
            }
            else
            {
                m_light2.enabled = false;
            }
        }
        if (m_light2.enabled == true)
        {
            m_light1.enabled = false;
        }
    }
}
