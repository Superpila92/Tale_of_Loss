using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class DemAnim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UnityFactory.factory.LoadDragonBonesData("Dem_Anim_ske");
        UnityFactory.factory.LoadTextureAtlasData("Dem_Anim_tex");

        var armatureComponent = UnityFactory.factory.BuildArmatureComponent("Dem_Anim");

        armatureComponent.animation.Play("Dem_Idle_01");

        armatureComponent.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    private void Update()
    {
        UnityFactory.factory.BuildArmatureComponent("Dem_Anim").animation.Play("Dem_walk");
    }

}
