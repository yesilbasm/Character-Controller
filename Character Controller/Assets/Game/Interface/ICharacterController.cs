using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterController
    {
        float GetCurrentSpeed();

        void Intialize();
        void Move(Vector3 direction);
        void Rotate(Vector3 direction);
        void Dispose();
    }
