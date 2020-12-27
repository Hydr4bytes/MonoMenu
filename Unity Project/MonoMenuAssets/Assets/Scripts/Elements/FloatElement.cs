using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MonoMenu.Elements
{
	public class FloatElement : Element<float>
	{
		private float minValue;
		private float maxValue;
		private float increment;
		private int decimalRestriction;
		private string units;
		private FloatElement.OnValueChanged onValueChanged;
		private delegate void OnValueChanged(float value);

		public FloatElement(string text, Color color, float minValue, float maxValue, float increment, float startValue, int decimalRestriction, string units = "", string subtitleText = "")
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

		public FloatElement(string text, Color color, float minValue, float maxValue, float increment, float startValue, int decimalRestriction, Action<float> onValueChanged, string units = "", string subtitleText = "")
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
			return null;
		}
	}
}
