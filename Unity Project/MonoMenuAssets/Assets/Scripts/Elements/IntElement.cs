using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MonoMenu.Elements
{
	public class IntElement : Element<int>
	{
		private int minValue;
		private int maxValue;
		private int increment;
		private string units;
		private IntElement.OnValueChanged onValueChanged;
		private delegate void OnValueChanged(int value);

		public IntElement(string text, Color color, int minValue, int maxValue, int increment, int startValue, string units = "", string subtitleText = "")
		{
			this.minValue = minValue;
			this.maxValue = maxValue;
			this.increment = increment;
			this.units = units;
			this.value = startValue;
		}

		public IntElement(string text, Color color, int minValue, int maxValue, int increment, int startValue, Action<int> onValueChanged, string units = "", string subtitleText = "")
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
			this.Render(textObject);
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
	}
}
