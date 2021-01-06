using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using MonoMenu.Elements;

public class PanelInterface : MonoBehaviour
{
	public List<Element> elementList = new List<Element>();
	public Dictionary<int, Transform> pages = new Dictionary<int, Transform>();
	public GameObject footer = null;

	private Transform currentGroup { get; set; }
	[SerializeField] private List<GameObject> pageList = new List<GameObject>();
	private int pageIndex;
	private Text pageNumberText;

	private void Start() => Initialize();

	public virtual void Initialize()
	{
		for(int i = 0; i < transform.childCount && transform.parent != null; i++)
		{
			pageList.Add(transform.GetChild(i).gameObject);
			pageList[i].name += i;

			currentGroup = pageList[pageIndex].transform;
		}

		pageNumberText = footer.transform.Find("PageNumber").GetComponent<Text>();
	}

	public virtual void GetAllElements(Transform currentGroup)
	{
		if (currentGroup == null) return;

		for (int i = 0; i < currentGroup.childCount; i++)
		{
			Transform currentChild = currentGroup.GetChild(i);
			elementList.Add(currentChild.gameObject.AddComponent<Element>());
		}
	}

	public void NextPage()
	{
		pageIndex++;
		if (pageIndex > pageList.Count - 1)
			pageIndex = pageList.Count - 1;
	}

	public void PreviousPage()
	{
		pageIndex--;
		if (pageIndex < 0)
			pageIndex = 0;
	}

	private void Update()
	{
		pageNumberText.text = $"PAGE {pageIndex + 1}/{pageList.Count}";

		if (Input.GetKeyDown(KeyCode.A))
			PreviousPage();
		else if (Input.GetKeyDown(KeyCode.D))
			NextPage();

		for(int i = 0; i < pageList.Count; i++)
		{
			if (pageList[pageIndex] == pageList[i])
            {
				if (pageList[i] == null)
                {
					pageList.Remove(pageList[i]);
					PreviousPage();
				}

				//I don't like doing it this way
				for(int j = 0; j < pageList[i].transform.childCount; j++)
                {
					GameObject child = pageList[i].transform.GetChild(j).gameObject;
					Element e = child.GetComponent<Element>();
					Text t = child.GetComponentInChildren<Text>();
					t.text = e.elementName;
					t.color = e.color;
                }

				pageList[i].SetActive(true);
			}
			else
            {
				ResetElementsPosition(pageList[i].transform);
				pageList[i].SetActive(false);
			}
		}
	}

	private void ResetElementsPosition(Transform Page)
	{
		for (int i = 0; i < Page.childCount; i++)
		{
			Transform currentChild = Page.GetChild(i);
			currentChild.localPosition = Vector3.zero;
		}
	}
}
