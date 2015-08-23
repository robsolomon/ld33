using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteSlide))]
public class SpriteSlideShowBubble : MonoBehaviour {

	public float showTalkBubbleTime = 1.5f;

	public TalkBubble talkBubble;

	SpriteSlide slidinSprite;

	bool spriteIsMovingInSoLetsShowTheBubbleAsSoonAsItIsDoneOkay = false;

	// Use this for initialization
	void Awake () {
		slidinSprite = GetComponent<SpriteSlide>();
	}
	
	// Update is called once per frame
	void Update () {
		if (slidinSprite.coolSpriteIsMoving && slidinSprite.showSprite)
			spriteIsMovingInSoLetsShowTheBubbleAsSoonAsItIsDoneOkay = true;
		if (spriteIsMovingInSoLetsShowTheBubbleAsSoonAsItIsDoneOkay && !slidinSprite.coolSpriteIsMoving)
		{
			spriteIsMovingInSoLetsShowTheBubbleAsSoonAsItIsDoneOkay = false; //cos we are about to show it, yeah!
			ShowMeTheSweetTalkBubble();
		}
		if (!slidinSprite.showSprite && slidinSprite.coolSpriteIsMoving)
		{
			if (IsInvoking("HideTheBubble"))
				CancelInvoke("HideTheBubble");
			HideTheBubble();
		}
	
	}

	void ShowMeTheSweetTalkBubble() {
		if (talkBubble != null)
		{
			talkBubble.Show ();
			Invoke ("HideTheBubble", showTalkBubbleTime);
		}

	}

	void HideTheBubble() {
		if (talkBubble != null)
		{
			talkBubble.Hide ();
		}
	}
}
