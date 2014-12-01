using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoReservation.Dal;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {
        //Insert
        public Auto insertAuto(Auto auto)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Autos.Add(auto);
                context.SaveChanges();
                return auto;
            }
        }
        public Kunde insertKunde(Kunde kunde)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Kunden.Add(kunde);
                context.SaveChanges();
                return kunde;
            }
        }
        public Reservation insertReservation(Reservation reservation)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Reservationen.Add(reservation);
                context.SaveChanges();
                return reservation;
            }
        }

        //Update
        public void updateAuto(Auto modified, Auto original)
        {      
            using (AutoReservationEntities context = new AutoReservationEntities())   
            {
                try 
                { 
                    context.Autos.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified); 
                    context.SaveChanges(); 
                }
                catch (DbUpdateConcurrencyException) 
                { 
                    HandleDbConcurrencyException(context, original); 
                } 
            } 
        }
        public void updateKunde(Kunde modified, Kunde original)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                try
                {
                    context.Kunden.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }
            }
        }
        public void updateReservation(Reservation modified, Reservation original)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                try
                {
                    context.Reservationen.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }
            }
        } 

        //Delete
        public Auto deleteAuto (Auto auto)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Autos.Attach(auto);
                context.Autos.Remove(auto);
                context.SaveChanges();
                return auto;
            }
        }
        public Reservation deleteReservation(Reservation reservation)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Reservationen.Attach(reservation);
                context.Reservationen.Remove(reservation);
                context.SaveChanges();
                return reservation;
            }
        }
        public Kunde deleteKunde(Kunde kunde)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Kunden.Attach(kunde);
                context.Kunden.Remove(kunde); 
                context.SaveChanges();
                return kunde;
            }
        }

        //Getter
        public Auto getAuto(int index)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                Auto auto = context.Autos.SingleOrDefault(r => r.Id == index);
                return auto;
            }
        }
        public Kunde getKunde(int index)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                Kunde kunde = context.Kunden.SingleOrDefault(r => r.Id == index);
                return kunde;
            }
        }
        public Reservation getReservation(int index)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                Reservation reservation = context.Reservationen.SingleOrDefault(r => r.Id == index);
                return reservation;
            }
        }
        public List<Auto> getAutos()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                List<Auto> autos = context.Autos.ToList();
                return autos;
            }

        }
        public List<Kunde> getKunden()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                List<Kunde> kunden = context.Kunden.ToList();
                return kunden;
            }

        }
        public List<Reservation> getReservationen()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                List<Reservation> reservationen = context.Reservationen.ToList();
                return reservationen;
            }

        }
        private static void HandleDbConcurrencyException<T>(AutoReservationEntities context, T original) where T : class
        {
            var databaseValue = context.Entry(original).GetDatabaseValues();
            context.Entry(original).CurrentValues.SetValues(databaseValue);

            throw new LocalOptimisticConcurrencyException<T>(string.Format("Update {0}: Concurrency-Fehler", typeof(T).Name), original);
        }

    }
}