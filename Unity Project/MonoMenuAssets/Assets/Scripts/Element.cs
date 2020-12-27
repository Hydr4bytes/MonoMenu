using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MonoMenu.Elements;
using MonoMenu.Interfaces;

using TMPro;

namespace MonoMenu.Elements
{
	public abstract class Element : MonoBehaviour
	{
		public Element() { }
		public Element(string text) { }
		public Element(string text, Color color) { }
		public Element(string text, Color color, string subtitleText) { }

		// stuff that doesn't depend on the type
		public GameObject textObject { get; set; }
		public GameObject subtitleObject { get; set; }

		public virtual void OnLeft() { }
		public virtual void OnRight() { }
		public virtual void OnTrigger() { }

		public virtual TextMeshPro Render(GameObject gameObject)
		{
			return null;
		}
	}

	public abstract class Element<T> : Element
	{
		// stuff that depends on the type
		public virtual T value { get; set; }
	}
}

