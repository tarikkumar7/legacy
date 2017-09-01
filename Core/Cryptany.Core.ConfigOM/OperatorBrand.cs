/*
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
using Cryptany.Core.DPO;
using Cryptany.Core.DPO.MetaObjects.Attributes;

namespace Cryptany.Core.ConfigOM
{
	[DbSchema("kernel")]
	[Table("OperatorBrands")]
	public class OperatorBrand : EntityBase
	{
		public string Name
		{
			get
			{
				return GetValue<string>("Name");
			}
			set
			{
				SetValue("Name", value);
			}
		}

		[Relation( RelationType.OneToMany, typeof(Operator), "Brand")]
		public EntityList<Operator> Operators
		{
			get
			{
				return GetValue<EntityList<Operator>>("Operators");
			}
			set
			{
				SetValue("Operators", value);
			}
		}
	}
}
