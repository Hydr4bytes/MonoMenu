using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MonoMenu.Elements;
using MonoMenu.Interfaces;

namespace MonoMenu.Elements
{
	public class Element<ElementType>
	{
		public string elementText;

		public ElementType type { get; }
	}
}

