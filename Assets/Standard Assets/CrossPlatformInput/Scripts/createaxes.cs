using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class createaxes : MonoBehaviour 
{

	public string horizontalAxisName = "Horizontal"; // название оси горизонтали для кросплатформенного ввода
	public string verticalAxisName = "Vertical"; // название оси вертикали для кросплатформенного ввода
	public CrossPlatformInputManager.VirtualAxis m_HorizontalVirtualAxis; // создаем переменные с типом виртуальные оси
	public CrossPlatformInputManager.VirtualAxis m_VerticalVirtualAxis; 

	void OnEnable () 
	{
		//регистрируем оси для работы
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
