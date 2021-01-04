using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerticalLayoutScript : LayoutGroup
{
    public AnimationCurve curve;

    public float Distance;
    public float PaddingLeft;
    public float PaddingTop;
    //public float LerpSpeed;

    public override void SetLayoutHorizontal() { }
    public override void SetLayoutVertical() { }
    public override void CalculateLayoutInputVertical() { } // => CalculateLayout();
    public override void CalculateLayoutInputHorizontal() { } // => CalculateLayout();

    void CalculateLayout()
    {
        Vector3[] Corners = new Vector3[4];
        rectTransform.GetLocalCorners(Corners);

        float StartX = GetStartOffset(0, 10);
        float StartY = GetStartOffset(1, 10);

        for (int i = 0; i < transform.childCount; i++)
        {
            RectTransform child = (RectTransform)transform.GetChild(i);
            if (child != null)
            {
                m_Tracker.Add(this, child, DrivenTransformProperties.Anchors | DrivenTransformProperties.AnchoredPosition | DrivenTransformProperties.Pivot);
                Vector3 P = new Vector3(StartX + PaddingLeft, (Distance * -i) - PaddingTop, child.position.z);
                //child.localPosition = Vector3.Lerp(child.localPosition, P, Time.deltaTime * LerpSpeed);
                child.localPosition += (P - child.localPosition) * curve.Evaluate(Time.time);
                child.anchorMin = child.anchorMax = child.pivot = new Vector2(0.5f, 0.5f);
            }
        }
    }

    private void Update()
    {
        CalculateLayout();
    }
}