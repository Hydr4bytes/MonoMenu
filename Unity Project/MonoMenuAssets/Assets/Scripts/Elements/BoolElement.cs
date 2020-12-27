﻿using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MonoMenu.Elements
{
	public class BoolElement : MenuElement
	{
		private bool value;
		private BoolElement.OnValueChanged onValueChanged;
		private delegate void OnValueChanged(bool value);

		public BoolElement(string text, Color color, bool startValue, string subtitleText = "") : base(text, color, subtitleText)
		{
			this.value = startValue;
		}

		public BoolElement(string text, Color color, bool startValue, Action<bool> onValueChanged, string subtitleText = "") : base(text, color, subtitleText)
		{
			this.value = startValue;
			this.onValueChanged = new BoolElement.OnValueChanged(onValueChanged.Invoke);
		}

		public override TextMeshPro Render(GameObject gameObject)
		{
			//return EasyMenu.createText(gameObject, 0, 0f, Color.black, base.GetColor(), 0.4f, EasyMenu.margin, base.GetText() + ": " + this.value.ToString());
			return null;
		}

		public bool GetValue()
		{
			return this.value;
		}

		public void SetValue(bool value)
		{
			this.value = value;
			this.Render(base.textObject);
		}

		public override void OnLeft()
		{
			this.value = !this.value;
			BoolElement.OnValueChanged onValueChanged = this.onValueChanged;
			if (onValueChanged != null)
			{
				onValueChanged(this.value);
			}
			this.Render(base.textObject);
		}

		public override void OnRight()
		{
			this.value = !this.value;
			BoolElement.OnValueChanged onValueChanged = this.onValueChanged;
			if (onValueChanged != null)
			{
				onValueChanged(this.value);
			}
			this.Render(base.textObject);
		}
	}
}
