using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }

        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void AutosTest()
        {
            List<AutoDto> list = Target.getAutos(); 
            Assert.AreEqual("Fiat Punto", list[0].Marke);
        }

        [TestMethod]
        public void KundenTest()
        {
            List<KundeDto> list = Target.getKunden();
            Assert.AreEqual("Zufall", list[3].Nachname);
            Assert.AreEqual("Timo", list[1].Vorname);
        }

        [TestMethod]
        public void ReservationenTest()
        {
            List<ReservationDto> list = Target.getReservationen(); 
            Assert.AreEqual("20.01.2020 00:00:00", list[2].Bis.ToString()); 
        }

        [TestMethod]
        public void GetAutoByIdTest()
        {
            AutoDto auto = Target.getAuto(2); 
            Assert.AreEqual("VW Golf", auto.Marke);
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            KundeDto kunde = Target.getKunde(1);
            Assert.AreEqual("Nass", kunde.Nachname);
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            ReservationDto reservation = Target.getReservation(1);
            Assert.AreEqual("20.01.2020 00:00:00", reservation.Bis.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))] 
        public void GetReservationByIllegalNr()
        {
            ReservationDto reservation = Target.getReservation(1234);
            KundeDto kunde = reservation.Kunde;
        }

        [TestMethod]
        public void InsertAutoTest()
        {
            AutoDto auto = new AutoDto
            {
                Marke = "Trabant",
                AutoKlasse = AutoKlasse.Standard
            };
            AutoDto newAuto = Target.InsertAuto(auto);
            Assert.AreEqual("Trabant", newAuto.Marke);
            Assert.AreEqual(4, newAuto.Id);
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            KundeDto kunde = new KundeDto
            {
                Nachname = "Gomez",
                Vorname = "Sergio",
                Geburtsdatum = new DateTime(1975, 3, 5)
            };
            KundeDto newKunde = Target.InsertKunde(kunde);
            Assert.AreEqual("Sergio", newKunde.Vorname);
            Assert.AreEqual(5, newKunde.Id);
        }

        [TestMethod]
        public void InsertReservationTest() 
        { 
            AutoDto auto = Target.getAuto(2); 
            KundeDto kunde = Target.getKunde(1); 
            ReservationDto reservation = new ReservationDto 
            { 
                Von = new DateTime(1999, 8, 1), 
                Bis = new DateTime(1999, 8, 25), 
                Auto = auto, 
                Kunde = kunde 
            }; 
            ReservationDto newReservation = Target.InsertReservation(reservation); 
            Assert.AreEqual("VW Golf", newReservation.Auto.Marke); 
            Assert.AreEqual(4, newReservation.ReservationNr);
        }
        [TestMethod]
        public void UpdateAutoTest() 
        { 
            AutoDto original = Target.getAuto(1); 
            AutoDto modified = Target.getAuto(1); 
            modified.Marke = "Seat"; 
            Target.UpdateAuto(modified, original); 
            AutoDto updatedAuto = Target.getAuto(1); 
            Assert.AreEqual("Seat", updatedAuto.Marke); 
        }
        [TestMethod]
        public void UpdateKundeTest() 
        { 
            KundeDto original = Target.getKunde(1); 
            KundeDto modified = Target.getKunde(1); 
            modified.Nachname = "Müller"; 
            Target.UpdateKunde(modified, original); 
            KundeDto updatedKunde = Target.getKunde(1); 
            Assert.AreEqual("Müller", updatedKunde.Nachname); 
        }
        [TestMethod]
        public void UpdateReservationTest() 
        { 
            ReservationDto original = Target.getReservation(1); 
            ReservationDto modified = Target.getReservation(1); 
            modified.Auto = Target.getAuto(2); 
            Target.UpdateReservation(modified, original); 
            ReservationDto updatedReservation = Target.getReservation(1); 
            Assert.AreEqual("VW Golf", updatedReservation.Auto.Marke);
        }
        [TestMethod]
        [ExpectedException(typeof(FaultException<AutoDto>))]
        public void UpdateAutoTestWithOptimisticConcurrency() 
        { 
            AutoDto original = Target.getAuto(1); 
            AutoDto modified = Target.getAuto(1); 

            original.Marke = "Nissan"; 
            modified.Marke = "Volvo"; 

            Target.UpdateAuto(modified, original); 
        }
        [TestMethod]
        [ExpectedException(typeof(FaultException<KundeDto>))]
        public void UpdateKundeTestWithOptimisticConcurrency() 
        { 
            KundeDto original = Target.getKunde(1); 
            KundeDto modified = Target.getKunde(1); 
            original.Nachname = "Tanner"; 
            modified.Nachname = "Hugentobler"; 
            Target.UpdateKunde(modified, original); 
        }
        [TestMethod]
        [ExpectedException(typeof(FaultException<ReservationDto>))]
        public void UpdateReservationTestWithOptimisticConcurrency() 
        { 
            ReservationDto original = Target.getReservation(1); 
            ReservationDto modified = Target.getReservation(1); 
            original.Auto = Target.getAuto(3); 
            modified.Auto = Target.getAuto(2); 
            Target.UpdateReservation(modified, original); 
        }
        [TestMethod]
        public void DeleteKundeTest() 
        {
            KundeDto newkunde = new KundeDto 
            { 
                Nachname = "Laib",
                Vorname = "Fabio", 
                Geburtsdatum = new DateTime(1988, 2, 9) 
            }; 
            KundeDto kunde = Target.InsertKunde(newkunde); 
            var count = Target.getKunden().Count; 
            KundeDto del = Target.DeleteKunde(kunde); 
            Assert.AreEqual("Laib", del.Nachname); 
            Assert.AreEqual(count, Target.getKunden().Count + 1); 
        }
        [TestMethod]
        public void DeleteAutoTest()
        { 
            AutoDto auto = Target.getAuto(2); 
            AutoDto del = Target.DeleteAuto(auto); 
            Assert.AreEqual("VW Golf", del.Marke); 
            Assert.IsNull(Target.getAuto(2)); 
        }
        [TestMethod]
        public void DeleteReservationTest() 
        { 
            ReservationDto reservation = Target.getReservation(2); 
            ReservationDto del = Target.DeleteReservation(reservation); 
            Assert.AreEqual("20.01.2020 00:00:00", del.Bis.ToString()); 
            Assert.IsNull(Target.getReservation(2)); 
        }
    }
}