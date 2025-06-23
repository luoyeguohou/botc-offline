using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcsUtil
{
    private static GameObject prefab;
    public static void PlaySound(string s)
    {
        if (prefab == null)
            prefab = Resources.Load<GameObject>("SoundEffect/SoundGameObject");
        SoundPlayer sound = GameObject.Instantiate(prefab).GetComponent<SoundPlayer>(); ;
        sound.PlaySound("SoundEffect/" + s);
    }
}
