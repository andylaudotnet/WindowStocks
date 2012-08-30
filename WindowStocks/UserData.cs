// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserData.cs" company="NSnaiL">
//   Copyright (C) 2009 NSnaiL
// </copyright>
// <summary>
//   Defines the UserData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowStocks
{
    using System;
    using System.Collections;

    [Serializable]
    internal class UserData : Entity
    {
        #region Fields

        private Hashtable _Stocks;

        #endregion Fields

        #region Constructors (1)

        private UserData()
        {
            Stocks = new Hashtable();
        }

        #endregion Constructors

        #region Properties (1)

        public Hashtable Stocks
        {
            get { return _Stocks; }
            set { _Stocks = value; }
        }

        #endregion Properties

        #region Methods (2)

        // Public Methods (1) 

        public void Save(string filePath)
        {
            Save(GetType(), filePath);
        }
        // Internal Methods (1) 

        internal static UserData Load(string filePath)
        {
            return Load(new UserData(), filePath);
        }

        internal Stock[] ToStockArray()
        {
            Stock[] rtn = new Stock[Stocks.Count];
            int i = 0;
            foreach (DictionaryEntry de in Stocks)
            {
                rtn[i++] = Stocks[de.Key] as Stock;
            }
            return rtn;
        }

        #endregion Methods
    }
}
