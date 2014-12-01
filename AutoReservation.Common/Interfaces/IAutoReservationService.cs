using System.Collections.Generic;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    public interface IAutoReservationService
    {
        void UpdateAuto(AutoDto changed, AutoDto old);
        void UpdateKunde(KundeDto changed, KundeDto old);
        void UpdateReservation(ReservationDto changed, ReservationDto old);

        AutoDto insertAuto(AutoDto auto);
        KundeDto insertKunde(KundeDto kunde);
        ReservationDto insertReservation(ReservationDto reservation);

        AutoDto deletAuto(AutoDto auto);
        KundeDto deleteKunde(KundeDto kunde);
        ReservationDto deleteReservation(ReservationDto reservation);

        List<AutoDto> getAutos();
        List<KundeDto> getKunden();
        List<ReservationDto> getReservationen();

        AutoDto getAuto(int index);
        KundeDto getKunder(int index);
        ReservationDto getReservation(int index);
    }
}
