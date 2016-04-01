using UnityEngine;
using System;
using System.Collections;

namespace Assets.Scripts.Car {
    class CarControl : MonoBehaviour {

        public float m_MotorTorque = 450.0f;
        public float m_FootbrakeTorque = 800.0f;
        public float m_HandbrakeTorque = 800.0f;
        public float m_MaxSteerAngle = 20.0f;

        public WheelAxleInfo m_FrontAxis;
        public WheelAxleInfo m_BackAxis;

        public Transform m_CenterOfMass;

        private float m_Magnitude = 0.0f;
        private float m_VelocityAngle = 0.0f;

        public void Start() {
            gameObject.GetComponent<Rigidbody>().centerOfMass = m_CenterOfMass.localPosition;
        }

        public void Update() {
            Debug.DrawLine(transform.position, transform.position + gameObject.GetComponent<Rigidbody>().velocity, new Color(0.0f, 0.0f, 1.0f));
        }

        public void FixedUpdate() {
            float torque = 0.0f;
            float m_Throttle = Input.GetAxis("AxisV");
            float steerAngle = Input.GetAxis("AxisH") * m_MaxSteerAngle;

            Vector3 velocity = gameObject.GetComponent<Rigidbody>().velocity;
            m_Magnitude = (float)Math.Round((double)velocity.magnitude, 2);

            Vector3 carDirection = transform.localRotation * Vector3.forward;
            m_VelocityAngle = Vector3.Angle(carDirection, velocity);

            if (m_Throttle > 0.1f) torque = m_Throttle * m_MotorTorque;
            else if(m_Throttle < 0.0f) torque = m_Throttle * m_HandbrakeTorque;

            m_FrontAxis.ApplyMotorTorque(torque);
            m_BackAxis.ApplyMotorTorque(torque);

            m_FrontAxis.ApplySteerAngle(steerAngle);
            m_BackAxis.ApplySteerAngle(steerAngle);
        }

        void OnGUI() {
            GUI.Box(new Rect(10, 10, 120, 24), "Magnitude: " + m_Magnitude);
            GUI.Box(new Rect(10, 36, 120, 24), "VelAngle: " + Mathf.RoundToInt(m_VelocityAngle));
        }
    }
}
