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
            catch (LocalOptimisticConcurrencyException<Auto> e)
            {
                throw new FaultException<AutoDto>(e.MergedEntity.ConvertToDto());
            }
        }

        public void UpdateReservation(ReservationDto modified, ReservationDto original)
        {
            WriteActualMethod();
            try
            {
                component.updateReservation(modified.ConvertToEntity(), original.ConvertToEntity());
            }
            catch (LocalOptimisticConcurrencyException<Auto> e)
            {
                throw new FaultException<AutoDto>(e.MergedEntity.ConvertToDto());
            }
        }

        public AutoDto insertAuto(AutoDto auto)
        {
            WriteActualMethod(); 
            return component.insertAuto(auto.ConvertToEntity()).ConvertToDto();
        }

        public KundeDto insertKunde(KundeDto kunde)
        {
            WriteActualMethod();
            return component.insertKunde(kunde.ConvertToEntity()).ConvertToDto();
        }

        public ReservationDto insertReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            return component.insertReservation(reservation.ConvertToEntity()).ConvertToDto();
        }

        public AutoDto deletAuto(AutoDto auto)
        {
            WriteActualMethod(); 
            return component.deleteAuto(auto.ConvertToEntity()).ConvertToDto();
        }

        public KundeDto deleteKunde(KundeDto kunde)
        {
            WriteActualMethod(); 
            return component.deleteKunde(kunde.ConvertToEntity()).ConvertToDto();
        }

        public ReservationDto deleteReservation(ReservationDto reservation)
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