using System;
using System.Diagnostics;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.CrossPlatformInput;
using Debug = UnityEngine.Debug;

namespace SampleGame.Movement
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class ClickToMoveUserControl : MonoBehaviour
    {
        private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam; // A reference to the main camera in the scenes transform

        private Camera _cam;
        private Transform _target;

        private bool
            m_Jump; // the world-relative desired move direction, calculated from the camForward and user input.

        // modified for sampleGame
        private bool enableMovement = true;

        private void Start()
        {
            // get the transform of the main camera
            if (Camera.main != null)
            {
                _cam = Camera.main;
                m_Cam = _cam.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.",
                    gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<ThirdPersonCharacter>();
        }

        [SerializeField] private float _speed;


        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }

        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            if (enableMovement)
            {
                Vector3 m_Move = default;
                if (Input.GetMouseButtonDown(1))
                {
                    var targetRay = _cam.ScreenPointToRay(Input.mousePosition);
                    Debug.DrawRay(_cam.transform.position, targetRay.direction * 100, Color.red, 1f);

                    if (Physics.Raycast(targetRay, out var hitInfo))
                    {
                        Debug.Log(hitInfo.collider.name);
                        Debug.Log(hitInfo.point);
                        m_Move = (-m_Character.transform.position + hitInfo.point).normalized * _speed;
                    }

                    bool crouch = Input.GetKey(KeyCode.C);
                    m_Character.Move(m_Move, crouch, m_Jump);
                }


//                 m_Jump = false;
                //Physics.Raycast(m_Cam.transform.position, )
//                 // read inputs
//                 float h = CrossPlatformInputManager.GetAxis("Horizontal");
//                 float v = CrossPlatformInputManager.GetAxis("Vertical");
//                
//
//                 // calculate move direction to pass to character
//                 if (m_Cam != null)
//                 {
//                     // calculate camera relative direction to move:
//                     m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
//                     m_Move = v * m_CamForward + h * m_Cam.right;
//                 }
//                 else
//                 {
//                     // we use world-relative directions in the case of no main camera
//                     m_Move = v * Vector3.forward + h * Vector3.right;
//                 }
// #if !MOBILE_INPUT
//                 // walk speed multiplier
//                 if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
// #endif
//
//                 // pass all parameters to the character control script
//
//                 m_Character.Move(m_Move, crouch, m_Jump);
//                 m_Jump = false;
            }
            else
            {
            }
        }
    }
}