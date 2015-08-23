using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TalkBubble : MonoBehaviour {

	public List<string> phrases;

	public SpriteRenderer sprite;
	public TextMesh text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Show () {
		if (phrases.Count > 0)
			text.text = phrases[Random.Range (0, phrases.Count)];
		StateSwitch(true);
	}

	public void Hide () {
		StateSwitch(false);
	}

	void StateSwitch(bool state)
	{
		sprite.enabled = state;
		text.gameObject.SetActive(state);
	}
}
