using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BadThingData", menuName = "ScriptableObjects/BadThingScriptableObject")]
public class BadThingData : ScriptableObject
{
	public string name = "SootSprite";
	public float speed = 1f;
	public float lifetime = 1f;
	public int points = 1;
    public Color myColor;
}
