using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterControllerExample
{
    /// <summary>
    /// Responsible for Health
    /// </summary>
    public class CharacterHealthController : MonoBehaviour
    {

        private Character character;
        public Character Character { get { return (character == null) ? character = GetComponent<Character>() : character; } }

        public void Damage()
        {
            Character.OnCharacterDie.Invoke();
            Debug.Log("Character " + Character.CharacterType + " Died");
        }
    }
}

