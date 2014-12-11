using AutoReservation.TestEnvironment;
using AutoReservation.Ui.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;

namespace AutoReservation.Ui.Testing
{
    [TestClass]
    public class ViewModelTest
    {
        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void AutosLoadTest()
        {
            AutoViewModel autoModel = new AutoViewModel();
            Assert.IsTrue(autoModel.LoadCommand.CanExecute(null));
            autoModel.LoadCommand.Execute(null);
            Assert.AreEqual("VW Golf", autoModel.Autos[1].Marke);
            Assert.AreEqual("Audi S6", autoModel.Autos[2].Marke);
            
        }

        [TestMethod]
        public void KundenLoadTest()
        {
            KundeViewModel kundenModel = new KundeViewModel();
            Assert.IsTrue(kundenModel.LoadCommand.CanExecute(null));
            kundenModel.LoadCommand.Execute(null);
            Assert.AreEqual("Nass", kundenModel.Kunden[0].Nachname);
            Assert.AreEqual("Zufall", kundenModel.Kunden[3].Nachname);
        }

        [TestMethod]
        public void ReservationenLoadTest()
        {
            ReservationViewModel reservationModel = new ReservationViewModel();
            Assert.IsTrue(reservationModel.LoadCommand.CanExecute(null));
            reservationModel.LoadCommand.Execute(null);
            Assert.AreEqual("Fiat Punto", reservationModel.Reservationen[0].Auto.Marke);
            Assert.AreEqual("Beil", reservationModel.Reservationen[1].Kunde.Nachname);
            Assert.AreEqual("Timo", reservationModel.Reservationen[1].Kunde.Vorname);
     
        }
    }
}