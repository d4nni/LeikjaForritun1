using UnityEngine;
using UnityEngine.UI;

public class UIAmmoCount : MonoBehaviour 
{
	public static UIAmmoCount Instance { get; private set;}

	public Text countText;
	
	// Use this for initialization
	void Awake ()
	{
		Instance = this;
	}

	public void SetAmmo(int count, int max)
	{
		countText.text = "x" + count + "/" + max;
	}
}
