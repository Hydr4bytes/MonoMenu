using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MonoMenu.Elements;

using TMPro;

namespace MonoMenu.Elements
{
	/// <summary>
	/// Element instance. This will be drawn and shown by the MenuInterface.
	/// It contains the name, color, and subtitle text.
	/// </summary>
	[System.Serializable]
	public class Element : MonoBehaviour
	{
		public string elementName = "-";
		public Color color = Color.white;
		public string subtitleText = "";

		public GameObject textObject { get; set; }
		public GameObject subtitleObject { get; set; }
	}

	/// <summary>
	/// Create a new Element instance in which you can set a type.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[System.Serializable]
	public class ElementGeneric<T> : Element
	{
		// stuff that depends on the type

		public T value
		{
			get
			{
				return value;
			}
		}
	}
}