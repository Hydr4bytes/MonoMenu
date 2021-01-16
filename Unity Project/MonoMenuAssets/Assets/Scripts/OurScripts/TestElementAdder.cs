using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using MonoMenu.Elements;


public class TestElementAdder : MonoBehaviour
{
	public Transform targetPage;
	public int howManyElements;

	[SerializeField] private string[] elementNames = new string[] { "What", "ModThatIsMod", "EasyMenu", "Personalized" };

	private void Awake()
	{
		for(int i = 0; i < howManyElements && targetPage != null; i++)
		{
			Element element = new Element(elementNames[Random.Range(0, elementNames.Length)], new GameObject("Element"), targetPage);
		}
	}
}
