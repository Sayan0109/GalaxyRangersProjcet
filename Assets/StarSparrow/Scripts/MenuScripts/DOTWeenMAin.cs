using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class DOTWeenMAin : MonoBehaviour
{
    [SerializeField] private float _transSpeed;
    [SerializeField] private float _rotationStep;
    [SerializeField] private float _speedFade;

    public void OpenPanel(GameObject panel)
    {
        panel.transform.DOScale(1, _transSpeed);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.transform.DOScale(0, _transSpeed);
    }

    /*public void MaxFade(GameObject panel)
    {
        panel.GetComponent<CanvasGroup>().DOFade(1, _transSpeed);
    }*/
    public void MMMaxFade(GameObject panel)
    {
        CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();

        // Сразу разрешаем клики
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;

        canvasGroup.DOFade(1, _speedFade);
    }

    /*public void MinFade(GameObject panel)
    {
        panel.GetComponent<CanvasGroup>().DOFade(0, _transSpeed);
    }*/

    public void MMMinFade(GameObject panel)
    {
        CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();

        // Запрещаем взаимодействие СРАЗУ
        canvasGroup.interactable = false;

        canvasGroup.DOFade(0, _speedFade)
            .OnComplete(() =>
            {
                // Полностью отключаем клики
                canvasGroup.blocksRaycasts = false;
            });
    }

    public void MoveUp(GameObject panel)
    {
        panel.GetComponent<RectTransform>()
             .DOAnchorPos(new Vector2(-485, 2000), _transSpeed);
    }

    public void MoveDown(GameObject panel)
    {
        panel.GetComponent<RectTransform>()
             .DOAnchorPos(new Vector2(-485, -53), _transSpeed);
    }

}
