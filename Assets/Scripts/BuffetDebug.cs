using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteSlide))]
public class BuffetDebug : MonoBehaviour {

	SpriteSlide slidinSprite;

	// Use this for initialization
	void Start () {
		slidinSprite = GetComponent<SpriteSlide>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Minus))
			slidinSprite.showSprite = false;
		if (Input.GetKeyDown (KeyCode.Equals))
			slidinSprite.showSprite = true;

	}
}
