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
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateAutoTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateAutoTestWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateKundeTestWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateReservationTestWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void DeleteKundeTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void DeleteAutoTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }
    }
}
