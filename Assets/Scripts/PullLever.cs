using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullLever : MonoBehaviour
{
    private Ray ray;
    private RaycastHit click;

    private Light m_light1;
    private Light m_light2;
    private GameObject m_lightobj1;
    private GameObject m_lightobj2;
    //private Material m_lightmat1;
    //private Material m_lightmat2;

    private Transform Levers_1;
    private Transform Levers_2;
   /* private int temp1=0;
    private bool time1 = true; 
    private int temp2=0;
    private bool time2 = true;*/

    // Use this for initialization
    void Start()
    {
        m_lightobj1 = GameObject.Find("Light5a (1)");
        m_light1 = m_lightobj1.GetComponent<Light>();
        //m_lightmat1 = m_lightobj1.GetComponent<Material>();

        m_lightobj2 = GameObject.Find("Light5a (2)");
        m_light2 = m_lightobj2.GetComponent<Light>();
        //m_lightmat2 = m_lightobj2.GetComponent<Material>();

        //m_lightmat1.color = new Color(255f, 0f, 0f);
        //m_lightmat2.color = new Color(0f, 255f, 0f);
        m_light1.enabled = false;
        m_light2.enabled = false;

        Levers_1 = GameObject.FindGameObjectWithTag("Spindle_1").GetComponent<Transform>();
        Levers_2 = GameObject.FindGameObjectWithTag("Spindle_2").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out click);
        if (click.collider.tag == "Lever_1" && Input.GetMouseButton(0))
        {
            /*if ((temp1 <= 3) && (time1==true))
            {
                temp1 = temp1 + 1;
                //Debug.Log(temp1);
                Levers_1.Rotate(Vector3.left, 30f);
            }
            if ((temp1 > 3) && (time1 == true))
            {
                Levers_1.Rotate(Vector3.left, -30f);
                temp1 = temp1 + 1;
                //Debug.Log(temp1);
            }
            if (temp1 == 11)
            {
                temp1 = 0;
            }*/
            Levers_1.Rotate(Vector3.right, -3f);
        }


        if (click.collider.tag == "Lever_2" && Input.GetMouseButton(0))
        {
            /* //Debug.Log("???");
             if ((temp2 <= 3) && (time2 == true))
             {
                 temp2 = temp2 + 1;
                 //Debug.Log(temp2);
                 Levers_2.Rotate(Vector3.left, 30f);
             }
             if ((temp2 > 3) && (time2 == true))
             {
                 Levers_2.Rotate(Vector3.left, -30f);
                 temp2 = temp2 + 1;
                 //Debug.Log(temp2);
             }
             if (temp2 == 11)
             {
                 temp2 = 0;
             }*/
            Levers_2.Rotate(Vector3.right, -3f);
        }
        if(((Levers_1.rotation.x<=Quaternion.Euler(new Vector3(-55,0,0)).x)
            &&((Levers_1.rotation.x >= Quaternion.Euler(new Vector3(-65, 0, 0)).x)))
            && ((Levers_2.rotation.x <= Quaternion.Euler(new Vector3(-85, 0, 0)).x)
            && ((Levers_2.rotation.x >= Quaternion.Euler(new Vector3(-95, 0, 0)).x))))
        {
            m_light1.enabled = false ;
            m_light2.enabled = true;
            m_light2.color = Color.green;
        }
        else
        {
            m_light1.enabled = true;
            m_light1.color = Color.red;
        }
    }
}

