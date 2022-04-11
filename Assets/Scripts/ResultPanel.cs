using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class ResultPanel : MonoBehaviour
{
    public Image background;
    public TextMeshProUGUI resultText;

    [Space]
    public Button continueButton;
    public Button retryButton;

    private Color _defaultBackgroundColor;

    private void Awake()
    {
        continueButton.onClick.AddListener(OnContinueButtonPressed);
        retryButton.onClick.AddListener(OnRetryButtonPressed);

        gameObject.SetActive(false);

        _defaultBackgroundColor = background.color;
    }

    public void Show(bool isWin, float delay)
    {

        if (isWin)
        {
            resultText.text = "You Win";

        }
        else
        {
            resultText.text = "You Lose";

        }

        continueButton.gameObject.SetActive(isWin);
        retryButton.gameObject.SetActive(!isWin);

        PreShowAnimation();
        RunShowAnimation(delay);

    }

    private void PreShowAnimation()
    {
        var c = background.color;
        c.a = 0;
        background.color = c;

        resultText.transform.localScale = Vector3.zero;
        continueButton.transform.localScale = Vector3.zero;
        retryButton.transform.localScale = Vector3.zero;

        gameObject.SetActive(true);
        background.gameObject.SetActive(true);

    }

    private void RunShowAnimation(float delay)
    {

        background.DOColor(_defaultBackgroundColor, 1).SetEase(Ease.InSine).SetId(GetInstanceID()).SetDelay(delay);
        resultText.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack).SetDelay(delay + 0.5f);
        retryButton.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack).SetDelay(delay + 0.6f);
        continueButton.transform.DOScale(1, 0.5f).SetEase(Ease.OutBack).SetDelay(delay + 0.6f);

    }

    private void OnContinueButtonPressed()
    {
        continueButton.interactable = false;
        Invoke("NextScene", 0.2f);
    }

    private void OnRetryButtonPressed()
    {
        retryButton.interactable = false;
        Invoke("Restart", 0.2f);
    }

    private void NextScene()
    {
        Account.Level++;


        DOTween.KillAll();
        SceneManager.LoadScene(Account.SceneName);
    }

    private void Restart()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
