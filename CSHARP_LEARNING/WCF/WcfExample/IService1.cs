using System.ServiceModel;

namespace WcfExample
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        double Add(double firstVal, double secondVal);

        [OperationContract]
        double Sub(double firstVal, double secondVal);

        [OperationContract]
        double Mul(double firstVal, double secondVal);

        [OperationContract]
        double Div(double firstVal, double secondVal);
    }
}
