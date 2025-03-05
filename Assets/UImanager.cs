using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UImanager : MonoBehaviour
{
    public float fadeTime = 1f; // 淡入淡出时间
    public CanvasGroup canvasGroup; // 获得CanvasGroup组件来调节alpha值
    public RectTransform rectTransform; // 位置组件
    public List<GameObject> items = new(); // 包含所有图标的列表
    public GameObject exitButton; // **退出按钮**

    // **设置淡入函数**
    public void PanelFadeIn()
    {
        exitButton.SetActive(false); // **禁用退出按钮**

        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(0, -1200f, 0);
        rectTransform.DOAnchorPos(Vector2.zero, fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1f, fadeTime);

        StartCoroutine(ItemsAnimation());
    }

    // **设置淡出函数**
    public void PanelFadeOut()
    {


        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = Vector3.zero;
        rectTransform.DOAnchorPos(new Vector2(0, -1200), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(0f, fadeTime);
    }

    // **图标动画**
    IEnumerator ItemsAnimation()
    {
        foreach (var item in items)
        {
            item.transform.localScale = Vector3.zero;
        }

        foreach (var item in items)
        {
            item.transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.25f);
        }

        // **所有图标动画完成后启用退出按钮**
        exitButton.SetActive(true);
    }
}
