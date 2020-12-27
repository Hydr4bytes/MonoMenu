using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using MonoMenu.Interfaces;

namespace MonoMenu.Elements
{
	public abstract class MenuElement : MonoBehaviour
	{
		public Color color { get; set; }
		public string text { get; set; }
		public GameObject textObject { get; set; }
		public GameObject subtitleObject { get; set; }
		public string subtitleText
		{
			get => subtitleText;
			set
			{
				if(this.subtitleText != null)
					subtitleObject.GetComponent<UnityEngine.UI.Text>().text = this.subtitleText;
			}
		}

		public MenuInterface _Interface;

		public MenuElement(string text, Color color, string subtitleText = "")
		{
			this.text = text;
			this.color = color;
			this.subtitleText = subtitleText;
		}

		public abstract TextMeshPro Render(GameObject gameObject);

		public virtual void OnTrigger() { }

		public virtual void OnRight() { }

		public virtual void OnLeft() { }

		public void OnSelect()
		{
			foreach (MenuElement menuElement in _Interface.menuElements)
			{
				menuElement.subtitleObject.SetActive(false);
			}
			if (this.subtitleObject != null)
			{
				this.subtitleObject.SetActive(true);
			}
		}
	}
}
