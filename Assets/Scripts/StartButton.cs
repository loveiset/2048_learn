using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StartButton : MonoBehaviour 
{

	public void OnClick( dfControl control, dfMouseEventArgs mouseEvent )
	{
		// Add event handler code here
        Application.LoadLevel(1);
	}

}
