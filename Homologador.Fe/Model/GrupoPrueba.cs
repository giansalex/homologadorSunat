using System;

namespace Homologador.Fe.Model
{
    public enum GrupoPrueba : byte
    {
        Gravada = 1,
        InafectaExonerada = 2,
        Gratuita = 3,
        DescuentoGlobal = 4,
        ConIsc = 5,
        ConPercepcion = 6,
        OtrasMonedas = 7,
    }

    /// <summary>
    /// Class GroupHelper.
    /// </summary>
    public static class GroupHelper
    {
        /// <summary>
        /// Gets from code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>GrupoPrueba.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">@Grupo no soportado</exception>
        public static GrupoPrueba GetFromCode(string code)
        {
            switch (code)
            {
                case "1":
                case "8":
                    return GrupoPrueba.Gravada;
                case "2":
                case "9":
                    return GrupoPrueba.InafectaExonerada;
                case "3":
                case "10":
                    return GrupoPrueba.Gratuita;
                case "4":
                case "11":
                    return GrupoPrueba.DescuentoGlobal;
                case "5":
                case "21":
                    return GrupoPrueba.ConIsc;
                case "6":
                case "22":
                    return GrupoPrueba.ConPercepcion;
                case "7":
                case "12":
                    return GrupoPrueba.OtrasMonedas;
                default:
                    throw new ArgumentOutOfRangeException(nameof(code), @"Grupo no soportado");
            }
        }
    }
}
