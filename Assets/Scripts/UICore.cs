
using UnityEngine;

public class UICore : MonoBehaviour
{
    private CanvasGroup canvasGrp;
    
    [SerializeField]
    private RectTransform highlightCircle;
    private Transform highlightTarget;
    
    private void Init()
    {
        //For future stuff
        canvasGrp = GetComponent<CanvasGroup>();
        
        canvasGrp.alpha = 1f;
        canvasGrp.interactable = false;
        canvasGrp.blocksRaycasts = false;

        highlightCircle.gameObject.SetActive(false);
    }

    public void SetHighlightTarget(Transform target)
    {
        highlightTarget = target;
        highlightCircle.gameObject.SetActive(true);
    }
    
    public void ManualUpdate(float timeStep)
    {
        if (highlightTarget)
        {
            if (Camera.main != null)
            {
                Vector2 viewportPoint = Camera.main.WorldToViewportPoint(highlightTarget.transform.position);
                
                highlightCircle.anchorMin = viewportPoint;  
                highlightCircle.anchorMax = viewportPoint;
            }
        }
    }
}
