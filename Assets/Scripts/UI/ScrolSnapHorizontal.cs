using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollSnapHorizontal : MonoBehaviour
{
    public RectTransform panel;
    public Image[] bttn;
    public RectTransform center;
    public Button start;

    private float[] distance;
    private bool dragging = false;
    private int bttnDistance;
    static public int minButtonNum;



    // Start is called before the first frame update
    void Start()
    {
        distance = new float[bttn.Length];

        bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < bttn.Length; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - bttn[i].transform.position.x);
        }

        float minDistance = Mathf.Min(distance);

        for (int i = 0; i < bttn.Length; i++)
        {
            if (minDistance == distance[i])
            {
                minButtonNum = i;
            }
        }

        if (!dragging)
        {
            LerpToBttn(minButtonNum * -bttnDistance);
        }

        if (panel.CompareTag("Ball"))
        {
                SpriteController_Ball.bSpriteIndex = minButtonNum;  
        }
        
        

    }

    void LerpToBttn(int position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 10f);
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);
        panel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }

}
