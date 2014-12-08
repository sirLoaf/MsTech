using System;
using System.Diagnostics;
using AutoReservation.Common.Interfaces;
using AutoReservation.Common.DataTransferObjects;
using AutoReservation.BusinessLayer;
using System.ServiceModel;
using AutoReservation.Dal;
using System.Collections.Generic;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {
        AutoReservationBusinessComponent component = new AutoReservationBusinessComponent();

        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }

        public void UpdateAuto(AutoDto modified, AutoDto original)
        {
            WriteActualMethod();
            try
            {
                component.updateAuto(modified.ConvertToEntity(), original.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<Auto> e)
            {
                throw new FaultException<AutoDto>(e.MergedEntity.ConvertToDto());
            }
        }



        public void UpdateKunde(KundeDto modified, KundeDto original)
        {
            WriteActualMethod();
            try
            {
                component.updateKunde(modified.ConvertToEntity(), original.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<Kunde> e)
            {
                throw new FaultException<KundeDto>(e.MergedEntity.ConvertToDto());
            }
        }

        public void UpdateReservation(ReservationDto modified, ReservationDto original)
        {
            WriteActualMethod();
            try
            {
                Auto automod = modified.Auto.ConvertToEntity();
                Kunde kundemod = modified.Kunde.ConvertToEntity();
                Reservation mod = modified.ConvertToEntity();
                mod.Auto = automod;
                mod.Kunde = kundemod;
                Auto autoorg = original.Auto.ConvertToEntity();
                Kunde kundeorg = original.Kunde.ConvertToEntity();
                Reservation org = original.ConvertToEntity();
                org.Auto = autoorg;
                org.Kunde = kundeorg;
                component.updateReservation(mod, org);
            }
            catch (LocalOptimisticConcurrencyException<Reservation> e)
            {
                throw new FaultException<ReservationDto>(e.MergedEntity.ConvertToDto());
            }
        }

        public AutoDto InsertAuto(AutoDto auto)
        {
            WriteActualMethod();
            return component.insertAuto(auto.ConvertToEntity()).ConvertToDto();
        }

        public KundeDto InsertKunde(KundeDto kunde)
        {
            WriteActualMethod();
            return component.insertKunde(kunde.ConvertToEntity()).ConvertToDto();
        }

        public ReservationDto InsertReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            Auto auto = reservation.Auto.ConvertToEntity();
            Kunde kunde = reservation.Kunde.ConvertToEntity();
            Reservation res = reservation.ConvertToEntity();
            res.Auto = auto;
            res.Kunde = kunde;
            return component.insertReservation(res).ConvertToDto();
        }

        public AutoDto DeleteAuto(AutoDto auto)
        {
            WriteActualMethod();
            return component.deleteAuto(auto.ConvertToEntity()).ConvertToDto();
        }

        public KundeDto DeleteKunde(KundeDto kunde)
        {
            WriteActualMethod();
            return component.deleteKunde(kunde.ConvertToEntity()).ConvertToDto();
        }

        public ReservationDto DeleteReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            return component.deleteReservation(reservation.ConvertToEntity()).ConvertToDto();
        }

        public List<AutoDto> getAutos()
        {
            WriteActualMethod();
            return component.getAutos().ConvertToDtos();
        }

        public List<KundeDto> getKunden()
        {
            WriteActualMethod();
            return component.getKunden().ConvertToDtos();
        }

        public List<ReservationDto> getReservationen()
        {
            WriteActualMethod();
            return component.getReservationen().ConvertToDtos();
        }

        public AutoDto getAuto(int index)
        {
            WriteActualMethod();
            return component.getAuto(index).ConvertToDto();
        }

        public KundeDto getKunde(int index)
        {
            WriteActualMethod();
            return component.getKunde(index).ConvertToDto();
        }

        public ReservationDto getReservation(int index)
        {
            WriteActualMethod();
            return component.getReservation(index).ConvertToDto();
        }


       
    }
}