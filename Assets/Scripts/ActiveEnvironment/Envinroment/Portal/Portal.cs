using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour , ICollWithPlayer
{
    public enum NamePortal { Portal1, Portal2 }
    public NamePortal namePortal = NamePortal.Portal1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (namePortal==NamePortal.Portal1)
            {
                PortalManager.Instance._portal2.GetComponent<Collider>().isTrigger = true;
                collision.transform.position = PortalManager.Instance._portal2.transform.position;
            }
            else
            {
                PortalManager.Instance._portal1.GetComponent<Collider>().isTrigger = true;
                collision.transform.position = PortalManager.Instance._portal1.transform.position;
            }
        }
    }

    public void OnTriggerExit(Collider collision)
    {
        PortalManager.Instance._portal1.GetComponent<Collider>().isTrigger = false;
        PortalManager.Instance._portal2.GetComponent<Collider>().isTrigger = false;
    }

    public void OnTriggerEnter(Collider other)
    {
    }
}
