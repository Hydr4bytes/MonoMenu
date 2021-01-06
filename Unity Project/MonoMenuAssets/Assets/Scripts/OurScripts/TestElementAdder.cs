using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using MonoMenu.Elements;


public class TestElementAdder : MonoBehaviour
{
	public Transform targetPage;

	private void Awake()
	{
		GameObject test = new GameObject("Element");
		test.transform.SetParent(targetPage);
	}
}
