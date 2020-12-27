using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using MonoMenu.Interfaces;

namespace MonoMenu.Elements
{
	public abstract class MenuElement : Element
	{
		public string text { get; set; }

		public Color color { get; set; }

		public string subtitleText
		{
			get => subtitleText;
			set
			{
				if(this.subtitleText != null) subtitleObject.GetComponent<UnityEngine.UI.Text>().text = this.subtitleText;
			}
		}

		public MenuInterface _Interface;

		public MenuElement(string text, Color color, string subtitleText = "")
		{
			this.text = text;
			this.color = color;
			this.subtitleText = subtitleText;
		}

		public void OnSelect()
		{
			foreach (MenuElement menuElement in _Interface.menuElements)
				menuElement.subtitleObject.SetActive(false);

			if (this.subtitleObject != null)
				this.subtitleObject.SetActive(true);
		}
	}
}
