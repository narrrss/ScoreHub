using System;
using Hub.Domain.Primitives;

namespace Hub.Domain.Entities;

public class TeamPlayer : Entity
{
    public TeamPlayer(Guid Id) : base(Id)
    {
        
    }
    public TeamPlayer()
    {

    }

    public Guid TeamId { get; set; }
    public Guid PlayerId { get; set; }
    public bool Current { get; set; }

    //references

    public Team Team { get; set; }
    public Player Player { get; set; }
}


