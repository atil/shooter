using UnityEngine;
using System.Collections;

namespace Shooter
{
	public class PlayerShipView : ShipView
	{
	    public override void BindTo(ModelBase model)
	    {
	        base.BindTo(model);

	        ((PlayerShipModel) model).Position = transform.position;
	    }

	    protected override void ModelPropertyChanged(object sender, PropertyChangedEventArgs e)
	    {
	        base.ModelPropertyChanged(sender, e);
	        if (e.PropertyName == "Position")
	        {
	            transform.position = (Vector2) e.Value;
	        }
	    }
	}
}