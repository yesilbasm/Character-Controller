using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum CharacterType { Player, AI}

    [System.Serializable]
    public class CharacterCurrentData
    {
        public float CurrentCoin;
        public int CurrentHealth;

        public MovementData MovementData;
        public HealthData HealthData;
        public void Initiliaze(MovementData movementData, HealthData healthData)
        {
            MovementData = movementData;
            HealthData = healthData;
        }
    }

    /// <summary>
    /// Responsible for Communication
    /// Character State
    /// </summary>
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private CharacterData CharacterData;
        public CharacterCurrentData CharacterCurrentData;
        public CharacterType CharacterType;


        #region Events
        [HideInInspector]
        public UnityEvent OnCharacterRevive = new UnityEvent();
        [HideInInspector]
        public UnityEvent OnCharacterDie = new UnityEvent();
        [HideInInspector]
        public UnityEvent OnCharacterJump = new UnityEvent();
        [HideInInspector]
        public UnityEvent OnCharacterAttack = new UnityEvent();
        #endregion

        private bool isControlable = true;
        public bool IsControlable { get { return isControlable; } set { isControlable = value; } }

        private bool isDead;
        public bool IsDead { get { return isDead; } set { isDead = value; } }

        private void Start()
        {
            CharacterCurrentData.Initiliaze(CharacterData.MovementData, CharacterData.HealthData);
            CharacterManager.Instance.AddCharacter(this);
        }

        private void OnDisable()
        {
            CharacterManager.Instance.RemoveCharacter(this);
        }
    }