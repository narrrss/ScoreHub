using System;
using Hub.Domain.Primitives;

namespace Hub.Domain.Entities;

public sealed class Team : Entity
{
    public Team(Guid teamId) : base(teamId)
    {

    }
    public Team()
    {

    }
    public string Name { get; set; }
    public string Logo { get; set; }
    public ICollection<TeamPlayer> TeamPlayers { get; set; }
    //public Guid CountryId { get; set; }
    //public Guid StadiumId { get; set; }

}




