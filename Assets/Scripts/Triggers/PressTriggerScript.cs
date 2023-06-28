using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressTriggerScript : MonoBehaviour
{
    GameObject thisObject;

    void Start()
    {
        thisObject = this.gameObject;
    }

    public void FindTriggerType()
    {
        if (thisObject.TryGetComponent(out SmallChestScript _))
        {
            thisObject.GetComponent<SmallChestScript>();
            Debug.Log("Small Chest");
        }

        if (thisObject.TryGetComponent(out MediumChestScript _))
        {
            thisObject.GetComponent<MediumChestScript>();
            Debug.Log("Medium Chest");
        }

        if (thisObject.TryGetComponent(out NpcScript _))
        {
            thisObject.GetComponent<NpcScript>();
            Debug.Log("NPC");
        }
    }
}
