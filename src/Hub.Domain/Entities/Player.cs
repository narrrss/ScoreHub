using System;
using System.Numerics;
using Hub.Domain.Primitives;

namespace Hub.Domain.Entities
{
	public class Player : Entity
	{
		public Player(Guid Id):base(Id)
        {
        }
        public Player()
        {

        }
        public string FullName { get; set; }
        public Guid CountryId { get; set; }
        public Guid PositionId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Height { get; set; }
        public short Weight { get; set; }
        public List<TeamPlayer> PlayerTeams { get; set; }

    }
}

