using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    [SerializeField] bool isDestroyOnClose = false;
    private void Awake()
    {
        RectTransform rect = GetComponent<RectTransform>();
        float ratio = (float)Screen.width / (float)Screen.height;
        if(ratio >2.1f)
        {
            Vector2 leftBottom = rect.offsetMin;
            Vector3 rightTop =  rect.offsetMax;
            leftBottom.y = 0;
            rightTop.y = -100f;
            rect.offsetMin = leftBottom;
            rect.offsetMax = rightTop;
        }
    }
    public virtual void SetUp()
    {
    }
    public virtual void Open()
    {
        gameObject.SetActive(true);
    }
    public virtual void Close(float time)
    {
        Invoke(nameof(CloseDirectly),time);
       
    }
    public virtual void CloseDirectly()
    {
        gameObject.SetActive(false);
        if (isDestroyOnClose) Destroy(this);
    }
}
