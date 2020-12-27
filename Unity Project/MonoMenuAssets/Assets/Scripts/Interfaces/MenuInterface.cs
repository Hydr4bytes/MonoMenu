using System;
using System.Collections.Generic;
using UnityEngine;

using MonoMenu.Elements;

namespace MonoMenu.Interfaces
{
	public class MenuInterface : MonoBehaviour
	{
		private string subtitleText;

		private List<CategoryElement> categoryElements = new List<CategoryElement>();

		public MenuInterface parentInterface;

		private GameObject menuObject;

		private GameObject subtitleObject;

		public string text { get; }
		public Color color { get; }
		public List<MenuElement> menuElements { get; }

		public MenuInterface(string title, Color color, string subtitleText = "")
		{
			text = title;
			this.color = color;
			menuElements = new List<MenuElement>();
			this.subtitleText = subtitleText;
		}

		public GameObject GetMenuObject()
		{
			return menuObject;
		}

		public void SetMenuObject(GameObject gameObject)
		{
			menuObject = gameObject;
		}

		public string GetSubtitleText()
		{
			return subtitleText;
		}

		public void SetSubtitleText(string text)
		{
			subtitleText = text;
		}

		public void SetSubtitleObject(GameObject gameObject)
		{
			subtitleObject = gameObject;
		}

		public GameObject GetSubtitleObject()
		{
			return this.subtitleObject;
		}

		public void RenderMenu()
		{
			if (menuObject)
			{
				GameObject MenuTitle = new GameObject("MenuTitle");
				foreach (MenuElement menuElement in this.menuElements)
				{
					
				}
			}
		}

		public void OpenMenu()
		{
			this.showMenu();
		}

		public void CloseMenu()
		{
			this.hideMenu();
			foreach (MenuElement menuElement in this.menuElements)
			{
				menuElement.subtitleObject.SetActive(false);
			}
			foreach (CategoryElement categoryElement in this.categoryElements)
			{
				categoryElement.m_Interface.CloseMenu();
			}
		}

		private void showMenu()
		{
			if (this.menuObject)
			{
				this.menuObject.SetActive(true);
			}
		}

		private void hideMenu()
		{
			if (this.menuObject)
			{
				this.menuObject.SetActive(false);
			}
		}

		#region Constructors (OLD)
		/*public IntElement CreateIntElement(string text, Color color, int minValue, int maxValue, int increment, int startValue, string units = "", string subtitleText = "")
		{
			IntElement intElement = new IntElement(text, color, minValue, maxValue, increment, startValue, units, subtitleText);
			this.SetElementInterface(intElement);
			this.menuElements.Add(intElement);
			return intElement;
		}

		public IntElement CreateIntElement(string text, Color color, int minValue, int maxValue, int increment, int startValue, Action<int> onValueChanged, string units = "", string subtitleText = "")
		{
			IntElement intElement = new IntElement(text, color, minValue, maxValue, increment, startValue, onValueChanged, units, subtitleText);
			this.SetElementInterface(intElement);
			this.menuElements.Add(intElement);
			return intElement;
		}

		public IntListElement CreateIntListElement(string text, Color color, List<int> options, int startValue, string units = "", string subtitleText = "")
		{
			IntListElement intListElement = new IntListElement(text, color, options, startValue, units, subtitleText);
			this.SetElementInterface(intListElement);
			this.menuElements.Add(intListElement);
			return intListElement;
		}

		public IntListElement CreateIntListElement(string text, Color color, List<int> options, int startValue, Action<int> onValueChanged, string units = "", string subtitleText = "")
		{
			IntListElement intListElement = new IntListElement(text, color, options, startValue, onValueChanged, units, subtitleText);
			this.SetElementInterface(intListElement);
			this.menuElements.Add(intListElement);
			return intListElement;
		}

		public FloatElement CreateFloatElement(string text, Color color, float minValue, float maxValue, float increment, float startValue, int decimalRestriction, string units = "", string subtitleText = "")
		{
			FloatElement floatElement = new FloatElement(text, color, minValue, maxValue, increment, startValue, decimalRestriction, units, subtitleText);
			this.SetElementInterface(floatElement);
			this.menuElements.Add(floatElement);
			return floatElement;
		}

		public FloatElement CreateFloatElement(string text, Color color, float minValue, float maxValue, float increment, float startValue, int decimalRestriction, Action<float> onValueChanged, string units = "", string subtitleText = "")
		{
			FloatElement floatElement = new FloatElement(text, color, minValue, maxValue, increment, startValue, decimalRestriction, onValueChanged, units, subtitleText);
			this.SetElementInterface(floatElement);
			this.menuElements.Add(floatElement);
			return floatElement;
		}

		public FloatListElement CreateFloatListElement(string text, Color color, List<float> options, float startValue, string units = "", string subtitleText = "")
		{
			FloatListElement floatListElement = new FloatListElement(text, color, options, startValue, units, subtitleText);
			this.SetElementInterface(floatListElement);
			this.menuElements.Add(floatListElement);
			return floatListElement;
		}

		public FloatListElement CreateFloatListElement(string text, Color color, List<float> options, float startValue, Action<float> onValueChanged, string units = "", string subtitleText = "")
		{
			FloatListElement floatListElement = new FloatListElement(text, color, options, startValue, onValueChanged, units, subtitleText);
			this.SetElementInterface(floatListElement);
			this.menuElements.Add(floatListElement);
			return floatListElement;
		}

		public BoolElement CreateBoolElement(string text, Color color, bool startValue, string subtitleText = "")
		{
			BoolElement boolElement = new BoolElement(text, color, startValue, subtitleText);
			this.SetElementInterface(boolElement);
			this.menuElements.Add(boolElement);
			return boolElement;
		}

		public BoolElement CreateBoolElement(string text, Color color, bool startValue, Action<bool> onValueChanged, string subtitleText = "")
		{
			BoolElement boolElement = new BoolElement(text, color, startValue, onValueChanged, subtitleText);
			this.SetElementInterface(boolElement);
			this.menuElements.Add(boolElement);
			return boolElement;
		}

		public StringElement CreateStringElement(string text, Color color, List<string> options, string startValue = "", string subtitleText = "")
		{
			StringElement stringElement = new StringElement(text, color, options, startValue, subtitleText);
			this.SetElementInterface(stringElement);
			this.menuElements.Add(stringElement);
			return stringElement;
		}

		public StringElement CreateStringElement(string text, Color color, List<string> options, Action<string> onValueChanged, string startValue = "", string subtitleText = "")
		{
			StringElement stringElement = new StringElement(text, color, options, startValue, onValueChanged, subtitleText);
			this.SetElementInterface(stringElement);
			this.menuElements.Add(stringElement);
			return stringElement;
		}

		public FunctionElement CreateFunctionElement(string text, Color color, Action left, Action right, Action trigger)
		{
			FunctionElement functionElement = new FunctionElement(text, color, left, right, trigger, "");
			this.SetElementInterface(functionElement);
			this.menuElements.Add(functionElement);
			return functionElement;
		}

		public FunctionElement CreateFunctionElement(string text, Color color, Action left, Action right, Action trigger, string subtitleText)
		{
			FunctionElement functionElement = new FunctionElement(text, color, left, right, trigger, subtitleText);
			this.SetElementInterface(functionElement);
			this.menuElements.Add(functionElement);
			return functionElement;
		}

		public CategoryElement CreateCategoryElement(string text, Color color, MenuInterface categoryInterface, string subtitleText = "")
		{
			CategoryElement categoryElement = new CategoryElement(text, color, categoryInterface, this, subtitleText);
			this.categoryElements.Add(categoryElement);
			this.SetElementInterface(categoryElement);
			this.menuElements.Add(categoryElement);
			return categoryElement;
		}

		public CategoryElement CreateCategoryElement(string text, Color color, MenuInterface categoryInterface, Action onOpen, string subtitleText = "")
		{
			CategoryElement categoryElement = new CategoryElement(text, color, categoryInterface, this, onOpen, subtitleText);
			this.categoryElements.Add(categoryElement);
			this.SetElementInterface(categoryElement);
			this.menuElements.Add(categoryElement);
			return categoryElement;
		}*/

		#endregion

		private void SetElementInterface(MenuElement element)
		{
			element._Interface = this;
		}

		public void RemoveMenuElement(MenuElement element)
		{
			if (this.menuElements.Contains(element))
			{
				this.menuElements.Remove(element);
				GameObject.Destroy(element.textObject);
				return;
			}
		}
	}
}
