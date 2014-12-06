using AutoReservation.Common.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {
        [OperationContract]
        [FaultContract(typeof(FaultException))] 
        void UpdateAuto(AutoDto modified, AutoDto original);
        [OperationContract]
        [FaultContract(typeof(AutoDto))] 
        void UpdateKunde(KundeDto modified, KundeDto original);
        [OperationContract]
        void UpdateReservation(ReservationDto modified, ReservationDto original);

        [OperationContract]
        AutoDto InsertAuto(AutoDto auto);
        [OperationContract]
        KundeDto InsertKunde(KundeDto kunde);
        [OperationContract]
        ReservationDto InsertReservation(ReservationDto reservation);

        [OperationContract]
        AutoDto DeleteAuto(AutoDto auto);
        [OperationContract]
        KundeDto DeleteKunde(KundeDto kunde);
        [OperationContract]
        ReservationDto DeleteReservation(ReservationDto reservation);

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
