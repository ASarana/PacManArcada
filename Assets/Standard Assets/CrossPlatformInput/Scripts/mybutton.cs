using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

	public class mybutton : MonoBehaviour
    {
		public createaxes axes;
		public string Name;
		/*public string horizontalAxisName = "Horizontal"; // The name given to the horizontal axis for the cross platform input
		public string verticalAxisName = "Vertical"; // The name given to the vertical axis for the cross platform input
		CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // Reference to the joystick in the cross platform input
		CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis; // Reference to the joystick in the cross platform input
*/
public string direction;
		//public AxisOption axesToUse = AxisOption.Both;

        void OnEnable()
        {
			/*m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis (horizontalAxisName);
			CrossPlatformInputManager.RegisterVirtualAxis (m_HorizontalVirtualAxis);
			m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
			CrossPlatformInputManager.RegisterVirtualAxis(m_VerticalVirtualAxis);*/
        }

		void OnDisable()
		{
		/*	m_HorizontalVirtualAxis.Remove();
			m_VerticalVirtualAxis.Remove();*/
		}

        public void SetDownState()
        {
	
            CrossPlatformInputManager.SetButtonDown(Name);
			if(direction == "Right")
			axes.m_HorizontalVirtualAxis.Update(1);
			if(direction == "Left")
			axes.m_HorizontalVirtualAxis.Update(-1);
			if(direction == "Up")
			axes.m_VerticalVirtualAxis.Update(1);
			if(direction == "Down")
			axes.m_VerticalVirtualAxis.Update(-1);
        }


        public void SetUpState()
        {
           CrossPlatformInputManager.SetButtonUp(Name);
			if(direction == "Right")
			axes.m_HorizontalVirtualAxis.Update(0);
			if(direction == "Left")
			axes.m_HorizontalVirtualAxis.Update(0);
			if(direction == "Up")
			axes.m_VerticalVirtualAxis.Update(0);
			if(direction == "Down")
			axes.m_VerticalVirtualAxis.Update(0);


        }


        public void SetAxisPositiveState()
        {
            CrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            CrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            CrossPlatformInputManager.SetAxisNegative(Name);
        }

        public void Update()
        {

        }
    }

