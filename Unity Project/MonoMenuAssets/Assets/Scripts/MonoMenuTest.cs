using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonoMenu.Elements;
using MonoMenu.Interfaces;

public class MonoMenuTest : MonoBehaviour
{
	public static List<MenuInterface> interfaces = new List<MenuInterface>();
	public GameObject bundle;

	private static MenuInterface selectedMenu;

	private void Awake()
	{
		bundle = CreateInterface();
		if (bundle) print("MonoMenu added.");
	}

	private GameObject CreateInterface()
	{
		GameObject asset = new GameObject();
		asset.SetActive(false);
		return asset;
	}
}
