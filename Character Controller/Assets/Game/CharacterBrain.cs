using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Responsible for Logic
/// </summary>
public class CharacterBrain : CharacterBrainBase
{
    
    public Joystick PlayerJoystick;
    public override void Logic()
    {
        CharacterController.Move(new Vector3(PlayerJoystick.Horizontal, 0, PlayerJoystick.Vertical));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Character aiCharacter = collision.collider.GetComponent<Character>();
        if(aiCharacter)
        {
            if(aiCharacter.CharacterType == CharacterType.AI)
            {
                Character.OnCharacterAttack.Invoke();
            }
        }
    }
}


