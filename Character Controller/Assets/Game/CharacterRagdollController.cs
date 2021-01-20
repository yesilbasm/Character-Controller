using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterControllerExample
{
    public class CharacterRagdollController : MonoBehaviour
    {
        List<Rigidbody> rigidbodies;
        List<Rigidbody> Rigidbodies { get { return (rigidbodies == null || rigidbodies.Count == 0) ? rigidbodies = new List<Rigidbody>(GetComponentsInChildren<Rigidbody>()) : rigidbodies; } }

        Character character;
        Character Character { get { return (character == null) ? character = GetComponentInParent<Character>() : character; } }


        private void Start()
        {
            DeactivateRagdoll();
        }

        private void OnEnable()
        {
            Character.OnCharacterDie.AddListener(ActivateRagdoll);
            Character.OnCharacterRevive.AddListener(DeactivateRagdoll);
        }

        private void OnDisable()
        {
            Character.OnCharacterDie.RemoveListener(ActivateRagdoll);
            Character.OnCharacterRevive.RemoveListener(DeactivateRagdoll);
        }

        private void ActivateRagdoll()
        {
            foreach (var body in Rigidbodies)
            {
                body.isKinematic = false;
            }
        }

        private void DeactivateRagdoll()
        {
            foreach (var body in Rigidbodies)
            {
                body.isKinematic = true;
            }
        }
    }
}

