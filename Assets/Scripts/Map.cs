using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Valve.VR.InteractionSystem
{
    [RequireComponent(typeof(Interactable))]
    public class Map : MonoBehaviour
    {
        private Light m_light1;
        private Light m_light2;
        private GameObject m_lightobj1;
        private GameObject m_lightobj2;

        private GameObject ball;
        private Transform ballTransform;
        private Vector3 dis;
        private Interactable ballinter;

        private Vector3 oldPosition;
        private Quaternion oldRotation;

        private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers);


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

            m_light1.enabled = true;
            m_light1.color = Color.red;
            m_light2.enabled = false;

            ball = GameObject.Find("Ball");
            ballTransform = ball.GetComponent<Transform>();
            oldPosition = ballTransform.position;
            ballinter = ball.GetComponent<Interactable>();

    }

        // Use controller to control the ball
        private void HandHoverUpdate(Hand hand)
        {
            if (hand.GetStandardInteractionButtonDown() || ((hand.controller != null) && hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)))
            {
                if (hand.currentAttachedObject == ball)
                {
                    hand.HoverLock(ballinter);
                    hand.AttachObject(ball, attachmentFlags);
                }
            }
        }
        void OnTriggerStay(Collider collider)
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

}
