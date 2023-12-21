using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactablePlanet : ItemCollactableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddPlanets();

    }
}
