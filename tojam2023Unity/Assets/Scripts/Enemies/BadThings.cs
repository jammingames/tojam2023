using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BadThings : MonoBehaviour, ICatchable
{
	
	public enum BadThingState
	{
		NullState = 1,
		Floating = 2,
		BadInteracting = 3,
		GoodInteracting = 4
	}

	[SerializeField] BadThingData myData;
	[SerializeField] private SpriteRenderer spriteRenderer;
	float speed;
	float lifetime;
	float currentLifeDuration = 0f;
	Color myColor;
	public int points;
	BadThingState currentBadThingState = BadThingState.NullState;

	Transform target = null;
	int direction = 1;
	private void Awake()
	{
		Init(myData);
		GameManager.OnStateChange += HandleGameStateChange;
	}

	void Start()
	{
		SetBadThingState(BadThingState.Floating);
	}

	private void OnDestroy()
	{
		GameManager.OnStateChange -= HandleGameStateChange;
	}

	private void Update()
	{
		if (currentBadThingState == BadThingState.NullState) return;
		HandleStateUpdate();
	}

	public void Init(BadThingData data)
	{
		myData = data;
		myColor = myData.myColor;
		speed = myData.speed;
		points = myData.points;
		lifetime = myData.lifetime;
		spriteRenderer.color = myColor;
		SetBadThingState(BadThingState.Floating);
		direction = transform.position.x < 0 ? 1 : -1;
	}

	//for stage 3, use in the physics collision logic
	public void GoodCollide()
	{
		GameManager.instance.CollideBadThing(this);
		Die();
	}

	//for stage 1, use in the physics collision logic
	public void BadCollide()
	{
		GameManager.instance.CollideBadThing(this);
		Die();
	}

	public void Die()
	{
		GameObject.Destroy(this.gameObject);
	}


	public void SetBadThingState(BadThingState newState)
	{
		if (currentBadThingState != newState)
		{
			HandleStateChange(newState);
			currentBadThingState = newState;
		}
		else
		{
			Debug.Log("ALREADY IN THIS STATE  " + currentBadThingState);
		}
	}

	public void HandleStateChange(BadThingState newState)
	{
		switch (currentBadThingState)
		{
			case BadThingState.Floating:
				currentLifeDuration = 0;
				break;
		}

	}

	void HandleGameStateChange(GameState newState)
	{
		switch (newState)
		{
			case GameState.Intro:
				break;
			case GameState.Game:
				break;
			case GameState.ScoreScreen:
				Die();
				break;
		}
	}

	public void HandleStateUpdate()
	{
		switch (currentBadThingState) 
		{
			case BadThingState.Floating:
				DoFloating();
				break;
		}
	}


	void DoFloating()
	{
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime * direction;
		transform.position = pos;
		currentLifeDuration += Time.deltaTime;
		if (currentLifeDuration >= lifetime)
			Die();
	}
}
