using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatButton : MonoBehaviour 
{

	public void OnClick( dfControl control, dfMouseEventArgs mouseEvent )
	{
        audio.Play();
        StatPanelCloseButton._instance.BounceIn();
	}

}
