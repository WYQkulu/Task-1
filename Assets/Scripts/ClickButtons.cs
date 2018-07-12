using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButtons : MonoBehaviour {
    private Ray ray;
    private RaycastHit click;

    private Light m_light1;
    private Light m_light2;
    private GameObject m_lightobj1;
    private GameObject m_lightobj2;

    private int[] temp = new int[5];
    private int j = 0;
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

        m_light1.enabled = true;
        m_light1.color = Color.red;
        m_light2.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out click);
        if (click.collider.tag == "Button_1" && Input.GetMouseButtonDown(0))
        {
            j = j + 1;
            temp[0] = j;
            Debug.Log(j);
            Debug.Log(temp[0]);
        }
        if (click.collider.tag == "Button_2" && Input.GetMouseButtonDown(0))
        {
            j = j + 1;
            temp[1] = j;
            Debug.Log(j);
            Debug.Log(temp[1]);
        }
        if (click.collider.tag == "Button_3" && Input.GetMouseButtonDown(0))
        {
            j = j + 1;
            temp[2] = j;
            Debug.Log(j);
            Debug.Log(temp[2]);
        }
        if (temp[0] == 1 && temp[1] == 2 && temp[2] == 3 && m_light2.enabled == false)
        //if (j == 3 && m_light.enabled == false)
        {
            m_light2.enabled = true;
            m_light2.color = Color.green;
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = 0;
            }
            j = 0;
        }
        if (temp[0] == 1 && temp[1] == 2 && temp[2] == 3 && m_light2.enabled == true)
        //else if (j == 3 && m_light.enabled == true)
        {
            m_light2.enabled = false;
            m_light2.color = Color.green;
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = 0;
            }
            j = 0;
        }
        if (m_light2.enabled == true)
        {
            m_light1.enabled = false;
        }
    }
}

