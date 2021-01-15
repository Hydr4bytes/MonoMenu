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

			UpdateText(textObjectTxt, null, elementName, color, 50);
		}

		public Element(string elementName, GameObject textObject)
		{
			this.elementName = elementName;
			this.textObject = textObject;

			this.textObjectTxt.text = elementName;

			UpdateText(textObjectTxt, null, elementName, color, 50);
		}

		public Element(string elementName, string subtitleText)
		{
			this.elementName = elementName;
			this.subtitleText = subtitleText;

			this.textObjectTxt.text = elementName;
			this.subtitleObjectTxt.text = subtitleText;

			UpdateText(textObjectTxt, null, elementName, color, 50);
			UpdateText(textObjectTxt, null, subtitleText, color, 50);
		}

		public Element(string elementName, GameObject textObject, string subtitleText, GameObject subtitleObject)
		{
			this.elementName = elementName;
			this.textObject = textObject;

			this.subtitleText = subtitleText;
			this.subtitleObject = subtitleObject;

			UpdateText(textObjectTxt, null, elementName, color, 50);
			UpdateText(textObjectTxt, null, subtitleText, color, 50);
		}

		~Element() { }
		#endregion

		public string elementName = "Default";
		public string subtitleText = "";
		public Color color = Color.white;

		public GameObject textObject { get; set; }
		public GameObject subtitleObject { get; set; }

		protected Text textObjectTxt
		{
			get
			{
				if (textObject.GetComponent<Text>() != null)
					return _textObjectTxt = textObject.GetComponent<Text>();
				else return textObjectTxt = textObject.AddComponent<Text>();
			}
			set
			{
				_textObjectTxt = value;
			}
		}
		protected Text subtitleObjectTxt
		{
			get
			{
				if (subtitleObject.GetComponent<Text>() != null)
					return _subtitleObjectTxt = subtitleObject.GetComponent<Text>();
				else return _subtitleObjectTxt = subtitleObject.AddComponent<Text>();
			}
			set
			{
				_subtitleObjectTxt = value;
			}
		}

		private Text _textObjectTxt;
		private Text _subtitleObjectTxt;

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

		private void UpdateText(Text text, Font font, string title, Color color, TextAnchor alignment = TextAnchor.MiddleCenter)
		{
			if (text == null) return;

			text.text = title;
			text.font = font;
			text.color = color;
			text.alignment = alignment;
		}

		private void UpdateText(Text text, Font font, string title, Color color, int fontSize, TextAnchor alignment = TextAnchor.MiddleCenter)
		{
			if (text == null) return;

			text.text = title;
			text.font = font;
			text.color = color;
			text.fontSize = fontSize;
			text.alignment = alignment;
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