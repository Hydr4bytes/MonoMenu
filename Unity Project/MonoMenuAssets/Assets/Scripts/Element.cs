using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MonoMenu.Elements;

using TMPro;

namespace MonoMenu.Elements
{
	public class Element : MonoBehaviour
	{
		public Element() 
		{ 

		}

		public Element(string text) 
		{
			this.elementName = text;
		}

		public Element(string text, Color color) 
		{
			this.elementName = text;
			this.color = color;
		}

		public Element(string text, Color color, string subtitleText) 
		{
			this.elementName = text;
			this.color = color;
			this.subtitleText = subtitleText;
		}

		public string elementName = "-";
		public Color color = Color.white;
		public string subtitleText = "";

		public GameObject textObject { get; set; }
		public GameObject subtitleObject { get; set; }
	}

	public class ElementGeneric<T> : Element
	{
		// stuff that depends on the type
		public virtual T value { get; set; }
	}

	public class OpenElementGeneric<T> : ElementGeneric<T> { }
}

