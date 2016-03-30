using UnityEngine;
using System.Collections;

namespace MyCar {
    public class CarOrbitCamera : MonoBehaviour {

        public Transform m_Pivot;
        public float m_OrbitSpeed = 2.5f;
        public float m_MouseWheelSpeed = 1.5f;

        private float m_ZoomPosition = -10.0f;
        private float m_RotationX = 30.0f;
        private float m_RotationY = 0.0f;


        // Use this for initialization
        void Start(){
            if (m_Pivot == null) m_Pivot = transform.parent;
        }

        // Update is called once per frame
        void Update(){
            m_RotationX -= Input.GetAxis("Mouse Y") * m_OrbitSpeed;
            m_RotationY += Input.GetAxis("Mouse X") * m_OrbitSpeed;
            m_ZoomPosition += Input.GetAxis("MouseWheel") * m_MouseWheelSpeed;

            m_Pivot.transform.localRotation = Quaternion.Euler(m_RotationX, m_RotationY, 0.0f);
            transform.localPosition = new Vector3(0.0f, 0.0f, m_ZoomPosition);
        }
    }
}
