using System;
using Hub.Domain.Primitives;

namespace Hub.Domain.Entities
{
	public class PlayerStats : Entity
	{
		public PlayerStats(Guid Id):base(Id)
		{
		}
		public int GoalsCount { get; set; }
		public int AssistsCount { get; set; }
		public Guid TeamPlayerId { get; set; }
		public TeamPlayer TeamPlayer { get; set; }
	}
}

