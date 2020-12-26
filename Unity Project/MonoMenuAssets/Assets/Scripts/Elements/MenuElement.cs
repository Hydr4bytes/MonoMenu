using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using MonoMenu.Interfaces;

namespace MonoMenu.Elements
{
	public abstract class MenuElement
	{
		private string text;
		private string subtitleText;
		private Color color;
		private GameObject textObject;
		private GameObject subtitleObject;
		public MenuInterface _Interface;

		public MenuElement(string text, Color color, string subtitleText = "")
		{
			this.text = text;
			this.color = color;
			this.subtitleText = subtitleText;
		}

		public void SetTextObject(GameObject gameObject)
		{
			this.textObject = gameObject;
		}

		public GameObject GetTextObject()
		{
			return this.textObject;
		}

		public void SetSubtitleObject(GameObject gameObject)
		{
			this.subtitleObject = gameObject;
		}

		public GameObject GetSubtitleObject()
		{
			return this.subtitleObject;
		}

		public void SetText(string text)
		{
			this.text = text;
		}

		public string GetText()
		{
			return this.text;
		}

		public void SetSubtitleText(string text)
		{
			this.subtitleText = text;
			if (this.subtitleObject != null)
			{
				subtitleObject.GetComponent<TextMeshPro>().SetText(this.subtitleText);
			}
		}

		public string GetSubtitleText()
		{
			return this.subtitleText;
		}

		public void SetColor(Color color)
		{
			this.color = color;
		}

		public Color GetColor()
		{
			return this.color;
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
