using UnityEngine;
using System.Collections;

public class BuffetApproves : MonoBehaviour {

	public float buffetAnimationSpeed = 1.0f;

	public bool buffetIsHappyAndWantsToShowIt = false;

	bool buffetPreviousStateOfMind;

	public SpriteRenderer jimmyBuffet;
	public Transform offScreenPosition;

	Vector3 theLocationWhereBuffetIsShowing;

	Vector3 buffetStartingPoint;
	Vector3 buffetTarget;
	bool buffetIsMoving = false;

	float animationTime = 0;

	// Use this for initialization
	void Start () {
		theLocationWhereBuffetIsShowing = jimmyBuffet.gameObject.transform.localPosition;
		buffetPreviousStateOfMind = buffetIsHappyAndWantsToShowIt;
		buffetIsHappyAndWantsToShowIt = false; //not yet, precious
		buffetStartingPoint = offScreenPosition.localPosition;
		jimmyBuffet.transform.localPosition = buffetStartingPoint;
	}
	
	// Update is called once per frame
	void Update () {
		if (buffetIsHappyAndWantsToShowIt != buffetPreviousStateOfMind)
		{
			MoveJimmyBuffetInAccordanceToHisHappiness();
			buffetPreviousStateOfMind = buffetIsHappyAndWantsToShowIt;
		}
		if (buffetIsMoving)
		{
			animationTime += Time.deltaTime;
			if (animationTime > buffetAnimationSpeed)
			{
				animationTime = buffetAnimationSpeed;
				buffetStartingPoint = buffetTarget;
				buffetIsMoving = false;
			}
			jimmyBuffet.transform.localPosition = Vector3.Lerp(buffetStartingPoint, buffetTarget, animationTime / buffetAnimationSpeed);
		}
	
	}

	void MoveJimmyBuffetInAccordanceToHisHappiness()
	{
		animationTime = 0;
		if (buffetIsHappyAndWantsToShowIt)
			buffetTarget = theLocationWhereBuffetIsShowing;
		else
			buffetTarget = offScreenPosition.localPosition;
		buffetIsMoving = true;
	}
}
