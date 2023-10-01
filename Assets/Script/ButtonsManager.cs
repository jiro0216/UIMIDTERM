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
    public Vector2 targetpos, Originalpos, ReturnPos,originalpos;
    public Vector3 targetpos3,originalPos4;
    public Vector3 targetpos2, originalpos2, returnpos2;
    public Vector3 targetpos4, originalpos3;
    private bool isZoomOut = false;
    private bool isfadeout = false;
    private bool browseSequenceOut = false;
    private bool isFadeOutRight = false;
    private Color originalcolor;
    private Vector3 originalScale;




    public void Zoom()
    {
        float zoomVal = 0;
        float targetScale = isZoomOut ? 1.0f : zoomVal;
        imageToScale.transform.DOScale(targetScale, 0.25f);
        isZoomOut = !isZoomOut;
    }

    public void Awake()
    {
        originalcolor = ImageToFade.color;
        originalpos = ImageToBrowse.transform.position;
        originalScale = ImageToBrowse.transform.localScale;
        originalcolor = ImageToBrowse.color;
        originalPos4  = ImageToFadeRight.transform.position;
    }
    public void FadeTween()
    {

        if (isfadeout)
        {
            ImageToFade.color = originalcolor;
        }
        else
        {
            ImageToFade.DOFade(0, FadeDuration);

        }
        isfadeout = !isfadeout;
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
       

        if (browseSequenceOut) 
        {
            //ImageToBrowse.transform.position = originalpos2;
            //ImageToBrowse.color = originalcolor;
            //ImageToBrowse.transform.localScale = originalScale;
            DG.Tweening.Sequence sequence = DOTween.Sequence();
            sequence.Append(ImageToBrowse.DOFade(originalcolor.a, FadeDuration));
            sequence.AppendInterval(0);
            sequence.Append(ImageToBrowse.transform.DOLocalMove(originalpos2, speed));
            sequence.AppendInterval(0);
            sequence.Append(ImageToBrowse.transform.DOLocalMove(originalpos2, speed));

        }
        else
        {
            DG.Tweening.Sequence sequence = DOTween.Sequence();
            sequence.Append(ImageToBrowse.transform.DOLocalMove(targetpos2, speed));
            sequence.AppendInterval(0);
            sequence.Append(ImageToBrowse.transform.DOLocalMove(originalpos2, speed));
            sequence.AppendInterval(0);
            sequence.Append(ImageToBrowse.DOFade(0, FadeDuration));
        }
        browseSequenceOut = !browseSequenceOut;

    }

    public void SequenceFadeRight()
    {
        if (isFadeOutRight) 
        {
            DG.Tweening.Sequence sequence =DOTween.Sequence();
            sequence.Append(ImageToFadeRight.transform.DOLocalMove(targetpos3, speed));
            sequence.AppendInterval(0);
            sequence.Append(ImageToFadeRight.DOFade(originalcolor.a, FadeDuration));
            sequence.Append(ImageToFadeRight.transform.DOLocalMove(originalPos4, speed));
        }
        else 
        {

            DG.Tweening.Sequence sequence = DOTween.Sequence();
            sequence.Append(ImageToFadeRight.transform.DOLocalMove(targetpos3, speed));
            sequence.AppendInterval(0);
            sequence.Append(ImageToFadeRight.DOFade(0, FadeDuration));
        }
        isFadeOutRight = !isFadeOutRight;

        
    }

    public void Flyup()
    {
        ImageToFlyUp.transform.DOLocalMove(targetpos4, speed).OnComplete(() => Returnpos1());
    }

    public void Returnpos1()
    {
        ImageToFlyUp.transform.DOLocalMove(originalpos3, speed);
    }




}
