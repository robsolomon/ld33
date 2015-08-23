using UnityEngine;
using System.Collections;

public class SpriteSlide : MonoBehaviour {

	public float animationSpeed = 0.5f;
	
	public bool showSprite = false;
	public bool coolSpriteIsMoving = false;
	
	bool previousShowSpriteState;
	
	public SpriteRenderer coolSprite;
	public Transform offscreenTargetPosition;
	
	Vector3 onscreenTargetPosition;
	
	Vector3 animationStartingPoint;
	Vector3 animationTargetPoint;
	
	float animationTime = 0;

	
	// Use this for initialization
	void Start () {
		onscreenTargetPosition = coolSprite.gameObject.transform.localPosition;
		previousShowSpriteState = showSprite;
		showSprite = false; //not yet, precious
		animationStartingPoint = offscreenTargetPosition.localPosition;
		coolSprite.transform.localPosition = animationStartingPoint;
	}
	
	// Update is called once per frame
	void Update () {
		if (showSprite != previousShowSpriteState)
		{
			MoveJimmyBuffetInAccordanceToHisHappiness();
			previousShowSpriteState = showSprite;
		}
		if (coolSpriteIsMoving)
		{
			animationTime += Time.deltaTime;
			if (animationTime > animationSpeed)
			{
				animationTime = animationSpeed;
				animationStartingPoint = animationTargetPoint;
				coolSpriteIsMoving = false;
			}
			coolSprite.transform.localPosition = Vector3.Lerp(animationStartingPoint, animationTargetPoint, animationTime / animationSpeed);
		}
		
	}
	
	void MoveJimmyBuffetInAccordanceToHisHappiness()
	{
		animationTime = 0;
		if (showSprite)
			animationTargetPoint = onscreenTargetPosition;
		else
			animationTargetPoint = offscreenTargetPosition.localPosition;
		coolSpriteIsMoving = true;
	}
}
