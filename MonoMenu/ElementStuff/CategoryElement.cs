using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

namespace MonoMenu.ElementStuff
{
	public class CategoryElement : MenuElement
	{
		private MenuInterface m_Interface;
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

		public MenuInterface GetInterface()
		{
			return this.m_Interface;
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
