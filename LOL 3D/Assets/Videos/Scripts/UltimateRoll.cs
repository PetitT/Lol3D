using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class UltimateRoll : MonoBehaviour
{
    [SerializeField] private List<VideoPlayer> players = new List<VideoPlayer>();
    [SerializeField] private GameObject bigPlayer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            Roll();

        if (Input.GetKeyDown(KeyCode.KeypadPlus))
            RickRoll();

        if (Input.GetKeyDown(KeyCode.KeypadMinus))
            RickerRoll();

        if (Input.GetKeyDown(KeyCode.R))
            TheRickestRoll();
    }

    public void Roll()
    {
        bigPlayer.SetActive(true);
        for (int i = 0; i < players.Count; i++)
        {
            players[i].Play();
        }
    }

    public void RickRoll()
    {
        bigPlayer.SetActive(true);
        for (int i = 0; i < players.Count; i++)
        {
            players[i].playbackSpeed = Random.Range(0, 10);
            players[i].Play();
        }
    }

    public void RickerRoll()
    {
        bigPlayer.SetActive(true);
        StartCoroutine("RickerRollCoroutine");
    }

    public IEnumerator RickerRollCoroutine()
    {
        for (int i = 0; i < players.Count; i++)
        {           
            players[i].Play();
            yield return new WaitForSeconds(1);
        }
    }

    public void TheRickestRoll()
    {
        bigPlayer.SetActive(true);
        StartCoroutine("TheRickestRollCoroutine");
    }

    public IEnumerator TheRickestRollCoroutine()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].playbackSpeed = Random.Range(0, 10);
            players[i].Play();
            yield return new WaitForSeconds(1);
        }
    }
}
