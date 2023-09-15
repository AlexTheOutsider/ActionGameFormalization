using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[Serializable]
public struct GlobalSettings
{
	public Vector2 trackSize;
	public float attackSpeed;
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

	GameObject track;

	void Start()
	{
		Debug.Log("Game Started");

		track = GameObject.Find("Track");
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
	}
}
