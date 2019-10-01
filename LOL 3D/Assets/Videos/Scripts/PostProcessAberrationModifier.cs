using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessAberrationModifier : MonoBehaviour
{
    private PostProcessVolume ppv;
    private ChromaticAberration chromaticAberration;
    private bool aberrated = false;

    private void Start()
    {
        ppv = GetComponent<PostProcessVolume>();
        ppv.profile.TryGetSettings(out chromaticAberration);
    }

    public void Aberrate()
    {
        if (aberrated)
        {
            chromaticAberration.intensity.value = 0f;
            aberrated = !aberrated;
        }
        else
        {
            chromaticAberration.intensity.value = 1f;
            aberrated = !aberrated;
        }
    }
}
