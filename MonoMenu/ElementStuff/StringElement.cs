using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

namespace MonoMenu.ElementStuff
{
	public class StringElement : MenuElement
	{
		private string value;
		private int currentOption;
		private List<string> options = new List<string>();
		private StringElement.OnValueChanged onValueChanged;
		private delegate void OnValueChanged(string value);

		public StringElement(string text, Color color, List<string> options, string startValue, string subtitleText = "") : base(text, color, subtitleText)
		{
			this.options = options;
			if (options.Contains(startValue))
			{
				this.value = startValue;
				return;
			}
			this.value = options[0];
		}

		public StringElement(string text, Color color, List<string> options, string startValue, Action<string> onValueChanged, string subtitleText = "") : base(text, color, subtitleText)
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
			this.onValueChanged = new StringElement.OnValueChanged(onValueChanged.Invoke);
		}

		public void SetOptions(List<string> options)
		{
			this.options = options;
			this.value = options[0];
			this.Render(base.GetTextObject());
		}

		public List<string> GetOptions()
		{
			return this.options;
		}

		public void SetValue(string value)
		{
			if (this.options.Contains(value))
			{
				this.value = value;
			}
			this.Render(base.GetTextObject());
		}

		public override void OnLeft()
		{
			this.currentOption--;
			if (this.currentOption < 0)
			{
				this.currentOption = this.options.Count - 1;
			}
			this.value = this.options[this.currentOption];
			StringElement.OnValueChanged onValueChanged = this.onValueChanged;
			if (onValueChanged != null)
			{
				onValueChanged(this.value);
			}
			this.Render(base.GetTextObject());
		}

		public override void OnRight()
		{
			this.currentOption++;
			if (this.currentOption == this.options.Count)
			{
				this.currentOption = 0;
			}
			this.value = this.options[this.currentOption];
			StringElement.OnValueChanged onValueChanged = this.onValueChanged;
			if (onValueChanged != null)
			{
				onValueChanged(this.value);
			}
			this.Render(base.GetTextObject());
		}

		public string GetValue()
		{
			return this.value;
		}

		public override TextMeshPro Render(GameObject gameObject)
		{
			//return EasyMenu.createText(gameObject, 0, 0f, Color.black, base.GetColor(), 0.4f, EasyMenu.margin, base.GetText());
			return null;
		}
	}
}
