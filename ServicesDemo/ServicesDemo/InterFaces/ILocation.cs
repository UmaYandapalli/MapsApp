using System;
namespace ServicesDemo.InterFaces
{
    public interface ILocation
    {
        void ObtainMyLocation();
        event EventHandler<ILocationEventArgs> locationObtained;

    }
    public interface ILocationEventArgs
    {
        double lat { get; set; }
        double lng { get; set; }
    }
}
