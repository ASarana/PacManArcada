using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityStandardAssets.CrossPlatformInput;

public class mybutton : MonoBehaviour
{
		public createaxes axes; //сюда подтянем скрипт с родительского объекта, где идет инициализация осей
		public string Name;

        void OnEnable()
        {
        }

		void OnDisable()
		{
		}

        public void SetDownState()
        {
	
            CrossPlatformInputManager.SetButtonDown(Name); //хз что это, было изначально
		//дальше в зависмоси от того, какая кнопка нажимается, присваиваем оси направление (ось получена из родительского объекта)
		if(Name == "Right")
			axes.m_HorizontalVirtualAxis.Update(1);
		if(Name == "Left")
			axes.m_HorizontalVirtualAxis.Update(-1);
		if(Name == "Up")
			axes.m_VerticalVirtualAxis.Update(1);
		if(Name == "Down")
			axes.m_VerticalVirtualAxis.Update(-1);
        }


        public void SetUpState()
        {
           CrossPlatformInputManager.SetButtonUp(Name);

		//к зависимости от кнопки зануляем напрвавление при отпукании кнопки
		if(Name == "Right")
			axes.m_HorizontalVirtualAxis.Update(0);
		if(Name == "Left")
			axes.m_HorizontalVirtualAxis.Update(0);
		if(Name == "Up")
			axes.m_VerticalVirtualAxis.Update(0);
		if(Name == "Down")
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

