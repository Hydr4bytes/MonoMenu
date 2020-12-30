using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonoMenu.Elements;

public class PanelInterface : MonoBehaviour
{
	public List<Element> elementList = new List<Element>();

	private Transform currentGroup { get; set; }
	[SerializeField] private List<Transform> groups = new List<Transform>();

	private void Awake()
	{
		currentGroup = transform.Find("Group");
		GetAllElements(currentGroup);
	}

	public void GetAllElements(Transform currentGroup)
	{
		if (currentGroup == null) return;
		// TODO
		// get all objects in the group
		foreach(Transform t in currentGroup.GetComponentsInChildren<Transform>())
		{
			if (!t.name.Contains("Group"))
			{
				Element element = t.gameObject.AddComponent<Element>();
				t.GetComponent<UnityEngine.UI.Text>().text = element.elementName;
				t.GetComponent<UnityEngine.UI.Text>().color = element.color;
			}
		}
		// add elements to specified objects
		// set text options to reflect visuals
	}
}
