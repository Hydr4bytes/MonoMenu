using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
		#region Constructors/Destructors
		public Element()
		{

		}

		public Element(string elementName)
		{
			this.elementName = elementName;
		}

		public Element(string elementName, GameObject textObject)
		{
			this.elementName = elementName;
			this.textObject = textObject;
		}

		public Element(string elementName, string subtitleText)
		{
			this.elementName = elementName;
			this.subtitleText = subtitleText;
		}

		public Element(string elementName, GameObject textObject, string subtitleText, GameObject subtitleObject)
		{
			this.elementName = elementName;
			this.textObject = textObject;
			this.subtitleText = subtitleText;
			this.subtitleObject = subtitleObject;
		}

		~Element() { }
		#endregion

		public string elementName = "-";
		public string subtitleText = "";
		public Color color = Color.white;

		public GameObject textObject { get; set; }
		public GameObject subtitleObject { get; set; }

		public bool isButton;

		[SerializeField] private Button elementButton;

		public Button CreateButton(GameObject obj)
		{
			if (elementButton == null) 
				elementButton = obj.AddComponent<Button>();
			else elementButton = obj.GetComponent<Button>();

			return elementButton;
		}

		public Button CreateButton(GameObject obj, UnityAction action)
		{
			if (elementButton == null)
				elementButton = obj.AddComponent<Button>();
			else elementButton = obj.GetComponent<Button>();

			elementButton.onClick.AddListener(() =>
			{
				action.Invoke();
			});

			return elementButton;
		}
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