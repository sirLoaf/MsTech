using System;
using System.Runtime.Serialization;
using System.Text;

namespace AutoReservation.Common.DataTransferObjects
{
    [DataContract]
    public class AutoDto : DtoBase
    {
        private int basistarif;
        private int id;
        private string marke;
        private int tagestarif;
        private AutoKlasse autoklasse;

        public int Basistarif
        {
            get { return basistarif; }
            set
            {
                if (basistarif != value)
                {
                    basistarif = value;
                    RaisePropertyChanged();
                }
            }
        }

		public int Id 
        { 
            get { return id; } 
            set 
            { 
                if (id != value) 
                {
                    id = value;
                    RaisePropertyChanged(); 
                } 
            } 
        }           
        
        public string Marke 
        { 
            get { return marke; } 
            set 
            { 
                if (marke != value) 
                {
                    marke = value;
                    RaisePropertyChanged();
                } 
            } 
        }           
        
        public int Tagestarif 
        { 
            get { return tagestarif; } 
            set 
            { 
                if (tagestarif != value) 
                {
                    tagestarif = value;
                    RaisePropertyChanged(); 
                } 
            } 
        }
        
        public AutoKlasse AutoKlasse 
        { 
            get { return autoklasse; } 
            set 
            { 
                if (autoklasse != value)
                {
                    autoklasse = value;
                    RaisePropertyChanged();
                }
            } 
        }


        public override string validate()
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(marke))
            {
                error.AppendLine("- marke ist nicht gesetzt.");
            }
            if (tagestarif <= 0)
            {
                error.AppendLine("- tagestarif muss grösser als 0 sein.");
            }
            if (autoklasse == AutoKlasse.Luxusklasse && basistarif <= 0)
            {
                error.AppendLine("- basistarif eines luxusautos muss grösser als 0 sein.");
            }

            if (error.Length == 0) { return null; }

            return error.ToString();
        }

        public override object clone()
        {
            return new AutoDto
            {
                id = id,
                marke = marke,
                tagestarif = tagestarif,
                autoklasse = autoklasse,
                basistarif = basistarif
            };
        }

        public override string tostring()
        {
            return string.Format(
                "{0}; {1}; {2}; {3}; {4}",
                id,
                marke,
                tagestarif,
                basistarif,
                autoklasse);
        }

    }
}
