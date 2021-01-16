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

		public Element() { }

		public Element(string elementName, GameObject textObject, Transform targetPage)
		{
			this.elementName = elementName;
			this.textObject = textObject;

			this.textObject.transform.localScale = Vector3.one / 1000f;
			this.textObject.transform.SetParent(targetPage);

			this.textObjectTxt.text = elementName;

			UpdateText(textObjectTxt, Font.CreateDynamicFontFromOSFont("Arial", 1), elementName, color, 75);
		}

		~Element() { }
		#endregion

		public string elementName = "Default";
		public Color color = Color.white;

		public GameObject textObject { get; set; }

		protected Text textObjectTxt
		{
			get
			{
				if (textObject.GetComponent<Text>() != null)
				{
					if (textObject.GetComponent<RectTransform>()) textObjectRectTransform = textObject.GetComponent<RectTransform>();
					return _textObjectTxt = textObject.GetComponent<Text>();
				}
				else return textObjectTxt = textObject.AddComponent<Text>();
			}
			set
			{
				_textObjectTxt = value;
			}
		}

		private Text _textObjectTxt;

		private RectTransform textObjectRectTransform = null;

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

		private void UpdateText(Text text, Font font, string title, Color color, TextAnchor alignment = TextAnchor.MiddleLeft)
		{
			if (text == null) return;

			text.text = title;
			text.font = font;
			text.color = color;
			text.alignment = alignment;

			textObjectRectTransform.sizeDelta = new Vector2(1000f, textObjectRectTransform.sizeDelta.y);
		}

		private void UpdateText(Text text, Font font, string title, Color color, int fontSize, TextAnchor alignment = TextAnchor.MiddleLeft)
		{
			if (text == null) return;

			text.text = title;
			text.font = font;
			text.color = color;
			text.fontSize = fontSize;
			text.alignment = alignment;

			textObjectRectTransform.sizeDelta = new Vector2(1000f, textObjectRectTransform.sizeDelta.y);
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