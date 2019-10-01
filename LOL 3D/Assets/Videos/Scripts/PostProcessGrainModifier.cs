using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessGrainModifier : MonoBehaviour
{
    private PostProcessVolume ppv;
    private Grain grain;

    private void Start()
    {
        ppv = GetComponent<PostProcessVolume>();
        ppv.profile.TryGetSettings(out grain);
    }

    public void MakeItGrainy()
    {
        grain.active = !grain.active;
    }
}
