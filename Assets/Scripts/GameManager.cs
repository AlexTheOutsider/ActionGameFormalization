using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using UnityEngine.UIElements;

[Serializable]
public struct GlobalSettings
{
	public Vector2 trackSize;
	public float attackSpeed;

	public InputAction attackAction;
	public InputAction skillAction;
	public InputAction ultimateAction;
	public InputAction dodgeAction;
}

public enum ActionPhase
{
	ENUM_INIT,
	ENUM_PRE,
	ENUM_MID,
	ENUM_POST,
	ENUM_END,
	ENUM_COUNT
}

[Serializable]
public struct ActionPhaseStruct
{
	public ActionPhase phase;
	public RectTransform rectTransform;
	public float duration;
}

public class GameManager : MonoBehaviour
{
	public GlobalSettings settings;
	public ActionPhaseStruct[] actionPhaseList = new ActionPhaseStruct[(int)ActionPhase.ENUM_COUNT];
	

	GameObject track, playerBeat;

	public void OnEnable()
	{
		settings.attackAction.Enable();
	}

	public void OnDisable()
	{
		settings.attackAction.Disable();
	}

	void Start()
	{
		Debug.Log("Game Started");

		track = GameObject.Find("Track");
		playerBeat = GameObject.Find("PlayerBeat");
		track.transform.GetComponent<RectTransform>().sizeDelta = settings.trackSize;
		foreach (var actionPhase in actionPhaseList)
		{
			switch (actionPhase.phase)
			{
				case ActionPhase.ENUM_INIT:
				case ActionPhase.ENUM_PRE:
				case ActionPhase.ENUM_MID:
				case ActionPhase.ENUM_POST:
				case ActionPhase.ENUM_END:
					actionPhase.rectTransform.sizeDelta = new Vector2(settings.trackSize.x, settings.trackSize.y * actionPhase.duration);
					break;

				default:
					break;
			}
		}

		settings.attackAction.performed += ctx => { OnAttack(ctx); };
	}

	void Update()
	{

	}

	void OnAttack(InputAction.CallbackContext ctx)
	{
		Debug.Log("Attack Pressed");
		playerBeat.transform.DOMove(playerBeat.transform.position + new Vector3(0, 440, 0), 2);
		//playerBeat.transform.DOMoveY(playerBeat.transform.position.y + 440, 2);
		//playerBeat.transform.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0, 445), 2);
		//StartCoroutine("Move");
	}

	IEnumerator Move()
	{
		for (; ; )
		{
			playerBeat.transform.GetComponent<RectTransform>().localPosition += new Vector3(0, 1, 0);
			yield return new WaitForSeconds(.1f);
		}
	}
}
