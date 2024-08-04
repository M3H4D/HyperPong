using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollSnapVertical : MonoBehaviour
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

        bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.y - bttn[0].GetComponent<RectTransform>().anchoredPosition.y);
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < bttn.Length; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.y - bttn[i].transform.position.y);

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
            LerpToBttn(minButtonNum * bttnDistance);
        }

        if (panel.CompareTag("Paddle1"))
        {
            
            SpriteController_Paddles.p1SpriteIndex = minButtonNum;
            
        }
        else if (panel.CompareTag("Paddle2"))
        { 
            SpriteController_Paddles.p2SpriteIndex = minButtonNum; 
        }
     

    }

    void LerpToBttn(int position)
    {
        float newY = Mathf.Lerp(panel.anchoredPosition.y, position, Time.deltaTime * 10f);
        Vector2 newPosition = new Vector2(panel.anchoredPosition.x, newY);
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
