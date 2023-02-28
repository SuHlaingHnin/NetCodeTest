using System.Collections.Generic;
using UnityEngine;

public class PickupManager : Singleton<PickupManager>
{
    List<Transform> pickupList;

    private void Start()
    {
        AssignPickupList();
    }

    private void AssignPickupList()
    {
        pickupList = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++)
        {
            pickupList.Add(transform.GetChild(i));
        }
    }

    //public bool CheckPickupRemain()
    //{
    //    return (pickupList.Count > 0) ? true : false;
    //}

    public void RemovePickupFromList(Transform pickup)
    {
        pickupList.Remove(pickup);

        if(pickupList.Count == 0)
        {
            GameManager.Instance.GameFinish();
        }
    }
}
