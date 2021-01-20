using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterControllerExample
{
    public class CharacterDamager : MonoBehaviour
    {
        public List<GameObject> HitParticleEffect;

        CharacterHealthController characterHealthController;
        CharacterHealthController CharacterHealthController { get { return (characterHealthController == null) ? characterHealthController = transform.root.GetComponentInChildren<CharacterHealthController>() : characterHealthController; } }

        private void OnTriggerEnter(Collider other)
        {
            CharacterHealthController healthController = other.GetComponent<CharacterHealthController>();
            if (ReferenceEquals(healthController, CharacterHealthController))
                return;

            if(healthController)
            {
                Rigidbody rigidbody = other.GetComponent<Rigidbody>();
                rigidbody.AddForceAtPosition((transform.position - other.transform.position).normalized * 20, transform.position, ForceMode.Impulse);
                healthController.Damage();
                Instantiate(HitParticleEffect[Random.Range(0, HitParticleEffect.Count)], transform.position, Quaternion.identity);
            }
        }
    }
}

