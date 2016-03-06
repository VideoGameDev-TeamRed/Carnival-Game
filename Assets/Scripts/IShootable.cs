using System;
using System.Collections;

namespace com.teamred.carnivalgame
{
	public interface IShootable
	{
		void Fire (float shotForce);

		IEnumerator Reload (float timeToReload);
	}
}

