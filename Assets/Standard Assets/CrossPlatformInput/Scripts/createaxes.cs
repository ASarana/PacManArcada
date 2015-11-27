using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class createaxes : MonoBehaviour 
{

	public string horizontalAxisName = "Horizontal"; // The name given to the horizontal axis for the cross platform input
	public string verticalAxisName = "Vertical"; // The name given to the vertical axis for the cross platform input
	public CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // Reference to the joystick in the cross platform input
	public CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis; // Reference to the joystick in the cross platform input
	// Use this for initialization
	void OnEnable () 
	{
		m_HorizontalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(horizontalAxisName);
		CrossPlatformInputManager.RegisterVirtualAxis(m_HorizontalVirtualAxis);
		
		m_VerticalVirtualAxis = new CrossPlatformInputManager.VirtualAxis(verticalAxisName);
		CrossPlatformInputManager.RegisterVirtualAxis(m_VerticalVirtualAxis);
	}

	void Start ()
	{
	}
	// Update is called once per frame
	void Update () 
	{
	
	}
}
