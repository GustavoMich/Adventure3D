using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EndGame : MonoBehaviour
{
    public SFXType sfxType;
    public List<GameObject> endGameObjects;

    private bool _endGame = false;


    public int currentLevel = 1;

    private void Awake()
    {
        endGameObjects.ForEach(i => i.SetActive(false));
    }

    private void PlaySFX()
    {
        SFXPool.Instance.Play(sfxType);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController p = other.transform.GetComponent<PlayerController>();

        if (!_endGame && p != null)
        {
            PlaySFX();
            ShowEndGame();
        }
    }

    private void ShowEndGame()
    {
        _endGame = true;
        endGameObjects.ForEach(i => i.SetActive(true));

        foreach(var i in endGameObjects)
        {
            i.SetActive(true);
            i.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
            SaveManager.Instance.SaveLastLevel(currentLevel);
        }
    }
}
