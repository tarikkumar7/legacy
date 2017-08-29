﻿/*
   Copyright 2006-2017 Cryptany, Inc.

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Cryptany.Core.DPO.MetaObjects.DynamicEntityBuilding
{
	public class DynamicEntityAttributeDescriptionCollection : Dictionary<string, DynamicEntityAttributeDescription>
	{
	}

	public class DynamicEntityAttributeDescription
	{
		private string _name;
		private string _paramaters;

		public static DynamicEntityAttributeDescription Create(XmlNode node)
		{
			DynamicEntityAttributeDescription attribute = new DynamicEntityAttributeDescription();

			if ( node.Name != "Attribute" )
			{
				DynamicEntityBuildingError err = new DynamicEntityBuildingError(ErrorType.InvalidXmlDocument, "A start element expected");
				return null;
			}
			attribute._name = node.Attributes["name"].InnerXml;

			attribute._paramaters = node.InnerXml;

			return attribute;
		}

		private DynamicEntityAttributeDescription()
		{
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public string Paramaters
		{
			get
			{
				return _paramaters;
			}
		}

		public string Compile()
		{
			string code = "";
			code = "[" + Name;
			if ( Paramaters != null && Paramaters != "" )
				code += "(" + Paramaters + ")";
			code += "]";
			return code;
		}
	}
}
