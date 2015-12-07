using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class MouseLook
    {
        public float XSensitivity = 2f;
        public float YSensitivity = 2f;
        public bool clampVerticalRotation = true;
        public float MinimumX = -90F;
        public float MaximumX = 90F;
        public bool smooth;
        public float smoothTime = 2.5f;


        private Quaternion m_CharacterTargetRot;
        private Quaternion m_CameraTargetRot;
		private Quaternion bottomRot = new Quaternion(1f,0f,0f,1f);
		private bool lookedDown = false;

        public void Init(Transform character, Transform camera)
        {
            m_CharacterTargetRot = character.localRotation;
            m_CameraTargetRot = camera.localRotation;
        }


		public void LookRotation(Transform character, Transform camera)
		{
			float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
			float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;
			
			m_CharacterTargetRot *= Quaternion.Euler (0f, yRot, 0f);
			m_CameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);
			
			if(clampVerticalRotation)
				m_CameraTargetRot = ClampRotationAroundXAxis (m_CameraTargetRot);
			
			if(smooth)
			{
				character.localRotation = Quaternion.Slerp (character.localRotation, m_CharacterTargetRot,
				                                            smoothTime * Time.deltaTime);
				camera.localRotation = Quaternion.Slerp (camera.localRotation, m_CameraTargetRot,
				                                         smoothTime * Time.deltaTime);
			}
			else
			{
				character.localRotation = m_CharacterTargetRot;
				camera.localRotation = m_CameraTargetRot;
			}
		}


		public void LookFallingRotation(Transform character, Transform camera)
		{
			float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
			float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;
			


			if (lookedDown) {

				m_CharacterTargetRot *= Quaternion.Euler (0f, yRot, 0f);


				m_CameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);
				m_CameraTargetRot = ClampRotationAroundXAxis (m_CameraTargetRot);
				m_CameraTargetRot.x += UnityEngine.Random.Range(-0.025f, 0.025f);
				m_CameraTargetRot.x = Mathf.Clamp(m_CameraTargetRot.x, .7f, 1f);
			}else {
				m_CameraTargetRot = bottomRot;
			}

			if (camera.localRotation == bottomRot) {
				lookedDown = true;
			}

			character.localRotation = Quaternion.Slerp (character.localRotation, m_CharacterTargetRot,
			                                            smoothTime * Time.deltaTime);
			camera.localRotation = Quaternion.Slerp (camera.localRotation, m_CameraTargetRot,
			                                         smoothTime * Time.deltaTime);
			
		}





		Quaternion ClampRotationAroundXAxis(Quaternion q)
		{
			q.x /= q.w;
			q.y /= q.w;
			q.z /= q.w;
			q.w = 1.0f;
			
			float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan (q.x);
			
			angleX = Mathf.Clamp (angleX, MinimumX, MaximumX);
			
			q.x = Mathf.Tan (0.5f * Mathf.Deg2Rad * angleX);
			
			return q;
		}

    }
}
