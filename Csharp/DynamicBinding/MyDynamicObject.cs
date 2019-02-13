using System.Collections.Generic;
using System.Dynamic;

namespace DynamicBinding
{
	public class MyDynamicObject : DynamicObject
	{
		private readonly Dictionary<string, object> members = new Dictionary<string, object>();

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			if (members.ContainsKey(binder.Name))
			{
				result = members[binder.Name];
				return true;
			}
			else
			{
				result = null;
				return false;
			}
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			members[binder.Name] = value;
			return true;
		}
	}
}
