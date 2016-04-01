using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Car {
    [System.Serializable]
    class WheelAxleInfo {
        public WheelCollider[] m_WheelColiders;
        public Transform[] m_Wheels;

        public bool m_isTorque = false;
        public bool m_isSteer = false;
        public bool m_isHandBrake = false;


        public void ApplyMotorTorque(float torque) {
            if (!m_isTorque) return;
            foreach (WheelCollider wc in m_WheelColiders) {
                wc.motorTorque = torque;
            }
        }

        public void ApplySteerAngle(float steer) {
            if (!m_isSteer) return;
            foreach (WheelCollider wc in m_WheelColiders) {
                wc.steerAngle = steer;
            }
        }

        public void ApplyFootbrake(float torque) {
            foreach (WheelCollider wc in m_WheelColiders) {
                wc.brakeTorque = torque;
            }
        }

        public void ApplyHandbrake(float torque) {
            if (!m_isHandBrake) return;
            foreach (WheelCollider wc in m_WheelColiders) {
                wc.brakeTorque = torque;
            }
        }
    }
}
