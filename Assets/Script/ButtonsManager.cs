using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ButtonsManager : MonoBehaviour
{
    public Image imageToScale;
    public Image ImageToFade;
    public Image ImageToFly;
    public Image ImageToFlyUp;
    public Image ImageToBrowse;
    public Image ImageToFadeRight;
    public float speed;
    public float FadeDuration;
    public Vector2 targetpos,Originalpos,ReturnPos;
    public Vector3 targetpos3;
    public Vector3 targetpos1, originalpos2, returnpos;
    public Vector3 targetpos4, originalpos3;   
    private bool isZoomOut = false;
    public void Zoom()
    {
        float zoomVal = 0;
        float targetScale = isZoomOut ? 1.0f : zoomVal;
        imageToScale.transform.DOScale(targetScale, 0.25f);
        isZoomOut = !isZoomOut;
    }

    public void FadeTween() 
    {

        ImageToFade.DOFade(0, FadeDuration);
       
     
    }

    public void Flydown() 
    {
        ImageToFly.transform.DOLocalMove(targetpos, speed).OnComplete(() => Returnpos());
    }

    public void Returnpos() 
    {
        ImageToFly.transform.DOLocalMove(Originalpos, speed);
    }

    public void BrowseSequence() 
    {
        DG.Tweening.Sequence sequence = DOTween.Sequence();
        sequence.Append(ImageToBrowse.transform.DOLocalMove(targetpos1, speed));
        sequence.AppendInterval(0);
        sequence.Append(ImageToBrowse.transform.DOLocalMove(Originalpos, speed));
        sequence.AppendInterval(0);
        sequence.Append(ImageToBrowse.DOFade(0, FadeDuration));
    }

    public void SequenceFadeRight() 
    {
        DG.Tweening.Sequence sequence = DOTween.Sequence();
        sequence.Append(ImageToFadeRight.transform.DOLocalMove(targetpos3,speed));
        sequence.AppendInterval(0);
        sequence.Append(ImageToFadeRight.DOFade(0, FadeDuration));
    }

    public void Flyup() 
    {
        ImageToFlyUp.transform.DOLocalMove(targetpos4,speed).OnComplete(() => Returnpos1());
    }

    public void Returnpos1() 
    {
    ImageToFlyUp.transform.DOLocalMove(originalpos3,speed);
    }




}
