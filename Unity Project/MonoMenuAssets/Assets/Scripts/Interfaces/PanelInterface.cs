using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonoMenu.Elements;

public class PanelInterface : MonoBehaviour
{
	public List<Element> elementList = new List<Element>();

	private Transform currentGroup { get; set; }
	[SerializeField] private List<GameObject> groupObjects = new List<GameObject>();
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
		// get all objects
		// add elements to specified objects
		// set text options to reflect visuals
	}
}
