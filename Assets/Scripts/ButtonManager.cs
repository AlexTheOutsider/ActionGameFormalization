using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
	float multiplier = 1;
	Button btn;

	void Start() 
	{
		btn = GetComponent<Button>();
		string text = GetComponentInChildren<TextMeshProUGUI>().text;
		Debug.Log(text);
	}
}
