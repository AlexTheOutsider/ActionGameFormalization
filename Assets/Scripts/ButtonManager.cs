using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehavior : MonoBehaviour
{
	public bool HasCombo;
	public int MaxComboCount = 3;

	Button button;

	void Start() 
	{
		button = GetComponent<Button>();
		Debug.Log("Init " + GetComponentInChildren<TextMeshProUGUI>().text);
	}


	public void OnClicked()
	{

	}
}
