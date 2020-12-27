using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using MonoMenu.Interfaces;

namespace MonoMenu.Elements
{
	public class CategoryElement : MenuElement
	{
		public MenuInterface m_Interface { get; }
		private Action onOpen;

		public CategoryElement(string text, Color color, MenuInterface category, MenuInterface parentInterface, string subtitleText = "") : base(text, color, subtitleText)
		{
			this.m_Interface = category;
			this.m_Interface.parentInterface = parentInterface;
		}

		public CategoryElement(string text, Color color, MenuInterface category, MenuInterface parentInterface, Action onOpen, string subtitleText = "") : base(text, color, subtitleText)
		{
			this.m_Interface = category;
			this.m_Interface.parentInterface = parentInterface;
			this.onOpen = onOpen;
		}

		public override void OnTrigger()
		{
			this._Interface.CloseMenu();
			//EasyMenu.setSelectedMenu(this.m_Interface);
			this.m_Interface.OpenMenu();
			Action action = this.onOpen;
			if (action == null)
			{
				return;
			}
			action();
		}

		public override TextMeshPro Render(GameObject gameObject)
		{
			//return EasyMenu.createText(gameObject, 0, 0f, Color.black, base.GetColor(), 0.4f, EasyMenu.margin, base.GetText());
			return null;
		}
	}
}
