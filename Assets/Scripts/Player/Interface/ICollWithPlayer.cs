using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface ICollWithPlayer
{
    void OnCollisionEnter(Collision collision);
    void OnTriggerExit(Collider other);
    void OnTriggerEnter(Collider other);
}
