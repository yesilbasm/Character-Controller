using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MovementData
{
    public float MaxSpeed;
    public float MovmeentForce;
    public float TurnSpeed;
    public float JumpHeight;
}

[System.Serializable]
public class HealthData
{
    public float MaxHealth;
    public float InitialDamage;
}

[System.Serializable]
public class ControllerData
{
    public Joystick PlayerJoystick;
}


[CreateAssetMenu(fileName = "Character Data", menuName = "CharacterControllerExample/Character Data", order = 1)]
public class CharacterData : ScriptableObject
{
    public MovementData MovementData = new MovementData();
    public HealthData HealthData = new HealthData();
}