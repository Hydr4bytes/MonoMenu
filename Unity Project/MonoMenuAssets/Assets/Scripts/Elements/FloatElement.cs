using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MonoMenu.Elements
{
	public class FloatElement : MenuElement
	{

		private float value;
		private float minValue;
		private float maxValue;
		private float increment;
		private int decimalRestriction;
		private string units;
		private FloatElement.OnValueChanged onValueChanged;
		private delegate void OnValueChanged(float value);

		public FloatElement(string text, Color color, float minValue, float maxValue, float increment, float startValue, int decimalRestriction, string units = "", string subtitleText = "") : base(text, color, subtitleText)
		{
			this.minValue = minValue;
			this.maxValue = maxValue;
			this.increment = increment;
			this.units = units;
			if (decimalRestriction >= 0)
			{
				this.decimalRestriction = decimalRestriction;
			}
			this.value = startValue;
		}

		public FloatElement(string text, Color color, float minValue, float maxValue, float increment, float startValue, int decimalRestriction, Action<float> onValueChanged, string units = "", string subtitleText = "") : base(text, color, subtitleText)
		{
			this.minValue = minValue;
			this.maxValue = maxValue;
			this.increment = increment;
			this.units = units;
			if (decimalRestriction >= 0)
			{
				this.decimalRestriction = decimalRestriction;
			}
			this.value = startValue;
			this.onValueChanged = new FloatElement.OnValueChanged(onValueChanged.Invoke);
		}

		public void SetUnits(string units)
		{
			this.units = units;
		}

		public string GetUnits()
		{
			return this.units;
		}

		public void SetValue(float value)
		{
			this.value = value;
			this.Render(base.textObject);
		}

		public float GetValue()
		{
			return this.value;
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

		public override void OnLeft()
		{
			float num = this.value;
			num -= this.increment;
			if (num < this.minValue)
			{
				num = this.maxValue;
			}
			num = (float)Math.Round((double)num, this.decimalRestriction);
			this.value = num;
			FloatElement.OnValueChanged onValueChanged = this.onValueChanged;
			if (onValueChanged != null)
			{
				onValueChanged(this.value);
			}
			this.Render(base.textObject);
		}

		public override void OnRight()
		{
			float num = this.value;
			num += this.increment;
			if (num > this.maxValue)
			{
				num = this.minValue;
			}
			num = (float)Math.Round((double)num, this.decimalRestriction);
			this.value = num;
			FloatElement.OnValueChanged onValueChanged = this.onValueChanged;
			if (onValueChanged != null)
			{
				onValueChanged(this.value);
			}
			this.Render(base.textObject);
		}
	}
}
