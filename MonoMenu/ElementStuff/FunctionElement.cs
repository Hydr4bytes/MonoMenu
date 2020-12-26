using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

namespace MonoMenu.ElementStuff
{
	public class FunctionElement : MenuElement
	{
		private Action left;
		private Action right;
		private Action trigger;

		public FunctionElement(string text, Color color, Action left, Action right, Action trigger, string subtitleText = "") : base(text, color, subtitleText)
		{
			this.left = left;
			this.right = right;
			this.trigger = trigger;
		}

		public override void OnLeft()
		{
			Action action = this.left;
			if (action == null)
			{
				return;
			}
			action();
		}

		public override void OnRight()
		{
			Action action = this.right;
			if (action == null)
			{
				return;
			}
			action();
		}

		public override void OnTrigger()
		{
			Action action = this.trigger;
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
