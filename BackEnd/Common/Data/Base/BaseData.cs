using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Validations.Base
{
    public abstract class BaseData
    {
        /// <summary>
        /// this section is use to declare variables that have a global use inside this class
        /// </summary>
        #region Variables

         protected object dataVariable;

        #endregion

        #region Constructors

            /// <summary>
            /// class constructor
            /// </summary>
            /// <param name="paramDataVariable">
            /// this parameters contains the data for a given variable an assignes it to the global 
            /// variable dataVariable for further validations inside this class
            /// </param>
            public BaseData(object paramDataVariable)
            {
                dataVariable = paramDataVariable;
            }

        #endregion
    }
}
