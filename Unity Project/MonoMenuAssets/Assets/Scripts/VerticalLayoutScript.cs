﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerticalLayoutScript : LayoutGroup
{
    public AnimationCurve curve;

    public float Distance;
    public float PaddingLeft;
    public float PaddingTop;

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
            if(transform.GetChild(i).GetComponent<RectTransform>() == null) return;
            RectTransform child = transform.GetChild(i).GetComponent<RectTransform>();

            if (child != null)
            {
                m_Tracker.Add(this, child, DrivenTransformProperties.Anchors | DrivenTransformProperties.AnchoredPosition | DrivenTransformProperties.Pivot);
                Vector3 P = new Vector3(StartX + PaddingLeft, (Distance * -i) - PaddingTop, child.position.z);
                //child.localPosition = Vector3.Lerp(child.localPosition, P, Time.deltaTime * 5);
                child.localPosition += (P - child.localPosition) * curve.Evaluate(Time.deltaTime * 60);
                child.anchorMin = child.anchorMax = child.pivot = new Vector2(0.5f, 0.5f);
            }
        }
    }

    private void Update()
    {
        CalculateLayout();
    }
}