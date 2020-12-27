using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MonoMenu.Elements
{
	public class FloatListElement : Element
	{
		private float value;
		private List<float> options;
		private string units;
		private int currentOption;
		private FloatListElement.OnValueChanged onValueChanged;
		private delegate void OnValueChanged(float value);

		public FloatListElement(string text, Color color, List<float> options, float startValue, string units = "", string subtitleText = "") : base(text, color, subtitleText)
		{
			this.options = options;

			if (options.Contains(startValue)) this.value = startValue; else this.value = options[0];

			this.units = units;
		}

		public FloatListElement(string text, Color color, List<float> options, float startValue, Action<float> onValueChanged, string units = "", string subtitleText = "") : base(text, color, subtitleText)
		{
			this.options = options;
			if (options.Contains(startValue)) this.value = startValue; else this.value = options[0];

			this.onValueChanged = new FloatListElement.OnValueChanged(onValueChanged.Invoke);
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

		public void SetValue(float value)
		{
			if (this.options.Contains(value))
			{
				this.value = value;
				this.Render(base.textObject);
			}
		}

		public void SetOptions(List<float> options)
		{
			this.options = options;
			this.value = options[0];
			this.Render(base.textObject);
		}

		public List<float> GetOptions()
		{
			return this.options;
		}

		public float GetValue()
		{
			return this.value;
		}

		public override void OnLeft()
		{
			this.currentOption--;
			if (this.currentOption < 0)
			{
				this.currentOption = this.options.Count - 1;
			}
			this.value = this.options[this.currentOption];
			FloatListElement.OnValueChanged onValueChanged = this.onValueChanged;
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
			FloatListElement.OnValueChanged onValueChanged = this.onValueChanged;
			if (onValueChanged != null)
			{
				onValueChanged(this.value);
			}
			this.Render(base.textObject);
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
	}
}
