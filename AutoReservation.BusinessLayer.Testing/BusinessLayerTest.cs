using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AutoReservation.BusinessLayer;
using AutoReservation.Dal;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {
        private AutoReservationBusinessComponent target;
        private AutoReservationBusinessComponent Target
        {
            get
            {
                if (target == null)
                {
                    target = new AutoReservationBusinessComponent();
                }
                return target;
            }
        }


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }
        
        [TestMethod]
        public void UpdateAutoTest()
        {
            StandardAuto auto = new StandardAuto 
            { 
                Marke = "Lada", 
                Tagestarif = 10 
            }; 
            
            Auto org = Target.insertAuto(auto); 
            Auto mod = Target.getAuto(org.Id); 
            mod.Marke = "VW"; 
            Target.updateAuto(mod, org); 
            Auto res = Target.getAuto(mod.Id); 
            Assert.AreEqual("VW", res.Marke);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            Kunde org = Target.getKunde(1); 
            Kunde mod = Target.getKunde(1); 
            mod.Nachname = "Rieder"; 
            Target.updateKunde(mod, org); 
            Kunde res = Target.getKunde(1); 
            Assert.AreEqual("Rieder", res.Nachname);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            Reservation org = Target.getReservation(1); 
            Reservation mod = Target.getReservation(1); 
            mod.AutoId = 3; Target.updateReservation(mod, org); 
            Reservation res = Target.getReservation(1); 
            Assert.AreEqual(3, res.AutoId);
        }

    }
}
