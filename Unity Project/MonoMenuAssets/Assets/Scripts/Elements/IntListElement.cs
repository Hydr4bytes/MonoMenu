using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MonoMenu.Elements
{
	public class IntListElement : MenuElement
	{
		private int value;
		private List<int> options;
		private string units;
		private int currentOption;
		private IntListElement.OnValueChanged onValueChanged;
		private delegate void OnValueChanged(int value);

		public IntListElement(string text, Color color, List<int> options, int startValue, string units = "", string subtitleText = "") : base(text, color, subtitleText)
		{
			this.options = options;
			if (options.Contains(startValue))
			{
				this.value = startValue;
			}
			else
			{
				this.value = options[0];
			}
			this.units = units;
		}

		public IntListElement(string text, Color color, List<int> options, int startValue, Action<int> onValueChanged, string units = "", string subtitleText = "") : base(text, color, subtitleText)
		{
			this.options = options;
			if (options.Contains(startValue))
			{
				this.value = startValue;
			}
			else
			{
				this.value = options[0];
			}
			this.onValueChanged = new IntListElement.OnValueChanged(onValueChanged.Invoke);
			this.units = units;
		}

		public void SetUnits(string units)
		{
			this.units = units;
		}

		public string GetUnits()
		{
			return this.units;
		}

		public void SetValue(int value)
		{
			if (this.options.Contains(value))
			{
				this.value = value;
				this.Render(base.textObject);
			}
		}

		public void SetOptions(List<int> options)
		{
			this.options = options;
			this.value = options[0];
			this.Render(base.textObject);
		}

		public List<int> GetOptions()
		{
			return this.options;
		}

		public float GetValue()
		{
			return (float)this.value;
		}

		public override void OnLeft()
		{
			this.currentOption--;
			if (this.currentOption < 0)
			{
				this.currentOption = this.options.Count - 1;
			}
			this.value = this.options[this.currentOption];
			IntListElement.OnValueChanged onValueChanged = this.onValueChanged;
			if (onValueChanged != null)
			{
				onValueChanged(this.value);
			}
			this.Render(base.textObject);
		}

		public override void OnRight()
		{
			this.currentOption++;
			if (this.currentOption == this.options.Count)
			{
				this.currentOption = 0;
			}
			this.value = this.options[this.currentOption];
			IntListElement.OnValueChanged onValueChanged = this.onValueChanged;
			if (onValueChanged != null)
			{
				onValueChanged(this.value);
			}
			this.Render(base.textObject);
		}

		public override TextMeshPro Render(GameObject gameObject)
		{
			return null;
		}
	}
}
