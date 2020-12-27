using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonoMenu.Elements;

public class MonoMenuTest : MonoBehaviour
{
	public GameObject bundle;

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
