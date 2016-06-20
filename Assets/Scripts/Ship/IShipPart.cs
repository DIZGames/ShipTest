
public interface IShipPart{

    ShipPartPosition position { get; }
	bool floorLevel { get; }
    bool createsNewShip { get; } // if true ShipPartPosiion should be set to Center
}
