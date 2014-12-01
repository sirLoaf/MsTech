using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {
        [OperationContract]
        void UpdateAuto(AutoDto modified, AutoDto original);
        [OperationContract]
        void UpdateKunde(KundeDto modified, KundeDto original);
        [OperationContract]
        void UpdateReservation(ReservationDto modified, ReservationDto original);

        [OperationContract]
        AutoDto insertAuto(AutoDto auto);
        [OperationContract]
        KundeDto insertKunde(KundeDto kunde);
        [OperationContract]
        ReservationDto insertReservation(ReservationDto reservation);

        [OperationContract]
        AutoDto deletAuto(AutoDto auto);
        [OperationContract]
        KundeDto deleteKunde(KundeDto kunde);
        [OperationContract]
        ReservationDto deleteReservation(ReservationDto reservation);

        [OperationContract]
        List<AutoDto> getAutos();
        [OperationContract]
        List<KundeDto> getKunden();
        [OperationContract]
        List<ReservationDto> getReservationen();

        [OperationContract]
        AutoDto getAuto(int index);
        [OperationContract]
        KundeDto getKunde(int index);
        [OperationContract]
        ReservationDto getReservation(int index);
    }
}
