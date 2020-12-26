using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MonoMenu.Elements
{
	public class IntElement : MenuElement
	{
		private int value;
		private int minValue;
		private int maxValue;
		private int increment;
		private string units;
		private IntElement.OnValueChanged onValueChanged;
		private delegate void OnValueChanged(int value);

		public IntElement(string text, Color color, int minValue, int maxValue, int increment, int startValue, string units = "", string subtitleText = "") : base(text, color, subtitleText)
		{
			this.minValue = minValue;
			this.maxValue = maxValue;
			this.increment = increment;
			this.units = units;
			this.value = startValue;
		}

		public IntElement(string text, Color color, int minValue, int maxValue, int increment, int startValue, Action<int> onValueChanged, string units = "", string subtitleText = "") : base(text, color, subtitleText)
		{
			this.minValue = minValue;
			this.maxValue = maxValue;
			this.increment = increment;
			this.units = units;
			this.value = startValue;
			this.onValueChanged = new IntElement.OnValueChanged(onValueChanged.Invoke);
		}

		public void SetValue(int value)
		{
			this.value = value;
			this.Render(base.GetTextObject());
		}

		public int GetValue()
		{
			return this.value;
		}

		public void SetUnits(string units)
		{
			this.units = units;
		}

		public string GetUnits()
		{
			return this.units;
		}

		public override TextMeshPro Render(GameObject gameObject)
		{
			/*
			return EasyMenu.createText(gameObject, 0, 0f, Color.black, base.GetColor(), 0.4f, EasyMenu.margin, string.Concat(new string[]
			{
				base.GetText(),
				": ",
				this.value.ToString(),
				" ",
				this.units
			}));
			*/
			return null;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003D60 File Offset: 0x00001F60
		public override void OnLeft()
		{
			int num = this.value;
			num -= this.increment;
			if (num < this.minValue)
			{
				num = this.maxValue;
			}
			this.value = num;
			IntElement.OnValueChanged onValueChanged = this.onValueChanged;
			if (onValueChanged != null)
			{
				onValueChanged(this.value);
			}
			this.Render(base.GetTextObject());
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00003DB8 File Offset: 0x00001FB8
		public override void OnRight()
		{
			int num = this.value;
			num += this.increment;
			if (num > this.maxValue)
			{
				num = this.minValue;
			}
			this.value = num;
			IntElement.OnValueChanged onValueChanged = this.onValueChanged;
			if (onValueChanged != null)
			{
				onValueChanged(this.value);
			}
			this.Render(base.GetTextObject());
		}
	}
}
