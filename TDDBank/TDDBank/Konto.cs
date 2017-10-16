using System;

namespace TDDBank
{
    public class Konto
    {
        public decimal Kontostand { get; set; }

        public void Einzahlen(decimal betrag)
        {
            if (betrag < 0)
                throw new ArgumentException($"{nameof(betrag)} muss positiv sein.");

            Kontostand += betrag;
        }

        public void Auszahlen(decimal betrag)
        {
            if (betrag < 0)
                throw new ArgumentException($"{nameof(betrag)} muss positiv sein.");
            if (Kontostand - betrag < 0)
                throw new ArgumentException($"{nameof(betrag)} darf nicht größer als der Kontostand sein.");
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
                throw new InvalidOperationException("Nur an Wochentagen dürfen Beträge ausgezahlt werden.");

            Kontostand -= betrag;
        }
    }
}
