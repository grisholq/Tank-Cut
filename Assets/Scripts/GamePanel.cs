﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePanel : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public Button restartButton;

    public RectTransform tutorial;


    private void Awake()
    {
        restartButton.onClick.AddListener(OnRestart);
    }

    private void OnRestart()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void ShowTutorial()
    {
        DOTween.Sequence().SetId(GetInstanceID())
            .Append(tutorial.DOScale(0.98f, 0.5f).SetLoops(10, LoopType.Yoyo).SetEase(Ease.InOutSine))
            .Append(tutorial.DOScale(0, 0.3f).SetEase(Ease.InSine))
            .AppendCallback(() => {
                tutorial.gameObject.SetActive(false);
            });
            
    }

   
}
