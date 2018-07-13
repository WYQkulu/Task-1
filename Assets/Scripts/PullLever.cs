using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace Valve.VR.InteractionSystem

{
    [RequireComponent(typeof(Interactable))]
    public class PullLever : MonoBehaviour
    {
        private Light m_light1;
        private Light m_light2;
        private GameObject m_lightobj1;
        private GameObject m_lightobj2;
        //private Material m_lightmat1;
        //private Material m_lightmat2;

        private Transform Levers_1;
        private Transform Levers_2;
        private GameObject Leversobj_1;
        private GameObject Leversobj_2;

        //Change this project to Steam VR
        private Vector3 oldPosition;
        private Quaternion oldRotation;

        private Interactable leverinter_1;
        private Interactable leverinter_2;

        private float attachTime;

        private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers);


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
            Leversobj_1 = GameObject.FindGameObjectWithTag("Lever_1");
            Leversobj_2 = GameObject.FindGameObjectWithTag("Lever_2");

            leverinter_1 = Leversobj_1.GetComponent<Interactable>();
            leverinter_2 = Leversobj_2.GetComponent<Interactable>();
        }

        //Change this to VR
        private void HandHoverUpdate(Hand hand)
        {
            if (hand.GetStandardInteractionButtonDown() || ((hand.controller != null) && hand.controller.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip)))
            {
                if (hand.currentAttachedObject == Leversobj_1)
                {
                    // Save our position/rotation so that we can restore it when we detach
                    oldPosition = Levers_1.position;
                    oldRotation = Levers_1.rotation;

                    // Call this to continue receiving HandHoverUpdate messages,
                    // and prevent the hand from hovering over anything else
                    hand.HoverLock(leverinter_1);

                    // Attach this object to the hand
                    hand.AttachObject(Leversobj_1, attachmentFlags);
                    Levers_1.Rotate(Vector3.right, -3f);
                }
                if (hand.currentAttachedObject == Leversobj_2)
                {
                    // Save our position/rotation so that we can restore it when we detach
                    oldPosition = Levers_2.position;
                    oldRotation = Levers_2.rotation;

                    // Call this to continue receiving HandHoverUpdate messages,
                    // and prevent the hand from hovering over anything else
                    hand.HoverLock(leverinter_2);

                    // Attach this object to the hand
                    hand.AttachObject(Leversobj_2, attachmentFlags);
                    Levers_2.Rotate(Vector3.right, -3f);
                }
            }
        }
        void Update()
        {
            if (((Levers_1.rotation.x <= Quaternion.Euler(new Vector3(-55, 0, 0)).x)
                && ((Levers_1.rotation.x >= Quaternion.Euler(new Vector3(-65, 0, 0)).x)))
                && ((Levers_2.rotation.x <= Quaternion.Euler(new Vector3(-85, 0, 0)).x)
                && ((Levers_2.rotation.x >= Quaternion.Euler(new Vector3(-95, 0, 0)).x))))
            {
                m_light1.enabled = false;
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
}